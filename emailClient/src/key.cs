using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This is a custom file that requires the dev to insert their own key to make the program function.
//A key in this case is defined as a string of hexidecimal characters (It can be a uuid without any hyphens). The longer the key, the more secure the program is.
//Be cautious of how this file is secured. If the source code was stolen, somebody could access your sensitive information.

//Keep in mind that BOTH cliEmailConfig and cliEmail need to contain this file.
static class key
{
    private static string passKey = "";
    public static string getKey()
    {
        return passKey;
    }
}
