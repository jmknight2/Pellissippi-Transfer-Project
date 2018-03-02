//Made by Zachary Mitchell in 2018!
//This is the core class for scrambling and unscrambling plain text. It requires a uuid without hyphens to work.

//It comes brocken down into different scrambling methods so one can place them in the order they choose.
//Ultimately, this provides the most optimal method of scrambling, since you can choose the methods you want.
using System;
static class Encrypt
{
	public static string fluctuate(bool enDecrypt, string uuid, string text)
    {
        string result="";
        string checkpoint = text; //This is here so text doesn't get replaced
        int curr = 0; //This keeps track of longestStrings's current location.

        string longestString = (uuid.Length > text.Length ? uuid : text);

        int i = 0;
        bool addSubtract = true;

        //These values will swap depnending on longestString.
        int checkNum, uuidNum;

        for (i = 0; i < longestString.Length; i++)
        {
            //Reset !longestString if it hits the max:
            if((longestString == uuid && result.Length == text.Length) || longestString == text && curr == uuid.Length - 1)
            {
                curr = 0;
                if ((longestString == uuid && result.Length == text.Length))
                {
                    checkpoint = result;
                    result = "";
                }
            }
            //Annoyingly, these have to be reset every time due to both i and curr being incremental...
            //These are here instead of being defined on the fly, due to needing more advanced control...
            if (longestString == uuid)
            {
                uuidNum = i;
                checkNum = curr;
            }
            else
            {
                uuidNum = curr;
                checkNum = i;
            }
            addSubtract = (i % 2 == 0 ? true : false);
            if (!enDecrypt)
                addSubtract = !addSubtract;

            result += charCalc((checkpoint[checkNum]), uuid[uuidNum], addSubtract );
            //Console.WriteLine(text[result.Length-1] + ":" + result[result.Length-1] + "(["+((addSubtract?"+" : "-")) +"]"+(int)result[result.Length-1]+") uuid:"+uuid[uuidNum]);

            curr++;
        }

        if(result.Length < checkpoint.Length)
        {
            //Console.WriteLine("result(scrambler):\"" + result + "\"\ncheckpoint:\"" + checkpoint+"\"");

            //grab checkpoint.length's characters that we don't have.
            for(i = result.Length;i< checkpoint.Length; i++)
            {
                result += (char)checkpoint[i];
            }
        }

        return result;
    }


    //Scrambler: this shuffles the whole string into a big mess. works best with fluctuate() on it's side
    public static string scrambler(bool enDecrypt, string uuid, string text)
    {
        string result="";

        string longestString = (uuid.Length > text.Length ? uuid : text);
        string shortestString = (longestString == uuid ? text : uuid);

        //Let's figure out where the beginning point of decryption will be (that is, if it's requested)
        int beginPoint = 0;
        if (!enDecrypt)
        {
            //Console.WriteLine("beginPoint:");
            for(int i = 0; i < longestString.Length; i++)
            {
                //Console.WriteLine(beginPoint);
                if (beginPoint == shortestString.Length - 1)
                    beginPoint = 0;
                else beginPoint++;
            }
            beginPoint--;
        }
        int curr = beginPoint;
        int swapPoint;

        int uuidPos = 0;
        int textPos = 0;
        //We have to split the string before we return it (and reconstruct it)
        char[] textEdit = text.ToCharArray();
        //Indeed, this for loop is funky XD It was designed cuz I didn't want to make two separate loops.
        for(int i = (enDecrypt?0:longestString.Length-1); i!= (enDecrypt?longestString.Length:-1); i=(enDecrypt?i+1:i-1) )
        {
            if (curr == (enDecrypt ? shortestString.Length : -1))
            {
                curr = (enDecrypt ? 0 : shortestString.Length - 1);
                /*if (enDecrypt)
                    zeroFlag = true;*/
            }
            //if (enDecrypt)
                //Console.WriteLine("curr: " + curr + " |i: " + i);

            //Console.WriteLine(longestString == uuid);
            uuidPos = (longestString == uuid ? i : curr);
            textPos = (longestString == text ? i : curr);
            swapPoint = new Random(hex2Int(uuid[uuidPos])).Next() % (textEdit.Length-1);
           //Console.WriteLine("swapPoint: " + swapPoint);


            //Accomodating for this weird for loop that was just made (XP):
            int pointA = (enDecrypt ? textPos : swapPoint);
            int pointB = (enDecrypt ? swapPoint : textPos);

            char temp = textEdit[pointA];
            textEdit[pointA] = textEdit[pointB];
            textEdit[pointB] = temp;

            curr =(enDecrypt?curr+1:curr-1);
        }

        //yaaaay! Everything's been encrypted/decrypted, so let's reassemble it:
        for(int i = 0; i < textEdit.Length; i++)
        {
            result += textEdit[i];
        }


        return result;
    }

    //This should be very straightforward, and therefore, have short syntax ^_^
    public static string reverse(string text)
    {
        string result = "";
        for(int i = text.Length - 1; i > -1; i--)
        {
            result += text[i];
        }
        return result;
    }

    //Private methods:

    //This is designed to keep text within the boundries that windows can handle, as well as keeping usable characters within the english language.
    //It is a far cry of the original, primitive method, which just did math on a specific set of characters.
    private static string charCalc(char main, char hex, bool addSub)
    {
        //Console.WriteLine("==charCalc()==");
        //hex won't be directly added; instead, we want it's hex value to be added to main.
        int addNumber = hex2Int(hex);
        addNumber = (addSub ? addNumber : 0 - addNumber);
        char result=main;

        int curr = -1;
        char[][] charList =
        {
            //new char[] {'\t','\t'},
            new char[]{' ','~'},
            new char[]{'¡','£'},
            new char[]{ '¿', '¿' },
            new char[]{ '÷', '÷' }
        };

        int i = 0;
        //Let's discover the current location of main:
            for (i = 0; i < charList.Length; i++)
            {
                if (main >= charList[i][0] && main <= charList[i][1])
                {
                    curr = i;
                    break;
                }
            }
            //I'm not really able to mathmatically convert this character in any way, shape or form (as of this build), so it's forced to be a question mark...
            if (curr == -1)
            {
                result = '?';
                curr = 0;
            }
        //Console.WriteLine("curr:" + curr + " | addSub: "+addSub + " | value: "+(int)addNumber + " | Char-to-edit: "+main);
        if (addSub)
        {
            for (i = 0; i < addNumber; i++)
            {
                result++;
                if (result > charList[curr][1])
                {
                    curr = (curr == charList.Length -1? 0 : curr + 1);
                    result = charList[curr][0];
                }
                //Console.WriteLine("result: " + result + "(" + (int)result + ")");
            }
            //We will run the same check one last time before we let it go:
            if (result > charList[curr][1])
            {
                curr = (curr == charList.Length -1? 0 : curr + 1);
                result = charList[curr][0];
            }
        }
        else
        {
            for (i = 0; i > addNumber; i--)
            {
                result--;
                if (result < charList[curr][0])
                {
                    curr = (curr == 0? charList.Length-1 : curr - 1);
                    result = charList[curr][1];
                }
                //Console.WriteLine("result: " + result + "(" + (int)result + ")");
            }
            //Same thing as above:
            if (result < charList[curr][0])
            {
                curr = (curr == 0 ? charList.Length -1: curr - 1);
                result = charList[curr][1];
            }
        }
        return "" + result;
    }

    //Just so I don't have to type this everytime ;P
    private static int hex2Int(char leChar)
    {
        return (leChar > 57 ? leChar - 87 : leChar - 48);
    }
}
