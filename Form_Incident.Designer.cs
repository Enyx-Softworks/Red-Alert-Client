namespace RA_Client
{
    partial class Form_Incident
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
            this.webView_Incident = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.pictureBox_Audio = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.webView_Incident)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Audio)).BeginInit();
            this.SuspendLayout();
            // 
            // webView_Incident
            // 
            this.webView_Incident.AllowExternalDrop = true;
            this.webView_Incident.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView_Incident.CreationProperties = null;
            this.webView_Incident.DefaultBackgroundColor = System.Drawing.Color.Transparent;
            this.webView_Incident.Location = new System.Drawing.Point(12, 12);
            this.webView_Incident.Name = "webView_Incident";
            this.webView_Incident.Size = new System.Drawing.Size(347, 284);
            this.webView_Incident.TabIndex = 3;
            this.webView_Incident.ZoomFactor = 1D;
            // 
            // pictureBox_Audio
            // 
            this.pictureBox_Audio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_Audio.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Audio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox_Audio.ErrorImage = null;
            this.pictureBox_Audio.Image = global::RA_Client.Properties.Resources.speaker_active_white;
            this.pictureBox_Audio.InitialImage = null;
            this.pictureBox_Audio.Location = new System.Drawing.Point(291, 236);
            this.pictureBox_Audio.Name = "pictureBox_Audio";
            this.pictureBox_Audio.Size = new System.Drawing.Size(68, 60);
            this.pictureBox_Audio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Audio.TabIndex = 4;
            this.pictureBox_Audio.TabStop = false;
            this.pictureBox_Audio.Click += new System.EventHandler(this.PictureBox_Audio_Click);
            // 
            // Form_Incident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 308);
            this.Controls.Add(this.pictureBox_Audio);
            this.Controls.Add(this.webView_Incident);
            this.Name = "Form_Incident";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incident";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Incident_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.webView_Incident)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Audio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Web.WebView2.WinForms.WebView2 webView_Incident;
        private PictureBox pictureBox_Audio;
    }
}