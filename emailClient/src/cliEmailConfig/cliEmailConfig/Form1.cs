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

        private void resetVals()
        {
            configPassBox.Text = "";
            connectionPassBox.Text = "";
            senderNameTextBox.Text = "";
            senderTextBox.Text = "";
            accountEmailBox.Text="";
            smtpBox.Text = "";
            portBox.Text = "";
            Program.contacts.Clear();
            emailListBox.Items.Clear();
        }

        //This is the initial setup for saving the file; after this is finished, it calls "program.save()"
        private void saveSetup(string path)
        {
            //The uuid that decodes the file when run by the actual client (This program ignores it):
            string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(Program.password)), true);
            string everything = "testing123\n"+senderNameTextBox.Text+'\n'+senderTextBox.Text+'\n'+accountEmailBox.Text+'\n'+connectionPassBox.Text+'\n'+smtpBox.Text+'\n'+portBox.Text+'\n';
            
            //Encrypting emails:
            for(int i=0;i<Program.contacts.Count();i++)
            {
                everything+=Program.contacts[i][0]+','+Program.contacts[i][1]+(i == Program.contacts.Count()-1?"":"\n");
            }
            //Encrypting everything and saving to configFile:
            Program.configFile=Program.mailEncrypt(true,uuid,everything);
            if (!Program.save(path,uuid))
            {
                MessageBox.Show("There was an error attempting to save this file... please try again with a different path and/or name","Save error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && configPassBox.Text != "")
            {
                string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(configPassBox.Text)),true);
                string[] everything = Program.mailEncrypt(false,uuid,Program.configFile).Split('\n');

                if (everything[0] == "testing123" )
                {
                    //Proceed to decrypting the rest of the information:
                    senderNameTextBox.Text  = everything[1];
                    senderTextBox.Text = everything[2];
                    accountEmailBox.Text = everything[3];
                    connectionPassBox.Text = everything[4];
                    smtpBox.Text = everything[5];
                    portBox.Text = everything[6];
                    //Grab all contacts:
                    emailListBox.Items.Clear();
                    for (int i = 7; i < everything.Length; i++)
                    {
                        string[] temp = everything[i].Split(',');
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
            Program.selectedContact = emailListBox.SelectedIndex;
            new editContact().Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.changedPassword = false;
            new changePassword().Show();
            resetVals();
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
            resetVals();
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