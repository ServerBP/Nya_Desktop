using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;

namespace nyaUpdater
{
    public partial class nya_updater : Form
    {
        public nya_updater()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            label1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            progressBar1.Value = 1;
            label1.Text = "Opened Environment...";
            string specificFolder = Path.Combine(folder, "nya_desktop");
            progressBar1.Value = 2;
            label1.Text = "Located Folder...";
            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
            }
            progressBar1.Value = 3;
            label1.Text = "Checked Foler...";
            string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
            progressBar1.Value = 4;
            label1.Text = "Opened MainFiles...";
            if (!Directory.Exists(specificFolder_mainFiles))
            {
                Directory.CreateDirectory(specificFolder_mainFiles);
            }
            progressBar1.Value = 5;
            label1.Text = "Checked MainFiles...";
            string specificFolder_logs = Path.Combine(specificFolder, "logs");
            progressBar1.Value = 6;
            label1.Text = "Opened Logs...";
            if (!Directory.Exists(specificFolder_logs))
            {
                Directory.CreateDirectory(specificFolder_logs);
            }
            progressBar1.Value = 7;
            label1.Text = "Checked Logs...";
            string specificFolder_save = Path.Combine(specificFolder, "saved");
            progressBar1.Value = 8;
            label1.Text = "Opened Save...";
            if (!Directory.Exists(specificFolder_save))
            {
                Directory.CreateDirectory(specificFolder_save);
            }
            progressBar1.Value = 9;
            label1.Text = "Checked Save...";


            progressBar1.Value = 10;
            string nyaFile = Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe");
            if (!System.IO.File.Exists(nyaFile))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/executables/Nya_Desktop.exe", Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe"));
                }
            }
            string assembly = getAssembly(nyaFile).ToString();
            progressBar1.Value = 50;
            label1.Text = "Recieved Assembly...";
            string newVer = "";
            using (var client = new WebClient())
            {
                newVer = client.DownloadString("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/version/main.txt");
            }
            progressBar1.Value = 51;
            label1.Text = "Recieved Newversion...";


            string nyaShortcut = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory), "Nya.Ink");
            if (!System.IO.File.Exists(nyaShortcut))
            {
                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Nya.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "New shortcut for Nya";
                shortcut.Hotkey = "Ctrl+Shift+N";
                shortcut.TargetPath = nyaFile;
                shortcut.Save();
            }


            string nyaUpdaterFile = Path.Combine(specificFolder_mainFiles, "nyaUpdater.exe");
            if (!System.IO.File.Exists(nyaUpdaterFile))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/executables/nyaUpdater.exe", Path.Combine(specificFolder_mainFiles, "nyaUpdater.exe"));
                    Process.Start(nyaUpdaterFile);
                    Application.Exit();
                    Environment.Exit(0);
                }
            }


            if (newVer.Contains(assembly) == true)
            {
                Console.WriteLine("equals");
                Process.Start(nyaFile); Environment.Exit(0);
            }
            else
            {
                System.IO.File.WriteAllText(Path.Combine(Path.Combine(specificFolder, "logs"), "launcher_versionLog_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")) + ".log", assembly + " " + newVer);
                using (var client = new WebClient())
                {
                    progressBar1.Value = 60;
                    label1.Text = "Initiated WebClient...";
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/executables/Nya_Desktop.exe", Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe"));
                    progressBar1.Value = 80;
                    label1.Text = "Downloaded executable...";
                    progressBar1.Value = 99;
                    label1.Text = "Created Shortcut...";
                    Process.Start(nyaFile);
                    progressBar1.Value = 100;
                    label1.Text = "Started Nya.exe...";
                    Environment.Exit(0);
                    Application.Exit();
                }
            }
        }


        public string getAssembly(string file)
        {
            string assembly;
            var domain = AppDomain.CreateDomain(nameof(Loader), AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(typeof(Loader).Assembly.Location) });
            try
            {
                var loader = (Loader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
                assembly = loader.Load(file);
            }
            finally
            {
                AppDomain.Unload(domain);
            }
            return assembly;
        }


        class Loader : MarshalByRefObject
        {
            public string Load(string file)
            {
                var assembly = Assembly.LoadFile(file);
                string version = assembly.GetName().Version.ToString();
                return version;
            }
        }
    }
}