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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;

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

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "nya_desktop");
            string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
            string nyaFile = Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe");
            var domain = AppDomain.CreateDomain(nameof(Loader), AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(typeof(Loader).Assembly.Location) });
            try
            {
                var loader = (Loader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
                buildID.Text = "Build ID:\n"+ loader.Load(nyaFile);
            }
            finally
            {
                AppDomain.Unload(domain);
            }

            
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
            category.log = "[MENU] Exit button pressed";
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            category.log = "[MENU] Menu loaded";


            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "nya_desktop");
            string JSONFolder = Path.Combine(specificFolder, "JSON");
            DirectoryInfo d = new DirectoryInfo(JSONFolder);
            category.log = "Started search for files...";
            foreach (var file in d.GetFiles("*.json"))
            {
                packsDropdown.Items.Add(file.Name.Remove(file.Name.Length - 5));
                category.log = "Added item: " + file.Name + " to the items list.";
            }
        }

        private void cfu_Click(object sender, EventArgs e)
        {
            category.log = "[MENU] Update now pressed";
            Actions.updateNow();
        }

        private void log_Click(object sender, EventArgs e)
        {
            category.log = "[MENU] Log creation inicialized";
            Actions.createLogs();
        }

        private void changelogs_Click(object sender, EventArgs e)
        {
            string assembly;
            var domain = AppDomain.CreateDomain(nameof(Loader), AppDomain.CurrentDomain.Evidence, new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(typeof(Loader).Assembly.Location) });
            try
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string specificFolder = Path.Combine(folder, "nya_desktop");
                string specificFolder_mainFiles = Path.Combine(specificFolder, "mainFiles");
                string nyaFile = Path.Combine(specificFolder_mainFiles, "Nya_Desktop.exe");
                var loader = (Loader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
                assembly = loader.Load(nyaFile);
            }
            finally
            {
                AppDomain.Unload(domain);
            }
            var uri = "https://github.com/ServerBP/Nya_Desktop/releases/tag/v" + assembly;
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = uri
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void packsDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (packsDropdown.SelectedItem.ToString() == "BlueWay")
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string specificFolder = Path.Combine(folder, "nya_desktop");
                string JSONFolder = Path.Combine(specificFolder, "JSON");
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://raw.githubusercontent.com/ServerBP/Nya_Desktop/main/packs/JSON/BlueWay.json", Path.Combine(JSONFolder, "BlueWay.json"));
                }
                category.API = "p:" + packsDropdown.SelectedItem.ToString();
                currentCategory_lb.Text = "Current Category: " + packsDropdown.SelectedItem.ToString() + " Pack";
                category.log = "Set new pack to: " + packsDropdown.SelectedItem.ToString();
            }
            else
            {
                category.API = "p:" + packsDropdown.SelectedItem.ToString();
                currentCategory_lb.Text = "Current Category: " + packsDropdown.SelectedItem.ToString() + " Pack";
                category.log = "Set new pack to: " + packsDropdown.SelectedItem.ToString();
            }
        }

        private void dlPacks_Click(object sender, EventArgs e)
        {
            // open the JSON github folder in the default browser
            var uri = "https://github.com/ServerBP/Nya_Desktop/tree/main/packs/JSON";
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = uri
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void importPacks_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "nya_desktop");
            string JSONFolder = Path.Combine(specificFolder, "JSON");
            OpenFileDialog opd = new OpenFileDialog();
            opd.Title = "Secelt your pack file!";
            opd.Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";
            opd.FileName = "Select your pack file";
            category.log = "File select dialog shown";
            if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fi = new FileInfo(opd.FileName);
                System.IO.File.Move(opd.FileName, Path.Combine(JSONFolder, fi.Name));
                category.log = "File moved!";
            }
            new ToastContentBuilder()
                .AddText("Successfully imported pack!")
                .Show();
            category.log = "Gave user a notification about the import";
        }

        private void addToPack_Click(object sender, EventArgs e)
        {
            var addToPacksForm = new addToPackForm();
            addToPacksForm.Show();
            category.log = "AddPacks Form inicialized";
        }
    }
}
