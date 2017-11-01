namespace Forms
{
    partial class Setup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
            this.SetupPanel = new System.Windows.Forms.Panel();
            this.CloseLink = new System.Windows.Forms.LinkLabel();
            this.StatusBox = new System.Windows.Forms.Label();
            this.FormLabel = new System.Windows.Forms.Label();
            this.PtNoBox = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.IPvXBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.SetupPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetupPanel
            // 
            this.SetupPanel.BackColor = System.Drawing.Color.Black;
            this.SetupPanel.Controls.Add(this.CloseLink);
            this.SetupPanel.Controls.Add(this.StatusBox);
            this.SetupPanel.Controls.Add(this.FormLabel);
            this.SetupPanel.Controls.Add(this.PtNoBox);
            this.SetupPanel.Controls.Add(this.IPLabel);
            this.SetupPanel.Controls.Add(this.IPvXBox);
            this.SetupPanel.Controls.Add(this.PortLabel);
            this.SetupPanel.Controls.Add(this.ConnectBtn);
            this.SetupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupPanel.Location = new System.Drawing.Point(8, 8);
            this.SetupPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SetupPanel.Name = "SetupPanel";
            this.SetupPanel.Size = new System.Drawing.Size(234, 334);
            this.SetupPanel.TabIndex = 9;
            // 
            // CloseLink
            // 
            this.CloseLink.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.CloseLink.BackColor = System.Drawing.Color.Transparent;
            this.CloseLink.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CloseLink.ForeColor = System.Drawing.Color.Silver;
            this.CloseLink.LinkColor = System.Drawing.Color.Silver;
            this.CloseLink.Location = new System.Drawing.Point(90, 247);
            this.CloseLink.MaximumSize = new System.Drawing.Size(55, 13);
            this.CloseLink.MinimumSize = new System.Drawing.Size(55, 13);
            this.CloseLink.Name = "CloseLink";
            this.CloseLink.Size = new System.Drawing.Size(55, 13);
            this.CloseLink.TabIndex = 16;
            this.CloseLink.TabStop = true;
            this.CloseLink.Text = "Unlock";
            this.CloseLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseLink.VisitedLinkColor = System.Drawing.Color.SkyBlue;
            // 
            // StatusBox
            // 
            this.StatusBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.StatusBox.Location = new System.Drawing.Point(2, 271);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(230, 60);
            this.StatusBox.TabIndex = 15;
            this.StatusBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLabel
            // 
            this.FormLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FormLabel.Font = new System.Drawing.Font("Arial", 15F);
            this.FormLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FormLabel.Location = new System.Drawing.Point(67, 30);
            this.FormLabel.Name = "FormLabel";
            this.FormLabel.Size = new System.Drawing.Size(100, 25);
            this.FormLabel.TabIndex = 14;
            this.FormLabel.Text = "Setup";
            this.FormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PtNoBox
            // 
            this.PtNoBox.BackColor = System.Drawing.Color.Black;
            this.PtNoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PtNoBox.Font = new System.Drawing.Font("Arial", 9F);
            this.PtNoBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.PtNoBox.Location = new System.Drawing.Point(77, 157);
            this.PtNoBox.Name = "PtNoBox";
            this.PtNoBox.Size = new System.Drawing.Size(80, 21);
            this.PtNoBox.TabIndex = 13;
            this.PtNoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PtNoBox.WordWrap = false;
            this.PtNoBox.TextChanged += new System.EventHandler(this.PtNoBox_TextChanged);
            this.PtNoBox.Validated += new System.EventHandler(this.PtNoBox_Validated);
            // 
            // IPLabel
            // 
            this.IPLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.IPLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.IPLabel.Location = new System.Drawing.Point(72, 90);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(90, 15);
            this.IPLabel.TabIndex = 12;
            this.IPLabel.Text = "IPv4 | IPv6";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IPvXBox
            // 
            this.IPvXBox.BackColor = System.Drawing.Color.Black;
            this.IPvXBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IPvXBox.ForeColor = System.Drawing.Color.DodgerBlue;
            this.IPvXBox.Location = new System.Drawing.Point(62, 108);
            this.IPvXBox.Margin = new System.Windows.Forms.Padding(0);
            this.IPvXBox.Name = "IPvXBox";
            this.IPvXBox.Size = new System.Drawing.Size(110, 21);
            this.IPvXBox.TabIndex = 11;
            this.IPvXBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPvXBox.WordWrap = false;
            // 
            // PortLabel
            // 
            this.PortLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.PortLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.PortLabel.Location = new System.Drawing.Point(72, 139);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(90, 15);
            this.PortLabel.TabIndex = 10;
            this.PortLabel.Text = "Port";
            this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.Black;
            this.ConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ConnectBtn.Location = new System.Drawing.Point(78, 201);
            this.ConnectBtn.MaximumSize = new System.Drawing.Size(78, 35);
            this.ConnectBtn.MinimumSize = new System.Drawing.Size(78, 35);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(78, 35);
            this.ConnectBtn.TabIndex = 9;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseMnemonic = false;
            this.ConnectBtn.UseVisualStyleBackColor = false;
            // 
            // Setup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 350);
            this.Controls.Add(this.SetupPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(250, 350);
            this.MinimumSize = new System.Drawing.Size(250, 350);
            this.Name = "Setup";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.TopMost = true;
            this.SetupPanel.ResumeLayout(false);
            this.SetupPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SetupPanel;
        private System.Windows.Forms.LinkLabel CloseLink;
        private System.Windows.Forms.Label StatusBox;
        private System.Windows.Forms.Label FormLabel;
        private System.Windows.Forms.TextBox PtNoBox;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox IPvXBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Button ConnectBtn;
    }
}