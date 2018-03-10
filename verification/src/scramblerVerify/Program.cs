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
            bool removeWord = false;
            bool replaceWord = false;
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
                        try {
                            saveLocation = args[i + 1];
                            useFile = true;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Error: No option given for the source file! Proceeding without an external file...");
                        }
                        break;
                    case "-r":
                        removeWord = true;
                        break;
                    case "-p":
                        replaceWord = true;
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
            if (removeWord)
            {
                //Guessing this should be removed as well:
                wordList.Add(compare);
                remove(saveLocation,test,wordList.ToArray());
            }
            else if (replaceWord)
            {
                string[] fileList = load(saveLocation);
                //We only compare two different words: with the second word being the exhisting word we wish to replace with the first.
                string[] newList = replace(wordList[0], compare, fileList, test);
                if (newList == null)
                {
                    Console.WriteLine("notfound");
                }
                else save(saveLocation, test, newList, false,false);
            }
            else if (encrypt)
            {
                wordList.Add(compare);

                if (useFile)
                {
                    save(saveLocation, test, wordList.ToArray(),true);
                }
                else
                {
                    foreach(string word in wordList)
                    {
                        Console.WriteLine(enDecrypt(true,test,word,false));
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

        public static string enDecrypt(bool encrypt, string input, string uuidGen, bool useEnter = true)
        {
            string uuid = Uuid.generate(new Random(Uuid.txt2PsudoRandom(uuidGen)),true);
            string result = input;
            if (encrypt)
            {
                result = Encrypt.scrambler(true, uuid, result);
                result = Encrypt.fluctuate(true, uuid, result, useEnter);
                result = Encrypt.reverse(result);
            }
            else
            {
                result = Encrypt.reverse(result);
                result = Encrypt.fluctuate(false, uuid, result, useEnter);
                result = Encrypt.scrambler(false, uuid, result);
            }
            return result;
        }

        public static void save(string location, string input, string[] uuidGen, bool keepEverything, bool encryptEachline = true)
        {
            int i;
            List<string> everything = new List<string>();
            if (keepEverything)
                everything.AddRange(load(location));
            //Console.WriteLine(""+everything.Count());
            StreamWriter saveLocation = new StreamWriter(location);

            //Insert all input:
            for (i = 0; i < uuidGen.Length; i++)
            {
                everything.Add(encryptEachline? enDecrypt(true, input,uuidGen[i],false) : uuidGen[i] );
            }
            //Gather it all together, and encrypt it once more for good measure:
            string output = "";
            for (i = 0; i < everything.Count(); i++)
            {
                output += everything[i] + (i == everything.Count() - 1 ? "" : "\n");
            }
            saveLocation.Write(enDecrypt(true, output, Uuid.generate(new Random(Uuid.txt2PsudoRandom(test)), true)));
            saveLocation.Close();
        }

        public static void remove(string location,string input,string[] uuidGen)
        {
            string[] everything = load(location);

            List<string> newList = new List<string>();
            //remake the list with the requested strings ommited:
            int j = 0;
            for (int i = 0; i < everything.Length; i++)
            {
                bool copy = false;
                for(j = 0; j < uuidGen.Length; j++)
                {
                    //Console.WriteLine(uuidGen[j]+":"+enDecrypt(true, input, uuidGen[j])+" | save entry:"+everything[i]);
                    if(enDecrypt(true,input,uuidGen[j]) == everything[i])
                    {
                        copy = true;
                        break;
                    }
                }
                if (!copy)
                {
                    newList.Add(everything[i]);
                }
            }
            //After sifting through all options, re-save:
            save(location, input, newList.ToArray(),false);
        }

        public static string[] load(string location)
        {
            string result = "";
            try
            {
                StreamReader reader = File.OpenText(location);
                result = enDecrypt(false,reader.ReadToEnd(),Uuid.generate(new Random(Uuid.txt2PsudoRandom(test)),true));
                reader.Close();
                //Console.WriteLine(result);
            }
            catch (FileNotFoundException ex)
            {
                return new string[] { };
            }
            return result.Split('\n');
        }

        public static bool search(string needle, string[] haystack,string uuidGen)
        {
            //Console.WriteLine("serch term: " + enDecrypt(true, needle, uuidGen, false)+"\n");
            foreach (string element in haystack)
            {
                //Console.WriteLine(element);
                if (enDecrypt(true, needle, uuidGen,false) == element)
                    return true;
            }
            return false;
        }
        public static string[] replace(string replaceString, string searchWord,string[] wordList, string baseWord)
        {
            for(int i = 0; i < wordList.Length; i++)
            {
                if(enDecrypt(true,baseWord,searchWord,false) == wordList[i])
                {
                    //Console.WriteLine("before:" + wordList[i]);
                    wordList[i] = enDecrypt(true, baseWord,replaceString,false);
                    //Console.WriteLine("after:" + wordList[i]);
                    return wordList;
                }
            }
            return null;
        }
    }
}
