# Iniquitous
Iniquitous is a tiny application that locks a user out of his or her computer with a very simple yet significantly damaging technique.

This repository contains two projects within the solution:
* Payload - The actual executable that disables usage of the main functions of the computer.
* Builder - The application that allows an individual to customize and build a stub (or Payload) through a graphical user interface.

### About
Iniquitous was inspired by the ransomware trojan, [CryptoLocker](https://en.wikipedia.org/wiki/CryptoLocker). CryptoLocker was a program that encrypted files with certain filetypes to target seemingly important documents (such as Word documents). The encryption method used incorporated a public private key pair; the private key was stored on the trojan's developer's server. The program demanded a random of a significant amount of money (100 USD ~ 300 USD) to be paid within a short amount of time; if the ransom was not paid, the private key stored on the server would be destroyed, technically eliminating any chance to recover the affected files.

Iniquitous does not directly incorporate the usage of a ransom (though it is possible for it to be used in conjunction with demanding ransom). Instead, the payload locks and disables usage of the computer and presents a window with a button and a text box. To close the payload's process and "unlock" the computer, the correct password must be entered in the text box. The user is given unlimited tries (as any and all other programs would have been terminated) to enter the password, but until the correct one is entered, the payload still remains, disabling any other basic usage of the computer. The password is not stored in plain text within the executable; the password is defined as the [MD5](https://en.wikipedia.org/wiki/MD5) hash of the password string, and stored as a static string in the source code. When a password is entered, the hash of the inputted string is compared with the pre-set static string that represents the hash of the correct password. If they match, the program closes.

### How It Works

Iniquitous's disabling technique works in a very straightforward way.

1. A Timer object is created. Its interval is set to a very small time; by default it is 100 milliseconds.
2. The Tick event of the Timer is set to be handled by a method named **Disable**.
3. The Timer as the form is shown.

### The Disable Method
Every 100 milliseconds (by default), this method is called. This method effectively disallows any basic usage of the computer by:
* Minimizing all open windows
* Killing all other processes that have a window title
  * It is possible configure the payload to kill all other processes regardless of having a window title or not
  * It is also possible to configure the payload to kill processes that are essential in running the computer, such as all instances of *svchost.exe* or *winlogon.exe*
* Killing all instances of Windows Explorer (explorer.exe) to prevent access to any of the user's applications
* Killing all instances of Task Manager (taskmgr.exe) to prevent the payload's process from being killed

### Other Annoyances
Besides having such a simple yet destructive method called over and over, there are other things that contribute to the damaging aspect of Iniquitous.

* The Alt + F4 keyboard shortcut (usually used to close a running application) is unable to close the payload's form.
* The payload is copied to the user's startup folder, so the payload runs again when logging back in.
  * Unfortunately, I did not make the payload copy itself to the startup folder for all users, as that would require administrative privileges (as far as I remember).
* The correct password's plaintext is not stored in the source; rather, the MD5 hash of the correct password is stored which (somewhat) prevents the password from being looked up if the assembly was somehow unintentionally compromised.

## Considerations / Possible To-Do list
* Make killing all other processes optional, as it can sometimes be excessively destructive in nature.
