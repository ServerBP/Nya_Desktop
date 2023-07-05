using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nya_Desktop
{
    public partial class notification : Form
    {
        public string close = "no";
        public notification()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            
            this.Hide();
        }

        private void notification_Load(object sender, EventArgs e)
        {
            notif_text.Text = category.notif;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            close = "yes";
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            Actions.updateNow();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (close == "yes") return;
            e.Cancel = true;
        }
    }
}
