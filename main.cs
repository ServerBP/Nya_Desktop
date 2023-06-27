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

namespace Nya_Desktop
{
    public partial class Form1 : Form
    {
        PictureBox pb1;
        ContextMenu cm = new ContextMenu();
        string specificFolder;
        string currentLogFile;
        string imageURL;
        string category = "waifu";

        public Form1()
        {
            InitializeComponent();

            buttons_disappear();


            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            currentLogFile += DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] Component Inicilized" + "\n";

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
                var URL = "https://waifu.pics/api/sfw/" + category;
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

        private void open_Click(object sender, EventArgs e)
        {
            string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string nyaFolder = Path.Combine(localFolder, "nya_desktop");
            string nyaFolder_saved = Path.Combine(nyaFolder, "saved");
            Process.Start(nyaFolder_saved);
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
                currentLogFile += "[" + DateTime.Now.ToString("yyyyy MM dd HH:mm:ss") + "] File downloaded" + "\n" + Environment.NewLine;
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            buttons_appear();
        }

        private void kill_Click(object sender, EventArgs e)
        {
            category = "kill";
            buttons_disappear();
        }

        private void kiss_Click(object sender, EventArgs e)
        {
            category = "kiss";
            buttons_disappear();
        }

        private void blush_Click(object sender, EventArgs e)
        {
            category = "blush";
            buttons_disappear();
        }

        private void hug_Click(object sender, EventArgs e)
        {
            category = "hug";
            buttons_disappear();
        }

        private void cry_Click(object sender, EventArgs e)
        {
            category = "cry";
            buttons_disappear();
        }

        private void handhold_Click(object sender, EventArgs e)
        {
            category = "handhold";
            buttons_disappear();
        }

        private void cringe_Click(object sender, EventArgs e)
        {
            category = "cringe";
            buttons_disappear();
        }

        private void dance_Click(object sender, EventArgs e)
        {
            category = "dance";
            buttons_disappear();
        }

        private void highfive_Click(object sender, EventArgs e)
        {
            category = "highfive";
            buttons_disappear();
        }

        private void wave_Click(object sender, EventArgs e)
        {
            category = "wave";
            buttons_disappear();
        }

        private void poke_Click(object sender, EventArgs e)
        {
            category = "poke";
            buttons_disappear();
        }

        private void wink_Click(object sender, EventArgs e)
        {
            category = "wink";
            buttons_disappear();
        }

        private void smile_Click(object sender, EventArgs e)
        {
            category = "smile";
            buttons_disappear();
        }

        private void nom_Click(object sender, EventArgs e)
        {
            category = "nom";
            buttons_disappear();
        }

        private void happy_Click(object sender, EventArgs e)
        {
            category = "happy";
            buttons_disappear();
        }

        private void cuddle_Click(object sender, EventArgs e)
        {
            category = "cuddle";
            buttons_disappear();
        }

        private void bully_Click(object sender, EventArgs e)
        {
            category = "bully";
            buttons_disappear();
        }

        private void yeet_Click(object sender, EventArgs e)
        {
            category = "yeet";
            buttons_disappear();
        }

        private void kick_Click(object sender, EventArgs e)
        {
            category = "kick";
            buttons_disappear();
        }

        private void slap_Click(object sender, EventArgs e)
        {
            category = "slap";
            buttons_disappear();
        }

        private void bonk_Click(object sender, EventArgs e)
        {
            category = "bonk";
            buttons_disappear();
        }

        private void megumin_Click(object sender, EventArgs e)
        {
            category = "megumin";
            buttons_disappear();
        }

        private void shinobu_Click(object sender, EventArgs e)
        {
            category = "shinobu";
            buttons_disappear();
        }

        private void smug_Click(object sender, EventArgs e)
        {
            category = "smug";
            buttons_disappear();
        }

        private void glomp_Click(object sender, EventArgs e)
        {
            category = "slomp";
            buttons_disappear();
        }

        private void bite_Click(object sender, EventArgs e)
        {
            category = "bite";
            buttons_disappear();
        }

        private void pat_Click(object sender, EventArgs e)
        {
            category = "pat";
            buttons_disappear();
        }

        private void neko_Click(object sender, EventArgs e)
        {
            category = "neko";
            buttons_disappear();
        }

        private void waifu_Click(object sender, EventArgs e)
        {
            category = "waifu";
            buttons_disappear();
        }

        private void lick_Click(object sender, EventArgs e)
        {
            category = "lick";
            buttons_disappear();
        }

        private void awoo_Click(object sender, EventArgs e)
        {
            category = "awoo";
            buttons_disappear();
        }

        public void buttons_disappear()
        {
            kill.Visible = false;
            waifu.Visible = false;
            neko.Visible = false;
            shinobu.Visible = false;
            megumin.Visible = false;
            bully.Visible = false;
            cuddle.Visible = false;
            cry.Visible = false;
            hug.Visible = false;
            awoo.Visible = false;
            kiss.Visible = false;
            lick.Visible = false;
            pat.Visible = false;
            smug.Visible = false;
            bonk.Visible = false;
            yeet.Visible = false;
            blush.Visible = false;
            smile.Visible = false;
            wave.Visible = false;
            highfive.Visible = false;
            handhold.Visible = false;
            nom.Visible = false;
            bite.Visible = false;
            glomp.Visible = false;
            slap.Visible = false;
            kick.Visible = false;
            happy.Visible = false;
            wink.Visible = false;
            poke.Visible = false;
            dance.Visible = false;
            cringe.Visible = false;
        }

        public void buttons_appear()
        {
            kill.Visible = true;
            waifu.Visible = true;
            neko.Visible = true;
            shinobu.Visible = true;
            megumin.Visible = true;
            bully.Visible = true;
            cuddle.Visible = true;
            cry.Visible = true;
            hug.Visible = true;
            awoo.Visible = true;
            kiss.Visible = true;
            lick.Visible = true;
            pat.Visible = true;
            smug.Visible = true;
            bonk.Visible = true;
            yeet.Visible = true;
            blush.Visible = true;
            smile.Visible = true;
            wave.Visible = true;
            highfive.Visible = true;
            handhold.Visible = true;
            nom.Visible = true;
            bite.Visible = true;
            glomp.Visible = true;
            slap.Visible = true;
            kick.Visible = true;
            happy.Visible = true;
            wink.Visible = true;
            poke.Visible = true;
            dance.Visible = true;
            cringe.Visible = true;
        }
    }
}

/*
  + "log_" + DateTime.Now.ToString("yyyyy_MM_dd_HH_mm_ss")
 * 
 * 
 * 
 */
