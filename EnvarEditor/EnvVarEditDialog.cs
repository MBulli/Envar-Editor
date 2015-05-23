using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvarEditor
{
    public partial class EnvVarEditDialog : Form
    {
        private EnvVar envVar;
        private EnvVarEditMode editMode;

        internal EnvVar EnvironmentVariable
        {
            get { return envVar; }
            set { envVar = value; OnEnvironmentVariableChanged(); }
        }

        public EnvVarEditMode EditMode
        {
            get { return editMode; }
            set { editMode = value; OnEditModeChanged(); }
        }

        public EnvVarEditDialog()
        {
            InitializeComponent();

            // see: http://msdn.microsoft.com/en-us/library/windows/desktop/ms724872.aspx
            this.textBoxName.MaxLength = 16383;
            // see: Exceptions of System.Environment.SetEnvironmentVariable()
            this.textBoxValue.MaxLength = 32767 - 1;

            // TODO:
            // check this? http://blogs.msdn.com/b/oldnewthing/archive/2006/09/29/776926.aspx
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // give value textbox the focus but remove selection
            this.textBoxValue.Select();
            this.textBoxValue.SelectAll();
            this.textBoxValue.DeselectAll();
        }

        private void OnEditModeChanged()
        {
            this.checkBoxUserSpecific.Enabled = editMode == EnvVarEditMode.FullEdit;
            this.textBoxName.ReadOnly = editMode != EnvVarEditMode.FullEdit;
        }

        private void OnEnvironmentVariableChanged()
        {
 	        if (this.envVar == null)
	        {
                this.checkBoxUserSpecific.Checked = false;
                this.textBoxName.Text = null;
                this.textBoxValue.Text = null;
                this.Text = null;
	        }
            else
            {
                this.checkBoxUserSpecific.Checked = this.envVar.UserSpecific;
                this.textBoxName.Text = this.envVar.Name;
                this.Text = this.envVar.Name;

                this.textBoxValue.Lines = this.envVar.ValuesSeperated();
            }
        }

        private void buttonCheckPaths_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            int pathsFound = 0;
            int pathsInvalid = 0;
            int linesSkipped = 0;

            foreach (string line in this.textBoxValue.Lines)
            {
                if (!LooksLikeAPathToTest(line))
                {
                    linesSkipped++;
                }
                else
                {
                    pathsFound++;
                    bool exists = false;
                    try
                    {
                        exists = System.IO.Directory.Exists(line);

                        if (!exists)
                            exists = System.IO.File.Exists(line);
                    }
                    catch (System.IO.IOException)
                    {
                        exists = false;
                    }

                    if (!exists)
                    {
                        sb.AppendLine(line);
                        pathsInvalid++;
                    }
                }
            }

            if (sb.Length == 0)
            {
                MessageBox.Show(string.Format("Everything seems fine.\nPaths found: {0}", pathsFound),
                                "Path check", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("Paths found: {0}\nThese paths could not be accessed:\n\n{1}", pathsFound, sb.ToString()),
                                               "Path check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private static bool LooksLikeAPathToTest(string path)
        {
            // skip network paths at the moment
            // RegEx: ([a-zA-z]:\\([a-zA-z])*)

            return System.IO.Path.IsPathRooted(path) && !path.StartsWith(@"\\");
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxName.Text))
            {
                MessageBox.Show("A valid variable name must be set.", "Variable name is empty!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringBuilder sb = new StringBuilder();

            string[] lines = this.textBoxValue.Lines;
            int lineCount = lines.Length;

            for (int i = 0; i < lineCount; i++)
            {
                string trimed = lines[i].Trim(' ', ';');

                if (!string.IsNullOrEmpty(trimed))
                {
                    sb.Append(trimed);

                    if (lineCount > 1 && i < lineCount - 1)
                        sb.Append(";");
                }
            }

            this.envVar.UserSpecific = this.checkBoxUserSpecific.Checked;
            this.envVar.Name = this.textBoxName.Text;
            this.envVar.Value = sb.ToString();

            try
            {
                this.envVar.SaveToRegistry();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Could not save variable. Failed with error:\n{0}", ex.Message), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            this.Text = this.textBoxName.Text;
        }

        private void textBoxValue_TextChanged(object sender, EventArgs e)
        {
            // Line breaks are converted to semicolon thus:
            // \r\n     => ; 
            // (2 char) => (1 char)

            int lineCount = textBoxValue.Lines.Count() - 1;
            int semicolons = lineCount;

            int charCount = textBoxValue.Text.Length - lineCount * 2 + semicolons;

            this.labelCharCount.Text = string.Format("{0} Chars", charCount);
        }
    }

    public enum EnvVarEditMode
    {
        FullEdit,
        ValueOnly
    }
}
