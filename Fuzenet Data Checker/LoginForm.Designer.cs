namespace Fuzenet_Data_Checker
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resetPwdLabel = new System.Windows.Forms.LinkLabel();
            this.savePwdCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(45, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(46, 89);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(106, 62);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 5;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(106, 86);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '.';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 6;
            // 
            // loginBtn
            // 
            this.loginBtn.BackgroundImage = global::Fuzenet_Data_Checker.Properties.Resources.Login;
            this.loginBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loginBtn.Location = new System.Drawing.Point(235, 66);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(62, 39);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Fuzenet_Data_Checker.Properties.Resources.FuzeNet_Login;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(334, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // resetPwdLabel
            // 
            this.resetPwdLabel.AutoSize = true;
            this.resetPwdLabel.Location = new System.Drawing.Point(208, 118);
            this.resetPwdLabel.Name = "resetPwdLabel";
            this.resetPwdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.resetPwdLabel.Size = new System.Drawing.Size(114, 13);
            this.resetPwdLabel.TabIndex = 7;
            this.resetPwdLabel.TabStop = true;
            this.resetPwdLabel.Text = "Forgot your password?";
            this.resetPwdLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetPwdLabel_LinkClicked);
            // 
            // savePwdCheckBox
            // 
            this.savePwdCheckBox.AutoSize = true;
            this.savePwdCheckBox.Location = new System.Drawing.Point(49, 114);
            this.savePwdCheckBox.Name = "savePwdCheckBox";
            this.savePwdCheckBox.Size = new System.Drawing.Size(99, 17);
            this.savePwdCheckBox.TabIndex = 8;
            this.savePwdCheckBox.Text = "Save password";
            this.savePwdCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 140);
            this.Controls.Add(this.savePwdCheckBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.resetPwdLabel);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passwordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login to the Customer Portal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.LinkLabel resetPwdLabel;
        private System.Windows.Forms.CheckBox savePwdCheckBox;
    }
}