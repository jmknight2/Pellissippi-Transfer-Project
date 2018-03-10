namespace cliEmailConfig
{
    partial class startPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(startPage));
            this.emailListBox = new System.Windows.Forms.ListBox();
            this.configPassBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.contactGroup = new System.Windows.Forms.GroupBox();
            this.newContactButton = new System.Windows.Forms.Button();
            this.removeContactButton = new System.Windows.Forms.Button();
            this.editContactButton = new System.Windows.Forms.Button();
            this.connectionSettings = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accountEmailBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.senderNameLabel = new System.Windows.Forms.Label();
            this.senderNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.smtpLabel = new System.Windows.Forms.Label();
            this.smtpBox = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.connectionPassBox = new System.Windows.Forms.TextBox();
            this.sendingEmailLabel = new System.Windows.Forms.Label();
            this.senderTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contactGroup.SuspendLayout();
            this.connectionSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailListBox
            // 
            this.emailListBox.FormattingEnabled = true;
            this.emailListBox.Location = new System.Drawing.Point(19, 19);
            this.emailListBox.Name = "emailListBox";
            this.emailListBox.Size = new System.Drawing.Size(103, 186);
            this.emailListBox.TabIndex = 0;
            this.emailListBox.SelectedIndexChanged += new System.EventHandler(this.emailListBox_SelectedIndexChanged);
            // 
            // configPassBox
            // 
            this.configPassBox.Enabled = false;
            this.configPassBox.Location = new System.Drawing.Point(127, 49);
            this.configPassBox.Name = "configPassBox";
            this.configPassBox.PasswordChar = '•';
            this.configPassBox.Size = new System.Drawing.Size(110, 20);
            this.configPassBox.TabIndex = 0;
            this.configPassBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(154, 33);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Enabled = false;
            this.changePasswordButton.Location = new System.Drawing.Point(243, 49);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(75, 20);
            this.changePasswordButton.TabIndex = 1;
            this.changePasswordButton.Text = "Change...";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // contactGroup
            // 
            this.contactGroup.Controls.Add(this.newContactButton);
            this.contactGroup.Controls.Add(this.removeContactButton);
            this.contactGroup.Controls.Add(this.editContactButton);
            this.contactGroup.Controls.Add(this.emailListBox);
            this.contactGroup.Enabled = false;
            this.contactGroup.Location = new System.Drawing.Point(243, 93);
            this.contactGroup.Name = "contactGroup";
            this.contactGroup.Size = new System.Drawing.Size(144, 303);
            this.contactGroup.TabIndex = 4;
            this.contactGroup.TabStop = false;
            this.contactGroup.Text = "Your Email Contacts";
            // 
            // newContactButton
            // 
            this.newContactButton.Location = new System.Drawing.Point(33, 274);
            this.newContactButton.Name = "newContactButton";
            this.newContactButton.Size = new System.Drawing.Size(75, 23);
            this.newContactButton.TabIndex = 3;
            this.newContactButton.Text = "New...";
            this.newContactButton.UseVisualStyleBackColor = true;
            this.newContactButton.Click += new System.EventHandler(this.newContactButton_Click);
            // 
            // removeContactButton
            // 
            this.removeContactButton.Location = new System.Drawing.Point(33, 245);
            this.removeContactButton.Name = "removeContactButton";
            this.removeContactButton.Size = new System.Drawing.Size(75, 23);
            this.removeContactButton.TabIndex = 2;
            this.removeContactButton.Text = "Remove";
            this.removeContactButton.UseVisualStyleBackColor = true;
            this.removeContactButton.Click += new System.EventHandler(this.removeContactButton_Click);
            // 
            // editContactButton
            // 
            this.editContactButton.Location = new System.Drawing.Point(33, 216);
            this.editContactButton.Name = "editContactButton";
            this.editContactButton.Size = new System.Drawing.Size(75, 23);
            this.editContactButton.TabIndex = 1;
            this.editContactButton.Text = "Edit";
            this.editContactButton.UseVisualStyleBackColor = true;
            this.editContactButton.Click += new System.EventHandler(this.editContactButton_Click);
            // 
            // connectionSettings
            // 
            this.connectionSettings.Controls.Add(this.label1);
            this.connectionSettings.Controls.Add(this.accountEmailBox);
            this.connectionSettings.Controls.Add(this.portBox);
            this.connectionSettings.Controls.Add(this.senderNameLabel);
            this.connectionSettings.Controls.Add(this.senderNameTextBox);
            this.connectionSettings.Controls.Add(this.label3);
            this.connectionSettings.Controls.Add(this.smtpLabel);
            this.connectionSettings.Controls.Add(this.smtpBox);
            this.connectionSettings.Controls.Add(this.passLabel);
            this.connectionSettings.Controls.Add(this.connectionPassBox);
            this.connectionSettings.Controls.Add(this.sendingEmailLabel);
            this.connectionSettings.Controls.Add(this.senderTextBox);
            this.connectionSettings.Enabled = false;
            this.connectionSettings.Location = new System.Drawing.Point(20, 93);
            this.connectionSettings.Name = "connectionSettings";
            this.connectionSettings.Size = new System.Drawing.Size(185, 303);
            this.connectionSettings.TabIndex = 5;
            this.connectionSettings.TabStop = false;
            this.connectionSettings.Text = "Connection Settigns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Server Email";
            // 
            // accountEmailBox
            // 
            this.accountEmailBox.Location = new System.Drawing.Point(80, 118);
            this.accountEmailBox.Name = "accountEmailBox";
            this.accountEmailBox.Size = new System.Drawing.Size(100, 20);
            this.accountEmailBox.TabIndex = 4;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(65, 257);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(53, 20);
            this.portBox.TabIndex = 7;
            // 
            // senderNameLabel
            // 
            this.senderNameLabel.AutoSize = true;
            this.senderNameLabel.Location = new System.Drawing.Point(6, 40);
            this.senderNameLabel.Name = "senderNameLabel";
            this.senderNameLabel.Size = new System.Drawing.Size(72, 13);
            this.senderNameLabel.TabIndex = 10;
            this.senderNameLabel.Text = "Sender Name";
            // 
            // senderNameTextBox
            // 
            this.senderNameTextBox.Location = new System.Drawing.Point(80, 40);
            this.senderNameTextBox.Name = "senderNameTextBox";
            this.senderNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.senderNameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // smtpLabel
            // 
            this.smtpLabel.AutoSize = true;
            this.smtpLabel.Location = new System.Drawing.Point(32, 171);
            this.smtpLabel.Name = "smtpLabel";
            this.smtpLabel.Size = new System.Drawing.Size(131, 13);
            this.smtpLabel.TabIndex = 5;
            this.smtpLabel.Text = "SMTP Server (Mail server)";
            // 
            // smtpBox
            // 
            this.smtpBox.Location = new System.Drawing.Point(44, 187);
            this.smtpBox.Name = "smtpBox";
            this.smtpBox.Size = new System.Drawing.Size(100, 20);
            this.smtpBox.TabIndex = 6;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(6, 144);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(53, 13);
            this.passLabel.TabIndex = 3;
            this.passLabel.Text = "Password";
            // 
            // connectionPassBox
            // 
            this.connectionPassBox.Location = new System.Drawing.Point(80, 141);
            this.connectionPassBox.Name = "connectionPassBox";
            this.connectionPassBox.PasswordChar = '•';
            this.connectionPassBox.Size = new System.Drawing.Size(100, 20);
            this.connectionPassBox.TabIndex = 5;
            // 
            // sendingEmailLabel
            // 
            this.sendingEmailLabel.AutoSize = true;
            this.sendingEmailLabel.Location = new System.Drawing.Point(6, 63);
            this.sendingEmailLabel.Name = "sendingEmailLabel";
            this.sendingEmailLabel.Size = new System.Drawing.Size(74, 13);
            this.sendingEmailLabel.TabIndex = 1;
            this.sendingEmailLabel.Text = "Sending Email";
            // 
            // senderTextBox
            // 
            this.senderTextBox.Location = new System.Drawing.Point(80, 63);
            this.senderTextBox.Name = "senderTextBox";
            this.senderTextBox.Size = new System.Drawing.Size(100, 20);
            this.senderTextBox.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(402, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShowShortcutKeys = false;
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "econf";
            this.openFileDialog1.Filter = "Email Configuration|*.econf";
            this.openFileDialog1.Tag = ".conf";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "econf";
            this.saveFileDialog1.FileName = "default.econf";
            this.saveFileDialog1.Filter = "Email Configuration|*.econf";
            this.saveFileDialog1.Tag = "";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // startPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 405);
            this.Controls.Add(this.connectionSettings);
            this.Controls.Add(this.contactGroup);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.configPassBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(418, 444);
            this.MinimumSize = new System.Drawing.Size(418, 444);
            this.Name = "startPage";
            this.Text = "Email Configuration Tool";
            this.EnabledChanged += new System.EventHandler(this.startPage_EnabledChanged);
            this.contactGroup.ResumeLayout(false);
            this.connectionSettings.ResumeLayout(false);
            this.connectionSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox emailListBox;
        private System.Windows.Forms.TextBox configPassBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.GroupBox contactGroup;
        private System.Windows.Forms.Button newContactButton;
        private System.Windows.Forms.Button removeContactButton;
        private System.Windows.Forms.Button editContactButton;
        private System.Windows.Forms.GroupBox connectionSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label smtpLabel;
        private System.Windows.Forms.TextBox smtpBox;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.TextBox connectionPassBox;
        private System.Windows.Forms.Label sendingEmailLabel;
        private System.Windows.Forms.TextBox senderTextBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Label senderNameLabel;
        private System.Windows.Forms.TextBox senderNameTextBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accountEmailBox;
    }
}

