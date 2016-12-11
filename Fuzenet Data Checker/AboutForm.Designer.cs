namespace Fuzenet_Data_Checker
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.HenryQuanBox = new System.Windows.Forms.PictureBox();
            this.emailLabel = new System.Windows.Forms.LinkLabel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.someTextlabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HenryQuanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HenryQuanBox
            // 
            this.HenryQuanBox.BackgroundImage = global::Fuzenet_Data_Checker.Properties.Resources.HenryQuan;
            this.HenryQuanBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HenryQuanBox.Location = new System.Drawing.Point(12, 12);
            this.HenryQuanBox.Name = "HenryQuanBox";
            this.HenryQuanBox.Size = new System.Drawing.Size(49, 48);
            this.HenryQuanBox.TabIndex = 0;
            this.HenryQuanBox.TabStop = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(101, 96);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(153, 13);
            this.emailLabel.TabIndex = 1;
            this.emailLabel.TabStop = true;
            this.emailLabel.Text = "E-mail: natequan@hotmail.com";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(86, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(140, 16);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Fuzenet Data Checker";
            // 
            // someTextlabel
            // 
            this.someTextlabel.Location = new System.Drawing.Point(9, 63);
            this.someTextlabel.Name = "someTextlabel";
            this.someTextlabel.Size = new System.Drawing.Size(245, 44);
            this.someTextlabel.TabIndex = 3;
            this.someTextlabel.Text = "This program is a quick way to check how much data you have left and it is only f" +
    "or Fuzenet customer.";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(197, 28);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(29, 15);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "v1.0";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 118);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.someTextlabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.HenryQuanBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About me";
            ((System.ComponentModel.ISupportInitialize)(this.HenryQuanBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox HenryQuanBox;
        private System.Windows.Forms.LinkLabel emailLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label someTextlabel;
        private System.Windows.Forms.Label versionLabel;
    }
}