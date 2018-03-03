//This Is the core uuid generation file. To use it, insert a random object as the argument.
//This is separate from the cli because of how many possible ways you could achive randomness, therefore, getting this randomness is up to the dev.
//using System;
static class Uuid
{

    public static int txt2PsudoRandom(string input)
    {
        double sum = 0;

        byte[] order = { 0, 1, 2, 3 }; //this allows shuffling the order mathematic calculations for further obscurity.

        int i;
        for (i = 0; i < input.Length; i++)
        {
            //This is to prevent somebody from typing the same characters in a different order to get the same uuid.
            //EDIT: this got complicated fast, and all it is is random math XP

            //shift the order of math by 1:
            byte temp = order[order.Length - 1];
            for (int j = order.Length - 1; j > 0; j--)
            {
                if (j == 0)
                    order[j] = temp;
                else order[j] = order[j - 1];
            }

            //A list of math: (This is refreshed every increment)
            double[] math = {
                        input[i],
                        0-input[i],
                        input[i]*input[i],
                        input[i] / input[ (i == 0 ? (i == input.Length - 1 ? i : i + 1) : i - 1) ]  //This mess determines if we are at the end of the string, or the beginning so we can select a number.
                    };

            sum += (i % 4 == 0 ? math[order[0]] : i % 3 == 0 ? math[order[1]] : i % 2 == 0 ? math[order[2]] : math[order[3]]);
        }

        return (int)sum;
    }

    public static string generate(System.Random rnd,bool dontUseHyphen)
    {
        string output="";

        int currNum = 0;

        for (int i = 0; i < 32; i++)
        {
            currNum = rnd.Next() % 16;
            output += (currNum > 9 ? (char)( (currNum - 10) + 97):(char)(currNum+48) )+"";
            //Console.WriteLine(output);
            //Console.ReadKey();
        }

        if (!dontUseHyphen)
        {
            string tempOutput = "";

            byte[] points = { 7,11,15,19 };
            byte curr = 0;

            for(int i = 0; i < 32; i++)
            {
                if ((curr + 1) != points.Length && i == points[curr])
                {
                    tempOutput += "-";
                    curr++;
                }
                tempOutput += output[i];
            }

            output = tempOutput;
        }

        return output;
    }
}