using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        }

        private void kill_Click(object sender, EventArgs e)
        {
            category.set = "kill";
        }

        private void kiss_CLick(object sender, EventArgs e)
        {
            category.set = "kiss";
        }

        private void blush_Click(object sender, EventArgs e)
        {
            category.set = "blush";
        }

        private void hug_Click(object sender, EventArgs e)
        {
            category.set = "hug";
        }

        private void cry_Click(object sender, EventArgs e)
        {
            category.set = "cry";
        }

        private void handhold_Click(object sender, EventArgs e)
        {
            category.set = "handhold";
        }

        private void cringe_Click(object sender, EventArgs e)
        {
            category.set = "cringe";
        }

        private void dance_Click(object sender, EventArgs e)
        {
            category.set = "dance";
        }

        private void highfive_Click(object sender, EventArgs e)
        {
            category.set = "highfive";
        }

        private void wave_Click(object sender, EventArgs e)
        {
            category.set = "wave";
        }

        private void poke_Click(object sender, EventArgs e)
        {
            category.set = "poke";
        }

        private void wink_Click(object sender, EventArgs e)
        {
            category.set = "wink";
        }

        private void smile_Click(object sender, EventArgs e)
        {
            category.set = "smile";
        }

        private void nom_Click(object sender, EventArgs e)
        {
            category.set = "nom";
        }

        private void happy_Click(object sender, EventArgs e)
        {
            category.set = "happy";
        }

        private void cuddle_Click(object sender, EventArgs e)
        {
            category.set = "cuddle";
        }

        private void bully_Click(object sender, EventArgs e)
        {
            category.set = "bully";
        }

        private void yeet_Click(object sender, EventArgs e)
        {
            category.set = "yeet";
        }

        private void kick_Click(object sender, EventArgs e)
        {
            category.set = "kick";
        }

        private void slap_Click(object sender, EventArgs e)
        {
            category.set = "slap";
        }

        private void bonk_Click(object sender, EventArgs e)
        {
            category.set = "bonk";
        }

        private void megumin_Click(object sender, EventArgs e)
        {
            category.set = "megumin";
        }

        private void shinobu_Click(object sender, EventArgs e)
        {
            category.set = "shinobu";
        }

        private void smug_Click(object sender, EventArgs e)
        {
            category.set = "smug";
        }

        private void glomp_Click(object sender, EventArgs e)
        {
            category.set = "slomp";
        }

        private void bite_Click(object sender, EventArgs e)
        {
            category.set = "bite";
        }

        private void pat_Click(object sender, EventArgs e)
        {
            category.set = "pat";
        }

        private void neko_Click(object sender, EventArgs e)
        {
            category.set = "neko";
        }

        private void waifu_Click(object sender, EventArgs e)
        {   
            category.set = "waifu";
        }

        private void lick_Click(object sender, EventArgs e)
        {
            category.set = "lick";
        }

        private void awoo_Click(object sender, EventArgs e)
        {
            category.set = "awoo";
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
    }
}
