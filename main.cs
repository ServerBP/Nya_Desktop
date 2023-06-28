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

namespace Nya_Desktop
{
    public partial class Form1 : Form
    {
        PictureBox pb1;
        ContextMenu cm = new ContextMenu();
        string specificFolder;
        string currentLogFile;
        string imageURL = "https://cdn.waifu.im/7581.jpg";


        public Form1()
        {
            category.set = "waifu";
            InitializeComponent();
            notifications.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            currentLogFile += DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Component Initialized" + "\n";

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

            PictureBox pb1 = pictureBox1;
            using (var client = new WebClient())
            {
                pb1.ImageLocation = "https://cdn.waifu.im/7581.jpg";
                pb1.SizeMode = PictureBoxSizeMode.Zoom;
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Default image set" + Environment.NewLine;
            }  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentLogFile += "Form1 loaded | at: " + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "\n";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ContextMenu = cm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PictureBox pb1 = pictureBox1;
            using (var client = new WebClient())
            {
                var URL = "https://waifu.pics/api/sfw/" + category.set;
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] URL set" + Environment.NewLine;
                var responseStr = client.DownloadString(URL);
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Initial URL recieved: " + responseStr + Environment.NewLine;
                var newresponse = responseStr.Remove(responseStr.Length - 3);
                imageURL = newresponse.Substring(8, newresponse.Length - 8);
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Front URL cropped: " + imageURL + Environment.NewLine;

                this.Controls.Add(pb1);
                pb1.ImageLocation = imageURL;
                pb1.SizeMode = PictureBoxSizeMode.Zoom;
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Image set" + Environment.NewLine;
            }
        }
        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Environment Folder Opened" + Environment.NewLine;
            string specificFolder = Path.Combine(folder, "nya_desktop");
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Folders combined" + "\n" + Environment.NewLine;
            File.WriteAllText(Path.Combine(Path.Combine(specificFolder, "logs"), "log_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")) + ".log", currentLogFile);
        }

        private void dl_Click(object sender, EventArgs e)
        {
            string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string nyaFolder = Path.Combine(localFolder, "nya_desktop");
            string nyaFolder_saved = Path.Combine(nyaFolder, "saved");
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Folders combined" + "\n" + Environment.NewLine;

            var imageName = imageURL.Substring(21, imageURL.Length - 21);
            currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Image name cropped: " + imageName + "\n" + Environment.NewLine;
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(imageURL, Path.Combine(nyaFolder_saved, imageName));
                category.notif = "Image Downloaded!";
                popup popup = new popup();
                popup.Visible = true;
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] File downloaded" + "\n" + Environment.NewLine;
                notifications.Text = "Nya Downloaded!";
                notifications.Visible = true;
                Thread.Sleep(3000);
                notifications.Visible = false;
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Visible = true;
        }
    }

    class category
    {
        public static string Category = "waifu";

        public static string set
        {
            get
            {
                return Category;
            }
            set
            {
                Category = value;
            }
        }

        public static string notif = "";

        public static string notifications
        {
            get
            {
                return notif;
            }
            set
            {
                notif = value;
            }
        }
    }
}

/*
  + "log_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")
 * 
 * 
 * 
 */
