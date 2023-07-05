namespace Nya_Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nya = new System.Windows.Forms.Button();
            this.dl = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.notifications = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(59, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(781, 567);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // nya
            // 
            this.nya.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nya.Location = new System.Drawing.Point(0, 273);
            this.nya.Name = "nya";
            this.nya.Size = new System.Drawing.Size(53, 293);
            this.nya.TabIndex = 1;
            this.nya.Text = "NYA~~";
            this.nya.UseVisualStyleBackColor = true;
            this.nya.Click += new System.EventHandler(this.button1_Click);
            // 
            // dl
            // 
            this.dl.Location = new System.Drawing.Point(0, 82);
            this.dl.Name = "dl";
            this.dl.Size = new System.Drawing.Size(53, 185);
            this.dl.TabIndex = 3;
            this.dl.Text = "DL Nya";
            this.dl.UseVisualStyleBackColor = true;
            this.dl.Click += new System.EventHandler(this.dl_Click);
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(0, -1);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(53, 77);
            this.settings.TabIndex = 4;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // notifications
            // 
            this.notifications.AutoSize = true;
            this.notifications.Location = new System.Drawing.Point(437, 9);
            this.notifications.Name = "notifications";
            this.notifications.Size = new System.Drawing.Size(0, 13);
            this.notifications.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 568);
            this.Controls.Add(this.notifications);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.dl);
            this.Controls.Add(this.nya);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Nya~~";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button nya;
        private System.Windows.Forms.Button dl;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Label notifications;
    }
}

