namespace Nya_Desktop
{
    partial class notification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notification));
            this.notif_text = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notif_text
            // 
            this.notif_text.AutoEllipsis = true;
            this.notif_text.Location = new System.Drawing.Point(0, 29);
            this.notif_text.Name = "notif_text";
            this.notif_text.Size = new System.Drawing.Size(308, 125);
            this.notif_text.TabIndex = 0;
            this.notif_text.Text = "aa";
            // 
            // cancel
            // 
            this.cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancel.Location = new System.Drawing.Point(0, 3);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Close";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // update
            // 
            this.update.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.update.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.update.Location = new System.Drawing.Point(0, 157);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(308, 30);
            this.update.TabIndex = 2;
            this.update.Text = "Update Now";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // notification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 187);
            this.Controls.Add(this.update);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.notif_text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "notification";
            this.Text = "New Notification!";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.notification_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label notif_text;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button update;
    }
}