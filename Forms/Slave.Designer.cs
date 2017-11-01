namespace Forms
{
    partial class Slave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Slave));
            this.TimerPanel = new System.Windows.Forms.Panel();
            this.TimerTxt = new System.Windows.Forms.Label();
            this.TimerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerPanel
            // 
            this.TimerPanel.BackColor = System.Drawing.Color.Black;
            this.TimerPanel.Controls.Add(this.TimerTxt);
            this.TimerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerPanel.ForeColor = System.Drawing.Color.Black;
            this.TimerPanel.Location = new System.Drawing.Point(8, 8);
            this.TimerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TimerPanel.Name = "TimerPanel";
            this.TimerPanel.Size = new System.Drawing.Size(265, 73);
            this.TimerPanel.TabIndex = 1;
            // 
            // TimerTxt
            // 
            this.TimerTxt.AutoEllipsis = true;
            this.TimerTxt.BackColor = System.Drawing.Color.Black;
            this.TimerTxt.CausesValidation = false;
            this.TimerTxt.Cursor = System.Windows.Forms.Cursors.Default;
            this.TimerTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimerTxt.Font = new System.Drawing.Font("Arial Black", 38F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerTxt.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TimerTxt.Location = new System.Drawing.Point(0, 0);
            this.TimerTxt.Margin = new System.Windows.Forms.Padding(0);
            this.TimerTxt.Name = "TimerTxt";
            this.TimerTxt.Size = new System.Drawing.Size(265, 73);
            this.TimerTxt.TabIndex = 5;
            this.TimerTxt.Text = "00:00:00";
            this.TimerTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TimerTxt.UseMnemonic = false;
            // 
            // Slave
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(281, 89);
            this.ControlBox = false;
            this.Controls.Add(this.TimerPanel);
            this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Slave";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Slave";
            this.TimerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TimerPanel;
        private System.Windows.Forms.Label TimerTxt;
    }
}

