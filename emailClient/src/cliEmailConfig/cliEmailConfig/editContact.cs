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
    public partial class editContact : Form
    {
        bool newContact = false;
        public editContact()
        {
            InitializeComponent();
            Application.OpenForms[0].Enabled = false;
            if (Program.selectedContact == Program.contacts.Count)
            {
                newContact = true;
            }
            else
            {
                nameTextBox.Text = Program.contacts[Program.selectedContact][0];
                mailTextBox.Text = Program.contacts[Program.selectedContact][1];
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (newContact)
                Program.contacts.Add(new string[] { nameTextBox.Text,mailTextBox.Text });
            else
                Program.contacts[Program.selectedContact] = new string[] { nameTextBox.Text, mailTextBox.Text };
            Close();
        }

        private void editContact_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Enabled = true;
        }

        private void mailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (mailTextBox.Text != "" && e.KeyCode == Keys.Enter)
                doneButton_Click(new object(), new EventArgs());
        }
    }
}
