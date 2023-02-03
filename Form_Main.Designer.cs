namespace RA_Client
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_Exit = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_Icon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.timer_Database = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip_Icon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.Location = new System.Drawing.Point(338, 202);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 0;
            this.button_Exit.Text = "&Beenden";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Settings.Location = new System.Drawing.Point(12, 202);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(126, 23);
            this.button_Settings.TabIndex = 1;
            this.button_Settings.Text = "Einstellungen";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip_Icon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip_Icon
            // 
            this.contextMenuStrip_Icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Show,
            this.ToolStripMenuItem_Exit});
            this.contextMenuStrip_Icon.Name = "contextMenuStrip_Icon";
            this.contextMenuStrip_Icon.Size = new System.Drawing.Size(124, 48);
            // 
            // ToolStripMenuItem_Show
            // 
            this.ToolStripMenuItem_Show.Name = "ToolStripMenuItem_Show";
            this.ToolStripMenuItem_Show.Size = new System.Drawing.Size(123, 22);
            this.ToolStripMenuItem_Show.Text = "&Anzeigen";
            this.ToolStripMenuItem_Show.Click += new System.EventHandler(this.ToolStripMenuItem_Show_Click);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(123, 22);
            this.ToolStripMenuItem_Exit.Text = "&Beenden";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(12, 12);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(401, 184);
            this.webView21.Source = new System.Uri("file:///D:/Projekte/RedAlert/incident_01.html", System.UriKind.Absolute);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
            // 
            // timer_Database
            // 
            this.timer_Database.Interval = 1000;
            this.timer_Database.Tick += new System.EventHandler(this.Timer_Database_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 237);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.button_Settings);
            this.Controls.Add(this.button_Exit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedAlert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.contextMenuStrip_Icon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_Exit;
        private Button button_Settings;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip_Icon;
        private ToolStripMenuItem ToolStripMenuItem_Show;
        private ToolStripMenuItem ToolStripMenuItem_Exit;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private System.Windows.Forms.Timer timer_Database;
    }
}