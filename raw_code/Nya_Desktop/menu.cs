﻿using IWshRuntimeLibrary;
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

namespace Nya_Desktop
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void kill_Click(object sender, EventArgs e)
        {
            category.set = "kill";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void kiss_CLick(object sender, EventArgs e)
        {
            category.set = "kiss";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void blush_Click(object sender, EventArgs e)
        {
            category.set = "blush";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void hug_Click(object sender, EventArgs e)
        {
            category.set = "hug";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void cry_Click(object sender, EventArgs e)
        {
            category.set = "cry";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void handhold_Click(object sender, EventArgs e)
        {
            category.set = "handhold";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void cringe_Click(object sender, EventArgs e)
        {
            category.set = "cringe";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void dance_Click(object sender, EventArgs e)
        {
            category.set = "dance";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void highfive_Click(object sender, EventArgs e)
        {
            category.set = "highfive";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void wave_Click(object sender, EventArgs e)
        {
            category.set = "wave";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void poke_Click(object sender, EventArgs e)
        {
            category.set = "poke";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void wink_Click(object sender, EventArgs e)
        {
            category.set = "wink";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void smile_Click(object sender, EventArgs e)
        {
            category.set = "smile";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void nom_Click(object sender, EventArgs e)
        {
            category.set = "nom";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void happy_Click(object sender, EventArgs e)
        {
            category.set = "happy";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void cuddle_Click(object sender, EventArgs e)
        {
            category.set = "cuddle";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void bully_Click(object sender, EventArgs e)
        {
            category.set = "bully";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void yeet_Click(object sender, EventArgs e)
        {
            category.set = "yeet";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void kick_Click(object sender, EventArgs e)
        {
            category.set = "kick";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void slap_Click(object sender, EventArgs e)
        {
            category.set = "slap";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void bonk_Click(object sender, EventArgs e)
        {
            category.set = "bonk";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void megumin_Click(object sender, EventArgs e)
        {
            category.set = "megumin";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void shinobu_Click(object sender, EventArgs e)
        {
            category.set = "shinobu";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void smug_Click(object sender, EventArgs e)
        {
            category.set = "smug";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void glomp_Click(object sender, EventArgs e)
        {
            category.set = "glomp";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void bite_Click(object sender, EventArgs e)
        {
            category.set = "bite";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void pat_Click(object sender, EventArgs e)
        {
            category.set = "pat";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void neko_Click(object sender, EventArgs e)
        {
            category.set = "neko";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void waifu_Click(object sender, EventArgs e)
        {   
            category.set = "waifu";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void lick_Click(object sender, EventArgs e)
        {
            category.set = "lick";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void awoo_Click(object sender, EventArgs e)
        {
            category.set = "awoo";
            currentCategory_lb.Text = "Current Category: " + category.set;
        }

        private void open_local_Click(object sender, EventArgs e)
        {
            string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string nyaFolder = Path.Combine(localFolder, "nya_desktop");
            string nyaFolder_saved = Path.Combine(nyaFolder, "saved");
            Process.Start(nyaFolder_saved);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void cfu_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "nya_desktop");
            string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
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
            else
            {
                Process.Start(nyaUpdaterFile);
                Application.Exit();
                Environment.Exit(0);
            }
        }
    }
}