// 0.0.0.1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO.Ports;
using System.Reflection;
using IWshRuntimeLibrary;

namespace Nya_Desktop
{
    public partial class Form1 : Form
    {
        // setting the default image URL
        string imageURL = "https://cdn.waifu.im/7581.jpg";
        // we define all of the needed variables
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "nya_desktop");
        public static string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
        public static string specificFolder_logs = Path.Combine(specificFolder, "logs");
        public static string specificFolder_save = Path.Combine(specificFolder, "saved");
        public Form1()
        {
            // setting the default category to waifu
            category.set = "waifu"; 
            InitializeComponent();
            // setting the notifications form to non visible
            notifications.Visible = false; 

            // setting the form size to static
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            //setting the form to be able to be minimized, but not fullscreened
            this.MaximizeBox = false;
            this.MinimizeBox = true; 
            // logging
            category.log = "Component Inicialized and defaults set";

            // making the form start in the top right
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);

            // check if the appdata folder doesn't exists
            if (!Directory.Exists(specificFolder))
            {
                Directory.CreateDirectory(specificFolder);
                category.log = "CREATED NEW LOCAL DIRECTORY";
            }
            // check if the mainFiles folder exists
            if (!Directory.Exists(specificFolder_mainFiles))
            {
                Directory.CreateDirectory(specificFolder_mainFiles);
                category.log = "NEW MAINFILES DIRECTORY CREATED";
            }
            // check if the logs folder exists
            if (!Directory.Exists(specificFolder_logs))
            {
                Directory.CreateDirectory(specificFolder_logs);
                category.log = "NEW LOG DIRECTORY CREATED";
            }
            // check if the save folder exists
            if (!Directory.Exists(specificFolder_save))
            {
                Directory.CreateDirectory(specificFolder_save);
                category.log = "NEW SAVE DIRECTORY CREATED";
            }


            // check if the windows notifications dll file exists
            string notifdll_File = Path.Combine(specificFolder_mainFiles, "Microsoft.Toolkit.Uwp.Notifications.dll");
            if (!System.IO.File.Exists(notifdll_File))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/executables/Microsoft.Toolkit.Uwp.Notifications.dll", Path.Combine(specificFolder_mainFiles, "Microsoft.Toolkit.Uwp.Notifications.dll"));
                    category.log = "Downloaded windows notification dll";
                }
            }
            // check if the nya file exists in the local folder
            string nyaFile = Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe");
            if (!System.IO.File.Exists(nyaFile))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://github.com/ServerBP/Nya_Desktop/raw/main/executables/Nya_Desktop.exe", Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe"));
                }
            }
            // check if the nya updater file exists
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

            // create a variable for the online version
            string newVer = "";
            // set the online version variable to the value
            using (var client = new WebClient())
            {
                newVer = client.DownloadString("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/version/main.txt");
            }
            // create a variable for the local nya file assembly version
            string assembly;
            // check for the assembly
            var domain = AppDomain.CreateDomain(nameof(Loader), AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(typeof(Loader).Assembly.Location) });
            try
            {
                var loader = (Loader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
                assembly = loader.Load(nyaFile);
            }
            finally
            {
                AppDomain.Unload(domain);
            }
            // check if the assembly equal to the online verison
            if (!newVer.Contains(assembly))
            {
                // if an update is available we notify the user with a popup form that cannot be closed
                category.notif = "A Nya update is available!\n\nTo get started either press the Update Now button or go into the menu and press Check for Updates!";
                notification notifForm = new notification();
                notifForm.Show();
            }

            // we define the picturebox variable
            PictureBox pb1 = pictureBox1;
            // we set the default image
            using (var client = new WebClient())
            {
                pb1.ImageLocation = "https://cdn.waifu.im/7581.jpg";
                pb1.SizeMode = PictureBoxSizeMode.Zoom;
                category.log = "Default Image set";
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            category.log = "Form 1 loaded";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        // when the NYA button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pb1 = pictureBox1;
            using (var client = new WebClient())
            {
                // we set the image URL
                var URL = "https://waifu.pics/api/sfw/" + category.set;
                category.log = "URL set to: " + URL;
                // we download the image as a JSON
                var responseStr = client.DownloadString(URL);
                category.log = "Initial URL recieved: " + responseStr;
                // we modify the JSON formatted string to get the URL
                var newresponse = responseStr.Remove(responseStr.Length - 3);
                // we set the imageURL variable to be the new URL
                imageURL = newresponse.Substring(8, newresponse.Length - 8);
                category.log = "Image URL created: " + imageURL;

                // we set the image and scaling mode etc...
                this.Controls.Add(pb1);
                pb1.ImageLocation = imageURL;
                pb1.SizeMode = PictureBoxSizeMode.Zoom;
                category.log = "Image set to: " + imageURL;
            }
        }

        // when the form is closing
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return; // if windows is shutting down
            if (e.CloseReason == CloseReason.FormOwnerClosing) return; // if the menu is closing

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }

        private void dl_Click(object sender, EventArgs e) // when we click the DL button
        {
            category.log = "Folders combined";
            // we create a name for the image based on the URL
            var imageName = imageURL.Substring(21, imageURL.Length - 21);
            category.log = "Image name created: " + imageName;
            using (WebClient client = new WebClient())
            {
                // we download the image to the right place
                client.DownloadFile(imageURL, Path.Combine(specificFolder_save, imageName));
                category.notif = "Image Downloaded!";
                // we send a windows notification to the user
                new ToastContentBuilder()
                .AddText("Image Downloaded!")
                .Show();
                category.log = "Image downloaded";
            }
        }

        // when the menu button is clicked
        private void settings_Click(object sender, EventArgs e)
        {
            // we create a new menu instance and start it
            menu menu = new menu();
            menu.Visible = true;
            category.log = "Menu started";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }


    // the category class is the class for the variables that need to be used by other forms.
    class category
    {
        // the image category variable
        public static string Category = "waifu";
        public static string set
        {
            get{return Category;}
            set{ Category = value; category.log = "Category set to: " + value; }
        }


        // the text for the notification window
        public static string notif = "";
        public static string notifications
        {
            get {return notif;}
            set{notif = value;}
        }


        // the logFile
        public static string logString = "";
        public static string log
        {
            get { return logString; }
            set { logString += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] " + value + Environment.NewLine; }
        }
    }


    // the file loader for the assembly loading
    class Loader : MarshalByRefObject
    {
        public string Load(string file)
        {
            var assembly = Assembly.LoadFile(file);
            string version = assembly.GetName().Version.ToString();
            return version;
        }
    }



    // the class for any actions that are triggered by other windows
    public class Actions
    {
        // when the update now button is clicked in the notification or we check for updates
        public static void updateNow()
        {
            // we have to redefine the variables
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "nya_desktop");
            string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
            Process.Start(Path.Combine(specificFolder_mainFiles, "nyaUpdater.exe"));
            Application.Exit();
            Environment.Exit(0);
        }

        // when we need logs to be created
        public static void createLogs()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            category.log = "Environment Folder Opened";
            string specificFolder = Path.Combine(folder, "nya_desktop");
            category.log = "Folders combined";
            System.IO.File.WriteAllText(Path.Combine(Path.Combine(specificFolder, "logs"), "log_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")) + ".log", category.log);
        }
    }
}