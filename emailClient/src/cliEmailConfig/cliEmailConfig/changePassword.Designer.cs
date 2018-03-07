namespace cliEmailConfig
{
    partial class changePassword
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
            this.doneButton = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newPass = new System.Windows.Forms.TextBox();
            this.confirmPass = new System.Windows.Forms.TextBox();
            this.passMatch = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doneButton
            // 
            this.doneButton.Enabled = false;
            this.doneButton.Location = new System.Drawing.Point(113, 118);
            this.doneButton.Margin = new System.Windows.Forms.Padding(2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(60, 21);
            this.doneButton.TabIndex = 0;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(31, 76);
            this.passLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(78, 13);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "New Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "This password helps you access the\ncurrent email configuration.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Confirm Password";
            // 
            // newPass
            // 
            this.newPass.Location = new System.Drawing.Point(113, 73);
            this.newPass.Margin = new System.Windows.Forms.Padding(2);
            this.newPass.Name = "newPass";
            this.newPass.PasswordChar = '•';
            this.newPass.Size = new System.Drawing.Size(114, 20);
            this.newPass.TabIndex = 4;
            this.newPass.TextChanged += new System.EventHandler(this.newPass_TextChanged);
            // 
            // confirmPass
            // 
            this.confirmPass.Location = new System.Drawing.Point(113, 94);
            this.confirmPass.Margin = new System.Windows.Forms.Padding(2);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.PasswordChar = '•';
            this.confirmPass.Size = new System.Drawing.Size(114, 20);
            this.confirmPass.TabIndex = 5;
            this.confirmPass.TextChanged += new System.EventHandler(this.confirmPass_TextChanged);
            this.confirmPass.Enter += new System.EventHandler(this.confirmPass_Enter);
            this.confirmPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.confirmPass_KeyDown);
            // 
            // passMatch
            // 
            this.passMatch.AutoSize = true;
            this.passMatch.ForeColor = System.Drawing.Color.Firebrick;
            this.passMatch.Location = new System.Drawing.Point(75, 47);
            this.passMatch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passMatch.Name = "passMatch";
            this.passMatch.Size = new System.Drawing.Size(118, 13);
            this.passMatch.TabIndex = 6;
            this.passMatch.Text = "Passwords must match!";
            this.passMatch.Visible = false;
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 146);
            this.Controls.Add(this.passMatch);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.newPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passLabel);
            this.Controls.Add(this.doneButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "changePassword";
            this.Text = "Change Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.changePassword_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newPass;
        private System.Windows.Forms.TextBox confirmPass;
        private System.Windows.Forms.Label passMatch;
    }
}