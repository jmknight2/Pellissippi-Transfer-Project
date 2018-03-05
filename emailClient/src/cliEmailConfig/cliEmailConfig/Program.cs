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
        public static List<string> configFile = new List<string>();
        public static List<string[]> contacts = new List<string[]>();
        public static int selectedContact = 0;
        public static string password = "";
        public static bool changedPassword = false;
        public static string currPath = ""; //The location of the file currently being edited.
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
                StreamReader config = File.OpenText(path);
                //Skip over the first line, which contains the uuid:
                config.ReadLine();
                string temp = ""; //This is where this program decrypts the first half.
                while (!config.EndOfStream)
                {
                    temp = mailEncrypt(false,uuid, config.ReadLine());
                    configFile.Add(temp);
                }
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
        }

        public static bool save(string path)
        {
            try
            {
                StreamWriter config = new StreamWriter(path);
                for (int i=0;i< configFile.Count;i++)
                {
                    config.WriteLine(mailEncrypt(true,uuid,configFile[i]));
                }
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
                input = Encrypt.fluctuate(true, uuid, input);
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
