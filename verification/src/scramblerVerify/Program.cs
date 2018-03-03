using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/// <summary>
/// Author: Zachary Mitchell
/// This is designed as a simple program that does an encryption check. Basically: if the input from argument 1 unlocks argument 2, then return true.
/// The program can also check from a file to check a list of encrypted strings; if one gets decrypted, then return true.
/// 
/// To actually encrypt items, run the -e flag; this will output a string that can only be unlocked through the input. It can also be saved to a file using -f ["filename"]
/// </summary>
namespace scramblerVerify
{
    class Program
    {
        //The actual thing that get's scrambled. The program NEVER stores passwords ;)
        static string test = "theQuickBrownFoxJumpsOverTheLazyDog";
        static void Main(string[] args)
        {
            bool encrypt = false;
            bool useFile = false;
            string saveLocation = "";

            bool gotFirstWord = false;
            List<string> wordList = new List<string>();
            string compare = "";

            //Grabbing the flags and arguments
            for(int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-e":
                        encrypt = true;
                        break;
                    case "-f":
                        useFile = true;
                        saveLocation = args[i + 1];
                        break;
                    default:
                        if (args[i] != saveLocation)
                        {
                            if (!gotFirstWord)
                            {
                                compare = args[i];
                                gotFirstWord = true;
                            }
                            else wordList.Add(args[i]);
                        }
                        break;
                }
            }
            if (encrypt)
            {
                wordList.Add(compare);

                if (useFile)
                {
                    save(saveLocation, test, wordList.ToArray());
                }
                else
                {
                    foreach(string word in wordList)
                    {
                        Console.WriteLine(enDecrypt(true,test,word));
                    }
                }
            }
            else
            {
                if (useFile)
                    wordList.AddRange(load(saveLocation));
                if (search(test, wordList.ToArray(),compare))
                {
                    Console.WriteLine(true);
                }
                else Console.WriteLine(false);
            }

        }

        public static string enDecrypt(bool encrypt, string input,string uuidGen)
        {
            string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(uuidGen)),true);
            string result = input;
            if (encrypt)
            {
                result = Encrypt.scrambler(true, uuid, result);
                result = Encrypt.fluctuate(true, uuid, result);
                result = Encrypt.reverse(result);
            }
            else
            {
                result = Encrypt.reverse(result);
                result = Encrypt.fluctuate(false, uuid, result);
                result = Encrypt.scrambler(false, uuid, result);
            }
            return result;
        }

        public static void save(string location,string input,string[] uuidGen)
        {
            string[] everything = load(location);
            int i;
            StreamWriter saveLocation = new StreamWriter(location);
            for(i = 0; i < everything.Length; i++)
            {
                saveLocation.WriteLine(everything[i]);
            }

            //Insert all input:
            for (i = 0; i < uuidGen.Length; i++)
            {
                saveLocation.WriteLine(enDecrypt(true, input,uuidGen[i]));
            }
            saveLocation.Close();
        }

        public static string[] load(string location)
        {
            List<string> result = new List<string>();
            try
            {
                StreamReader reader = File.OpenText(location);
                while (!reader.EndOfStream)
                {
                    result.Add(reader.ReadLine());
                }
                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
            }
            return result.ToArray();
        }

        public static bool search(string needle, string[] haystack,string uuidGen)
        {
            foreach(string element in haystack)
            {
                if (enDecrypt(false,element,uuidGen) == needle)
                    return true;
            }
            return false;
        }
    }
}
