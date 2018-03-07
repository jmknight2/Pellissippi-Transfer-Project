namespace cliEmailConfig
{
    partial class editContact
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(129, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(214, 26);
            this.nameTextBox.TabIndex = 0;
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(129, 72);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(214, 26);
            this.mailTextBox.TabIndex = 1;
            this.mailTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mailTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(51, 78);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(48, 20);
            this.emailLabel.TabIndex = 3;
            this.emailLabel.Text = "Email";
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(193, 111);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 29);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // editContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 152);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Name = "editContact";
            this.Text = "Edit Contact";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.editContact_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Button doneButton;
    }
}