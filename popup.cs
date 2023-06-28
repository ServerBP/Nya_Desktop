using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Nya_Desktop
{
    public partial class popup : Form
    {
        public popup()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }

        private void popup_Load(object sender, EventArgs e)
        {
            notification_lb.Text = category.notif;
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
