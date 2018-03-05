Scrambler verify
================

This is a program to help with security. It checks to see if a string can unscramble an encrypted piece of text (built in to the program); if successful, it prints "True" to the command line.

## Usage:
 
### Encrypting
 ```./scramblerVerify.exe -e password [anotherPassword] [ANOTHERpassword:O] [-f ./path/to/textFile.txt]```

 **WHERE:**

**-e** is the encryption flag. it scrambles the built-in string with the specified password, then outputs the scrambled string to the command line. If you specify more passwords, it will also output those strings as well.

**-f** allows you to save the scrambled string(s) into the file of your choice.

### Decrypting
```./scramblerVerify.exe password scrambledString [scrambledString2] [scrambledString3] [-f ./path/to/textFile.txt]```

**WHERE:**

**-f** tells the program you wish to compare "password" to that file. It looks through all other scrambled strings in that file, and if nothing can get unscrambled, it returns "False".

When decrypting, the first argument is always the password you want to use to unscramble the second argument, as well as any other scrambled arguments provided. You can request *both* an external file, and scrambled arguments to be compared at the same time.

### Removing a "password"
Passwords do **not** get stored in this program, just scrambled text that can be unscrabled with that password. If you wish to remove a reference to such a password (The password will no longer return true), use the following:

```./scramblerVerify.exe -r password1 [password2] [passEtc] -f ./path/to/textFile.txt```

**WHERE**

**-r** represents *remove*. Use this to remove the requested password reference.

You can remove multiple references to passcodes at once (as represented by password1,etc.)