using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace cliEmailConfig
{
    static class Program
    {
        //This is a double layer to make sure only this, and the email client can open the config.
        private static string uuid = key.getKey();
        //Depending on the process, this may contain either an opened config, or a config being saved.
        public static string configFile = "";
        public static List<string[]> contacts = new List<string[]>();
        public static int selectedContact = 0;
        public static string password = "";
        public static bool changedPassword = false;
        public static string currPath = ""; //The location of the file currently being edited.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new startPage());
        }
        //Pick through all of the data:
        public static bool load(string path)
        {
            try
            {
                StreamReader newFile = File.OpenText(path);
                string temp = newFile.ReadToEnd();
                string[] config = mailEncrypt(false,uuid,temp).Split('\n');
                //MessageBox.Show(mailEncrypt(false, uuid, temp));
                newFile.Close();
                //Skip over the first line, which contains the uuid:
                int i;
                configFile = "";
                for (i = 1; i < config.Length; i++)
                {
                    configFile+=config[i]+(i == config.Length-1?"":"\n");
                }
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public static bool save(string path,string passUuid)
        {
            try
            {
                StreamWriter config = new StreamWriter(path);
                //MessageBox.Show(passUuid + "\n" + configFile);
                config.Write(mailEncrypt(true,uuid,passUuid+"\n"+configFile));
                config.Close();
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public static string mailEncrypt(bool enDecrypt, string uuid,string input)
        {
            if (enDecrypt)
            {
                input = Encrypt.fluctuate(true, uuid, input,true);
                input = Encrypt.scrambler(true, uuid, input);
                input = Encrypt.fluctuate(true, Encrypt.reverse(uuid), input);
                input = Encrypt.reverse(input);
            }
            else
            {
                input = Encrypt.reverse(input);
                input = Encrypt.fluctuate(false, Encrypt.reverse(uuid), input);
                input = Encrypt.scrambler(false, uuid, input);
                input = Encrypt.fluctuate(false, uuid, input);
            }
            return input;
        }

        //Simply converts contacts to a signle dimension array with the information of the dev's choice.
        public static string[] contact2SingleDim(bool grabNames = true)
        {
            int index = (grabNames ? 0 : 1); //If it's set to false, grab emails instead...

            List<string> result = new List<string>();

            for(int i = 0; i < contacts.Count; i++)
            {
                result.Add(contacts[i][index]);
            }
            return result.ToArray();
        }
    }
}
