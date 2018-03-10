using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/// <summary>
/// Credits:
/// SMPT client created by: Microsoft
/// Encryption: Zachary Mitchell
/// File Author: Zachary Mitchell
/// 
/// This makes use of the SMTP class to s emails to the desired client, and from the receiver.
/// </summary>
namespace cliEmail
{
    class Program
    {
        public static string confDir = "";
        public static string htmlDir = "";
        private static string uuid = key.getKey();
        public static List<string> filesDir = new List<string>();

        public static string[] argList =
        {
            "-config",
            "-html",
            "-files"
        };

        private static bool searchArgs(string input)
        {
            for(int i = 0; i < argList.Length; i++)
            {
                if (input == argList[i])
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            //grab arguments:
            for (int i= 0;i<args.Length;i++)
            {
                switch (args[i])
                {
                    case "-config":
                        confDir = args[i + 1];
                    break;
                    case "-html":
                        htmlDir = args[i + 1];
                    break;
                    case "-files":
                        //grab all the files until we reach another argument:
                        int searchIndex = i+1;
                        while (searchIndex < args.Length && !searchArgs(args[searchIndex]))
                        {
                            //Console.WriteLine("program.cs:"+args[searchIndex]);
                            filesDir.Add(args[searchIndex]);
                            searchIndex++;
                        }
                    break;
                }
            }
            if (confDir == "")
                confDir = "./default.econf";
            if (htmlDir == "")
                htmlDir = "./default.html";
            try
            {
                emailConfiguration eConfig = new emailConfiguration(load(confDir)); //Everything gets converted into a readable format for Microsoft's client

                //Alright, now we need the html file used for the message:
                StreamReader htmlIn = File.OpenText(htmlDir);
                message htmlMessage = new message(htmlIn.ReadLine(), htmlIn.ReadToEnd());
                //SEND THE THING!!!1!
                email.sendMail(ref eConfig, ref htmlMessage, filesDir.ToArray());
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("I couldn't find "+ confDir+" :/");
            }
        }

        //The loooong process of decrypting everything:
        private static List<string> load(string path)
        {
            List<string> conf = new List<string>();
            StreamReader confIn = File.OpenText(path);
            string confStr = confIn.ReadToEnd();
            confIn.Close();
            //Decrypt the string based off of key.cs:
            conf.AddRange(mailEncrypt(uuid,confStr).Split('\n'));

            confStr = "";
            //Decrypt the string based off of user-password: (we sortof have to put the string back together :P)
            for(int i = 1; i < conf.Count(); i++)
            {
                confStr += conf[i] + (i == conf.Count() - 1 ?"":"\n");
            }
            string pass = conf[0];
            conf.Clear();
            //now we split the string AGAIN! (oi, that must be painful) >_<
            conf.AddRange(mailEncrypt(pass,confStr).Split('\n'));
            return conf;
        }

        public static string mailEncrypt(string uuid, string input)
        {
                input = Encrypt.reverse(input);
                input = Encrypt.fluctuate(false, Encrypt.reverse(uuid), input);
                input = Encrypt.scrambler(false, uuid, input);
                input = Encrypt.fluctuate(false, uuid, input);
            return input;
        }
    }
}
