# Abantes
This trojan made for fun.
The Creators are not responsible for any damage made using this trojan.
Please don't use this virus to troll your friends because it will make their PC unusable
### Plugins And Software Used
###### Plugins
* [Fody](https://github.com/Fody/Fody)
* [Costura.fody](https://github.com/Fody/Costura)
* [Task Scheduler](https://github.com/dahall/TaskScheduler)
###### Software
* [NASM](http://nasm.us)
* [Resource Hacker](http://www.angusj.com/resourcehacker/)
### Debug Mode
Abantes has it's own debug system in place, just add a string `Debug` with a value of `1` to
######64Bit Windows
`HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Abantes`
######32Bit Windows
`HKEY_LOCAL_MACHINE\SOFTWARE\Abantes`
### Payloads (23)
* Infecting Image File Execution Options
* Schedule its launch in Task Scheduler
* Hide all drives
* Disallow access to all drives
* Infect Winlogon (Userinit and Explorer Shell)
* Change context menu text and start menu text
* Change window titles
* Change button text window text and other strings for some windows
* Draw question icons to screen
* Process and file watch dog
* MBR overwrite
* Logon UI overwrite
* Encrypts user files with extension .Abantes
* Flip screen
* Draw black and red text to screen
* change the screen and re-draw it disorientated in a new location (hard to explain)
* Eject CD
* draw the screen inverted slowly, sliding effect
* re-draw the screen with merged colours
* Force BSOD (kill all processes or NTRAISEHARDERROR)
* Trap the mouse
* Random keyboard input
* Random OS Sounds
* Delete as much of the Windows Registry as it can
### Coded In:
* C#
* C++
* Batch
* Assembly
* Python
