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
    public partial class startPage : Form
    {
        public startPage()
        {
            InitializeComponent();
            if (Program.contacts.Count > 0)
            {
                emailListBox.Items.AddRange(Program.contact2SingleDim());
                emailListBox.SelectedIndex = 0;
                editContactButton.Enabled = true;
                removeContactButton.Enabled = true;
                newContactButton.Enabled = true;
            }
        }

        bool everythingEnabled = false;
        private void enableDisableEverything()
        {
            changePasswordButton.Enabled = !changePasswordButton.Enabled;
            connectionSettings.Enabled = !connectionSettings.Enabled;
            contactGroup.Enabled = !contactGroup.Enabled;
            saveAsToolStripMenuItem.Enabled = !saveAsToolStripMenuItem.Enabled;
            saveToolStripMenuItem.Enabled = !saveToolStripMenuItem.Enabled;
            everythingEnabled = !everythingEnabled;
        }

        //This is the initial setup for saving the file; after this is finished, it calls "program.save()"
        private void saveSetup(string path)
        {
            //The uuid that decodes the file when run by the actual client (This program ignores it):
            string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(Program.password)), true);
            Program.configFile.Clear();

            Program.configFile.Add(uuid);
            Program.configFile.Add(Program.mailEncrypt(true, uuid, "testing123"));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, senderNameTextBox.Text));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, senderTextBox.Text));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, accountEmailBox.Text));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, connectionPassBox.Text));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, smtpBox.Text));
            Program.configFile.Add(Program.mailEncrypt(true, uuid, portBox.Text));

            //Encrypting emails:
            foreach (string[] currContact in Program.contacts)
            {
                Program.configFile.Add(Program.mailEncrypt(true, uuid, currContact[0]+","+currContact[1]));
            }
            if (!Program.save(path))
            {
                MessageBox.Show("There was an error attempting to save this file... please try again with a different path and/or name","Save error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && configPassBox.Text != "")
            {
                string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(configPassBox.Text)),true);
                string test = Program.mailEncrypt(false,uuid,Program.configFile[0]);
                if (test == "testing123" )
                {
                    //Proceed to decrypting the rest of the information:
                    senderNameTextBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[1]);
                    senderTextBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[2]);
                    accountEmailBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[3]);
                    connectionPassBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[4]);
                    smtpBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[5]);
                    portBox.Text = Program.mailEncrypt(false, uuid, Program.configFile[6]);
                    //Grab all contacts:
                    emailListBox.Items.Clear();
                    for (int i = 7; i < Program.configFile.Count; i++)
                    {
                        string[] temp = Program.mailEncrypt(false, uuid, Program.configFile[i]).Split(',');
                        Program.contacts.Add(temp);
                        emailListBox.Items.Add(Program.contacts[Program.contacts.Count - 1][0]);
                    }
                    Program.password = configPassBox.Text;
                    enableDisableEverything();
                    configPassBox.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Incorrect Password.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            new changePassword().Show();
        }

        private void emailListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.contacts.Count > 0)
            {
                editContactButton.Enabled = true;
                removeContactButton.Enabled = true;
            }
            else
            {
                editContactButton.Enabled = false;
                removeContactButton.Enabled = false;
            }
        }

        private void editContactButton_Click(object sender, EventArgs e)
        {
            new editContact().Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.changedPassword = false;
            new changePassword().Show();
        }

        private void startPage_EnabledChanged(object sender, EventArgs e)
        {
            //Creating a new configuration
            if (Program.changedPassword && !everythingEnabled)
            {
                enableDisableEverything();
                emailListBox_SelectedIndexChanged(new object(), new EventArgs());
            }

            if (Program.changedPassword)
                configPassBox.Text = Program.password;

            //Editing/creating an new contact.
            if (everythingEnabled)
            {
                string[] temp = Program.contact2SingleDim();
                string[] contacts = emailListBox.Items.Cast<string>().ToArray<string>();
                if (contacts != temp)
                {
                    //MessageBox.Show(contacts[0]);
                    emailListBox.Items.Clear();
                    emailListBox.Items.AddRange(temp);
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            configPassBox.Enabled = true;
            Program.currPath = openFileDialog1.FileName;
            Program.load(Program.currPath);
            if(everythingEnabled)
                enableDisableEverything();
        }

        private void newContactButton_Click(object sender, EventArgs e)
        {
            Program.selectedContact = Program.contacts.Count();
            new editContact().Show();
        }

        private void removeContactButton_Click(object sender, EventArgs e)
        {
            Program.contacts.Remove(Program.contacts[emailListBox.SelectedIndex]);
            emailListBox.Items.Clear();
            emailListBox.Items.AddRange(Program.contact2SingleDim());
            emailListBox_SelectedIndexChanged(new object(), new EventArgs());
            emailListBox.SelectedIndex = emailListBox.Items.Count - 1;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.currPath == "")
            {
                saveFileDialog1.ShowDialog();
            }
            else saveSetup(Program.currPath);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Program.currPath = saveFileDialog1.FileName;
            saveSetup(Program.currPath);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }
    }
}