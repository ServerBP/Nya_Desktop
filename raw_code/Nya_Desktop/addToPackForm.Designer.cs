namespace Nya_Desktop
{
    partial class addToPackForm
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
            this.cancel = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.packSelectionbox = new System.Windows.Forms.ComboBox();
            this.createNew = new System.Windows.Forms.Button();
            this.packName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(296, 15);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 28);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(296, 266);
            this.add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(100, 28);
            this.add.TabIndex = 1;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // packSelectionbox
            // 
            this.packSelectionbox.FormattingEnabled = true;
            this.packSelectionbox.Location = new System.Drawing.Point(17, 16);
            this.packSelectionbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.packSelectionbox.Name = "packSelectionbox";
            this.packSelectionbox.Size = new System.Drawing.Size(269, 24);
            this.packSelectionbox.TabIndex = 2;
            // 
            // createNew
            // 
            this.createNew.Location = new System.Drawing.Point(296, 209);
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(100, 50);
            this.createNew.TabIndex = 3;
            this.createNew.Text = "Create New Pack";
            this.createNew.UseVisualStyleBackColor = true;
            this.createNew.Click += new System.EventHandler(this.createNew_Click);
            // 
            // packName
            // 
            this.packName.Location = new System.Drawing.Point(13, 236);
            this.packName.Name = "packName";
            this.packName.Size = new System.Drawing.Size(273, 22);
            this.packName.TabIndex = 4;
            this.packName.Text = "enter pack name here";
            this.packName.Visible = false;
            // 
            // addToPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 309);
            this.Controls.Add(this.packName);
            this.Controls.Add(this.createNew);
            this.Controls.Add(this.packSelectionbox);
            this.Controls.Add(this.add);
            this.Controls.Add(this.cancel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "addToPackForm";
            this.Text = "addToPackForm";
            this.Load += new System.EventHandler(this.addToPackForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox packSelectionbox;
        private System.Windows.Forms.Button createNew;
        private System.Windows.Forms.TextBox packName;
    }
}