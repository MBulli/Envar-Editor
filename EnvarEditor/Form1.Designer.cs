namespace EnvarEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editVariableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.runAsAdminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMachineRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUserRegistry = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRunAsAdmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(865, 383);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(865, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCount
            // 
            this.toolStripStatusLabelCount.Name = "toolStripStatusLabelCount";
            this.toolStripStatusLabelCount.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelCount.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItemRegistry,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(865, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewVariableToolStripMenuItem,
            this.deleteVariableToolStripMenuItem,
            this.editVariableToolStripMenuItem,
            this.toolStripSeparator2,
            this.runAsAdminToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // addNewVariableToolStripMenuItem
            // 
            this.addNewVariableToolStripMenuItem.Name = "addNewVariableToolStripMenuItem";
            this.addNewVariableToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.addNewVariableToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.addNewVariableToolStripMenuItem.Text = "Add new Variable";
            this.addNewVariableToolStripMenuItem.Click += new System.EventHandler(this.addNewVariableToolStripMenuItem_Click);
            // 
            // deleteVariableToolStripMenuItem
            // 
            this.deleteVariableToolStripMenuItem.Name = "deleteVariableToolStripMenuItem";
            this.deleteVariableToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.deleteVariableToolStripMenuItem.Text = "Delete Variable";
            this.deleteVariableToolStripMenuItem.Click += new System.EventHandler(this.deleteVariableToolStripMenuItem_Click);
            // 
            // editVariableToolStripMenuItem
            // 
            this.editVariableToolStripMenuItem.Name = "editVariableToolStripMenuItem";
            this.editVariableToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editVariableToolStripMenuItem.Text = "Edit Variable";
            this.editVariableToolStripMenuItem.Click += new System.EventHandler(this.editVariableToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
            // 
            // runAsAdminToolStripMenuItem
            // 
            this.runAsAdminToolStripMenuItem.Name = "runAsAdminToolStripMenuItem";
            this.runAsAdminToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.runAsAdminToolStripMenuItem.Text = "Run as Admin";
            this.runAsAdminToolStripMenuItem.Click += new System.EventHandler(this.runAsAdminToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItemRegistry
            // 
            this.toolStripMenuItemRegistry.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMachineRegistry,
            this.toolStripMenuItemUserRegistry});
            this.toolStripMenuItemRegistry.Name = "toolStripMenuItemRegistry";
            this.toolStripMenuItemRegistry.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItemRegistry.Text = "Registry";
            // 
            // toolStripMenuItemMachineRegistry
            // 
            this.toolStripMenuItemMachineRegistry.Name = "toolStripMenuItemMachineRegistry";
            this.toolStripMenuItemMachineRegistry.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemMachineRegistry.Text = "Open Local Machine Key";
            this.toolStripMenuItemMachineRegistry.Click += new System.EventHandler(this.toolStripMenuItemMachineRegistry_Click);
            // 
            // toolStripMenuItemUserRegistry
            // 
            this.toolStripMenuItemUserRegistry.Name = "toolStripMenuItemUserRegistry";
            this.toolStripMenuItemUserRegistry.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItemUserRegistry.Text = "Open User Key";
            this.toolStripMenuItemUserRegistry.Click += new System.EventHandler(this.toolStripMenuItemUserRegistry_Click);
            // 
            // buttonRunAsAdmin
            // 
            this.buttonRunAsAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRunAsAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRunAsAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRunAsAdmin.Location = new System.Drawing.Point(0, 24);
            this.buttonRunAsAdmin.Name = "buttonRunAsAdmin";
            this.buttonRunAsAdmin.Size = new System.Drawing.Size(865, 35);
            this.buttonRunAsAdmin.TabIndex = 0;
            this.buttonRunAsAdmin.Text = "Run as administrator";
            this.buttonRunAsAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRunAsAdmin.UseVisualStyleBackColor = true;
            this.buttonRunAsAdmin.Click += new System.EventHandler(this.buttonRunAsAdmin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonRunAsAdmin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "Form1";
            this.Text = "Environment variables editor";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewVariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteVariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editVariableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runAsAdminToolStripMenuItem;
        private System.Windows.Forms.Button buttonRunAsAdmin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRegistry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMachineRegistry;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserRegistry;

    }
}

