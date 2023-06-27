using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nya_Launcher
{
    public partial class Form1 : Form
    {

        string currentLogFile = "";
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            currentLogFile += DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Component initialized" + "\n";

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            currentLogFile += "Environment Folder Opened | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";

            string specificFolder = Path.Combine(folder, "nya_desktop");
            currentLogFile += "Folders combined | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";

            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
                currentLogFile += "NEW LOCAl DIRECTORY CREATED | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";
            }

            string specificFolder_logs = Path.Combine(specificFolder, "logs");
            currentLogFile += "Folders combined | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";

            string specificFolder_save = Path.Combine(specificFolder, "saved");
            currentLogFile += "Folders combined | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";

            if (!Directory.Exists(specificFolder_logs))
            {
                Directory.CreateDirectory(specificFolder_logs);
                currentLogFile += "NEW LOG DIRECTORY CREATED | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";
            }
            if (!Directory.Exists(specificFolder_save))
            {
                Directory.CreateDirectory(specificFolder_save);
                currentLogFile += "NEW SAVE DIRECTORY CREATED | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";
            }


            string nya_File = Path.Combine(specificFolder, "Nya.exe");
            if (!File.Exists(nya_File))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/Nya_Desktop.exe", Path.Combine(specificFolder, "Nya.exe"));
                }
                string versionFile = Path.Combine(specificFolder, "ver.txt");
                if (!File.Exists(versionFile))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadFile("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/ver.txt", Path.Combine(specificFolder, "ver.txt"));
                    }
                }
                Process.Start(nya_File);
                Application.Exit();
                Environment.Exit(0);
            }

            string verFile = File.ReadAllText(Path.Combine(specificFolder, "ver.txt"));
            string nyaFile = Path.Combine(specificFolder, "Nya.exe");
            string newVer;
            using (var client = new WebClient())
            {
                newVer = client.DownloadString("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/ver.txt");
            }
            if (verFile != newVer)
            {
                File.Delete(nyaFile);
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/Nya_Desktop.exe", Path.Combine(specificFolder, "Nya.exe"));
                    client.DownloadFile("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/ver.txt", Path.Combine(specificFolder, "ver.txt"));
                }
            }
            Process.Start(nyaFile);
            Application.Exit();
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Environment Folder Opened" + Environment.NewLine;
            string specificFolder = Path.Combine(folder, "nya_desktop");
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Folders combined" + Environment.NewLine;
            File.WriteAllText(Path.Combine(Path.Combine(specificFolder, "logs"), "log_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")) + ".log", currentLogFile);
        }
    }
}
