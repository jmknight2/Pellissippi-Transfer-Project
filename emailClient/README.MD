Email Client
============

This email client was made in c# with the help of Microsoft's SMTP objects. It's designed to send off HTML emails by looking into an encrypted list of contacts, and connects to the mail server of the owner's choice. Since this client sends emails programatically, it can be applied to other programming langages or a batch script so one doesn't have to think about it after it's been setup.

Due to the sensitivity of some info this program requires (username, password), all configuration files are encrypted as they are saved.

The client is bundled with a separate windows forms configuration tool, and is required to setup the client to send emails. It helps setup everything except for the message itself, and attachments one wishes to send; both of which can be set as batch arguments.

## Usage:
# First-time setup (for compiling only):
This program is capable of containing sensitive information, and as of this verison, it could potentially be easily reverse engineered to unlock said information if the developer is not careful with the source code.
To combat this, you will find a file called "key.cs", which is required to compile both programs without errors.

To use it, first add this file to both projects in visual studio, then insert a uuid (or any string of hex characters) without a hyphen (-) into the passKey string.
This unique key will be used to decrypt the first half of the file. The second half is decrypted through a user-generated uuid (based on a password).

This way, if an attacker used this source code from github, he/she could not access any other email client, as they wouldn't have their unique key.

## cliEmailConfig.exe

This is a GUI based tool. When initialy starting up the program, the user is required to either create a new configuration, or open an exhisting one. When creating a new configuration, a password is required to start setting up the config. After the user fills in the information, files are saved with a .econf extension.

### Connection settings:
One of the requirements to actually connecting to the server is the SMTP server information. This is the mail server one wishes to use (e.g office.365.com goes to microsoft office servers), the port, and the username and password for the account of said smtp server.

### misc
When adding contacts, please refrain from using any commas in the name fields, as they help the program separate certian types of information when decoding the encrypted file. There will be a patch later to prevent this...

## cliEmail.exe
This the actual program that sends emails. It reads the econf file requested by the user, and sends off the message, as well as any attachments that may have been requested.

### Dependencies:
* *.econf (searches for "default.econf" automatically) Your setup file. Use this to send emails based off of the information in this file.
* *.html (searches for "default.html" automatically) The message. This is the same as a regular html file, with one difference as shown below:

```html
INSERT SUBJECT HERE
<span>Message goes below the subject line. (span tag isn't required)</span>
<b>wheeeee</b><br><br>pretty much just good 'ol html...
```

### Usage:
### ./cliEmail \[-html "./path/to/message.html"\] \[-config "./path/to/config.econf"\] \[-files \["./path/to/file1.*"\] \["./path/to/file2.*"\] \["./etc/etc.*"\] \]

**WHERE:** 
* -html is the location of your message. By default, it looks for "./default.html", so this flag is optional.
* -config is the path to the configuration. This flag is also optional, it looks for "./default.econf" automatically.
* -files is an infinite list of attachments you would like to use. They can be any file type. This flag isn't required if you don't have anything to attach.

## Example:
```
./cliEmail -files ./myPuppy.png ./nyanCat.gif ./bensTwinBrother.jpg -html ./photoGallery.html
#I'm a weird person and chose to use the html flag XP
#Again, the program assumes we have default.econf ready to send this message off.
```