using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cliEmailConfig
{
    public partial class changePassword : Form
    {
        bool placedInPass = false;
        public changePassword()
        {
            InitializeComponent();
            Application.OpenForms[0].Enabled = false;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            Program.password = newPass.Text;
            Program.changedPassword = true;
            Application.OpenForms[0].Enabled = true;
            Close();
        }

        private void textChanged()
        {
            if (confirmPass.Text == "")
            {
                passMatch.Visible = false;
                doneButton.Enabled = false;
            }
            else if (confirmPass.Text != newPass.Text)
            {
                if(placedInPass)
                    passMatch.Visible = true;
                doneButton.Enabled = false;
            }
            else
            {
                passMatch.Visible = false;
                doneButton.Enabled = true;
            }
        }

        private void confirmPass_TextChanged(object sender, EventArgs e)
        {
            textChanged();
        }

        private void confirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if(doneButton.Enabled && e.KeyCode == Keys.Enter)
            {
                doneButton_Click(new object() ,new EventArgs());
            }
        }

        private void changePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
        }

        private void confirmPass_Enter(object sender, EventArgs e)
        {
                placedInPass = (newPass.Text!=""?true:false);
        }

        private void newPass_TextChanged(object sender, EventArgs e)
        {
            textChanged();
        }
    }
}
