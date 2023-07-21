using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using System.IO;
using System.Windows.Forms;

namespace Nya_Desktop
{
    public partial class addToPackForm : Form
    {
        public static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string specificFolder = Path.Combine(folder, "nya_desktop");
        public static string JSONFolder = Path.Combine(specificFolder, "JSON");
        public addToPackForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(packSelectionbox.SelectedItem.ToString())) return;
            new ToastContentBuilder()
                .AddText("Successfully added " + category.currentURL + " to pack: " + packSelectionbox.SelectedItem.ToString())
                .Show();
            category.log = "Successfully added " + category.currentURL + " to pack: " + packSelectionbox.SelectedItem.ToString();
        }

        private void addToPackForm_Load(object sender, EventArgs e)
        {
            category.log = "[addToPackForm] Form loaded";


            DirectoryInfo d = new DirectoryInfo(JSONFolder);
            category.log = "Started search for files...";
            foreach (var file in d.GetFiles("*.json"))
            {
                packSelectionbox.Items.Add(file.Name.Remove(file.Name.Length - 5));
            }
        }

        private void createNew_Click(object sender, EventArgs e)
        {
            if (packName.Visible == true)
            {
                if (string.IsNullOrEmpty(packName.Text)) return;
                File.AppendAllText(Path.Combine(JSONFolder, packName.Text + ".json"), category.currentURL + Environment.NewLine);
                category.log = "Created a new pack with the name of: " + packName.Text + ".json";
                new ToastContentBuilder()
                .AddText("Successfully added " + category.currentURL + " to pack: " + packName.Text)
                .Show();
                category.log = "Successfully added " + category.currentURL + " to pack: " + packName.Text;
                this.Close();
            } else
            {
                packName.Visible = true;
                createNew.Text = "Create";
            }
        }
    }
}
