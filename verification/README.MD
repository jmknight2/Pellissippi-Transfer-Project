Scrambler verify
================

This is a program to help with security. It checks to see if a string can unscramble an encrypted piece of text (built in to the program); if successful, it prints "True" to the command line.

## Usage:
 
### Encrypting
 ```./scramblerVerify -e password [anotherPassword] [ANOTHERpassword:O] [-f ./path/to/textFile.txt]```

 **WHERE:**

**-e** is the encryption flag. it scrambles the built-in string with the specified password, then outputs the scrambled string to the command line. If you specify more passwords, it will also output those strings as well.

**-f** allows you to save the scrambled string(s) into the file of your choice.

### Decrypting
```./scramblerVerify password scrambledString [scrambledString2] [scrambledString3] [-f ./path/to/textFile.txt]```

**WHERE:**

**-f** tells the program you wish to compare "password" to that file. It looks through all other scrambled strings in that file, and if nothing can get unscrambled, it returns "False".

When decrypting, the first argument is always the password you want to use to unscramble the second argument, as well as any other scrambled arguments provided. You can request *both* an external file, and scrambled arguments to be compared at the same time.