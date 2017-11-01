namespace Forms
{
    partial class Login

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.StatusBox = new System.Windows.Forms.Label();
            this.CloseLnk = new System.Windows.Forms.LinkLabel();
            this.FormLabel = new System.Windows.Forms.Label();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.UserBox = new System.Windows.Forms.TextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.Black;
            this.LoginPanel.Controls.Add(this.StatusBox);
            this.LoginPanel.Controls.Add(this.CloseLnk);
            this.LoginPanel.Controls.Add(this.FormLabel);
            this.LoginPanel.Controls.Add(this.PassBox);
            this.LoginPanel.Controls.Add(this.PassLabel);
            this.LoginPanel.Controls.Add(this.UserBox);
            this.LoginPanel.Controls.Add(this.KeyLabel);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.ForeColor = System.Drawing.Color.Black;
            this.LoginPanel.Location = new System.Drawing.Point(8, 8);
            this.LoginPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(234, 334);
            this.LoginPanel.TabIndex = 0;
            // 
            // StatusBox
            // 
            this.StatusBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatusBox.Location = new System.Drawing.Point(2, 271);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(230, 60);
            this.StatusBox.TabIndex = 14;
            this.StatusBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseLnk
            // 
            this.CloseLnk.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.CloseLnk.BackColor = System.Drawing.Color.Transparent;
            this.CloseLnk.CausesValidation = false;
            this.CloseLnk.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseLnk.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CloseLnk.LinkColor = System.Drawing.Color.Silver;
            this.CloseLnk.Location = new System.Drawing.Point(90, 247);
            this.CloseLnk.MaximumSize = new System.Drawing.Size(55, 13);
            this.CloseLnk.MinimumSize = new System.Drawing.Size(55, 13);
            this.CloseLnk.Name = "CloseLnk";
            this.CloseLnk.Size = new System.Drawing.Size(55, 13);
            this.CloseLnk.TabIndex = 15;
            this.CloseLnk.TabStop = true;
            this.CloseLnk.Text = "Cancel";
            this.CloseLnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLnk.VisitedLinkColor = System.Drawing.Color.SkyBlue;
            this.CloseLnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CloseLnk_Click);
            // 
            // FormLabel
            // 
            this.FormLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FormLabel.Font = new System.Drawing.Font("Arial", 15F);
            this.FormLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FormLabel.Location = new System.Drawing.Point(67, 30);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(100, 25);
            this.FormLabel.TabIndex = 13;
            this.FormLabel.Text = "Login";
            this.FormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PassBox
            // 
            this.PassBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.PassBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassBox.Font = new System.Drawing.Font("Arial", 9F);
            this.PassBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PassBox.Location = new System.Drawing.Point(67, 157);
            this.PassBox.MaximumSize = new System.Drawing.Size(100, 21);
            this.PassBox.MaxLength = 16;
            this.PassBox.MinimumSize = new System.Drawing.Size(100, 21);
            this.PassBox.Name = "PassBox";
            this.PassBox.ShortcutsEnabled = false;
            this.PassBox.Size = new System.Drawing.Size(100, 21);
            this.PassBox.TabIndex = 12;
            this.PassBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PassBox.UseSystemPasswordChar = true;
            this.PassBox.WordWrap = false;
            // 
            // PassLabel
            // 
            this.PassLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PassLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.PassLabel.Location = new System.Drawing.Point(72, 90);
            this.PassLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(90, 15);
            this.PassLabel.TabIndex = 11;
            this.PassLabel.Text = "Username";
            this.PassLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserBox
            // 
            this.UserBox.BackColor = System.Drawing.SystemColors.WindowText;
            this.UserBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.UserBox.Location = new System.Drawing.Point(62, 108);
            this.UserBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserBox.MaxLength = 16;
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(110, 21);
            this.UserBox.TabIndex = 10;
            this.UserBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserBox.WordWrap = false;
            // 
            // KeyLabel
            // 
            this.KeyLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.KeyLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.KeyLabel.Location = new System.Drawing.Point(87, 139);
            this.KeyLabel.MaximumSize = new System.Drawing.Size(60, 15);
            this.KeyLabel.MinimumSize = new System.Drawing.Size(60, 15);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(60, 15);
            this.KeyLabel.TabIndex = 9;
            this.KeyLabel.Text = "Password";
            this.KeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(78, 201);
            this.LoginButton.MaximumSize = new System.Drawing.Size(78, 35);
            this.LoginButton.MinimumSize = new System.Drawing.Size(78, 35);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(78, 35);
            this.LoginButton.TabIndex = 8;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.Login_Click);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 350);
            this.Controls.Add(this.LoginPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(250, 350);
            this.MinimumSize = new System.Drawing.Size(250, 350);
            this.Name = "Login";
            this.Opacity = 0.8D;
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.LinkLabel CloseLnk;
        private System.Windows.Forms.Label StatusBox;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Button LoginButton;
    }
}