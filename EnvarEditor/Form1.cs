using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvarEditor
{
    public partial class Form1 : Form
    {
        ObservableCollection<EnvVar> EnvVars
        {
            get;
            set;
        }

        public Form1()
        {
            InitializeComponent();

            //UpdateDataGridView();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Environment.OSVersion.Version.Major < 6 || UACHelper.IsAdministrator())
            {
                buttonRunAsAdmin.Parent.Controls.Remove(buttonRunAsAdmin);
                buttonRunAsAdmin = null;
                
                fileToolStripMenuItem.DropDownItems.Remove(runAsAdminToolStripMenuItem);
                runAsAdminToolStripMenuItem = null;
            }
            else
            {
                Bitmap icon = null;
                try
                {
                    icon = UACHelper.GetUACShieldIcon();
                }
                catch(Exception)
                {
                    // failed to get icon 
                }

                runAsAdminToolStripMenuItem.Image = icon;
                buttonRunAsAdmin.Image = icon;
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            try
            {
                this.EnvVars = new ObservableCollection<EnvVar>(EnvVar.GetEnvironmentVariables());

                int userCount = EnvVars.Count((var) =>
                {
                    return var.UserSpecific;
                });

                this.toolStripStatusLabelCount.Text = string.Format("User: {0} System: {1} Σ: {2}",
                                                userCount, EnvVars.Count - userCount, EnvVars.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            int oldSelection = 0;

            if (this.dataGridView1.SelectedRows.Count > 0)
	        {
                oldSelection = Math.Min(EnvVars.Count - 1, this.dataGridView1.SelectedRows[0].Index);
	        }

            this.dataGridView1.DataSource = EnvVars;
            this.dataGridView1.Rows[oldSelection].Selected = true;

            if (!this.dataGridView1.Rows[oldSelection].State.HasFlag(DataGridViewElementStates.Displayed))
            {
                this.dataGridView1.FirstDisplayedScrollingRowIndex = oldSelection;   
            }
        }

        private void NewEnvVar()
        {
            EnvVar newVar = new EnvVar();
            newVar.Name = "(New Variable)";

            // check name duplicate

            if (EditEnvVar(newVar, EnvVarEditMode.FullEdit))
            {
                this.EnvVars.Add(newVar);
            }
        }


        private bool EditEnvVar(EnvVar var, EnvVarEditMode editMode)
        {
            if (var == null)
                return false;

            EnvVarEditDialog dlg = new EnvVarEditDialog();
            dlg.EnvironmentVariable = var;
            dlg.EditMode = editMode;

            return dlg.ShowDialog() == DialogResult.OK;
        }

        private void DeleteEnvVar(EnvVar var)
        {
            if (var == null)
                return;

            string msg = string.Format("Really delete '{0}’ permanently? This can’t be undone and could harm your system.", var.Name);
            if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // todo not working atm
                    var.DeleteFromRegistry();
                    this.EnvVars.Remove(var);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Could not delete variable. Failed with error:\n{0}", ex.Message), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private EnvVar GetCurrentSelectedEnvVar()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                return this.EnvVars[rowIndex];
            }

            return null;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EditEnvVar(GetCurrentSelectedEnvVar(), EnvVarEditMode.ValueOnly);
        }


        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Return)
            {
                EditEnvVar(GetCurrentSelectedEnvVar(), EnvVarEditMode.ValueOnly);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEnvVar();
        }

        private void deleteVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEnvVar(GetCurrentSelectedEnvVar());
        }

        private void editVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditEnvVar(GetCurrentSelectedEnvVar(), EnvVarEditMode.ValueOnly);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void runAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UACHelper.RerunApplicationAsAdministrator();
        }

        private void buttonRunAsAdmin_Click(object sender, EventArgs e)
        {
            UACHelper.RerunApplicationAsAdministrator();
        }

        private void toolStripMenuItemMachineRegistry_Click(object sender, EventArgs e)
        {
            OpenRegeditToKey(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\Environment");
        }

        private void toolStripMenuItemUserRegistry_Click(object sender, EventArgs e)
        {
            OpenRegeditToKey(@"HKEY_CURRENT_USER\Environment");
        }

        public static void OpenRegeditToKey(string FullKeyPath)
        {
            using (RegistryKey rKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit", true))
            {
                rKey.SetValue("LastKey", FullKeyPath);
                System.Diagnostics.Process.Start("regedit.exe");   
            }
        }
    }
}
