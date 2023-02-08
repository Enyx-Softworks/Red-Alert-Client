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
            this.timer_Incident = new System.Windows.Forms.Timer(this.components);
            this.button_CheckForIncident = new System.Windows.Forms.Button();
            this.timer_Icon = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip_Icon.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Exit
            // 
            this.button_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Exit.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Exit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Exit.Location = new System.Drawing.Point(338, 190);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 35);
            this.button_Exit.TabIndex = 0;
            this.button_Exit.Text = "&Beenden";
            this.button_Exit.UseVisualStyleBackColor = false;
            this.button_Exit.Click += new System.EventHandler(this.Button_Exit_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Settings.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Settings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Settings.Location = new System.Drawing.Point(12, 190);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(126, 35);
            this.button_Settings.TabIndex = 1;
            this.button_Settings.Text = "Einstellungen";
            this.button_Settings.UseVisualStyleBackColor = false;
            this.button_Settings.Click += new System.EventHandler(this.Button_Settings_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip_Icon;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);
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
            // timer_Incident
            // 
            this.timer_Incident.Enabled = true;
            this.timer_Incident.Interval = 1000;
            this.timer_Incident.Tick += new System.EventHandler(this.Timer_Incident_Tick);
            // 
            // button_CheckForIncident
            // 
            this.button_CheckForIncident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_CheckForIncident.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button_CheckForIncident.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_CheckForIncident.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_CheckForIncident.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_CheckForIncident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CheckForIncident.Location = new System.Drawing.Point(160, 71);
            this.button_CheckForIncident.Name = "button_CheckForIncident";
            this.button_CheckForIncident.Size = new System.Drawing.Size(126, 35);
            this.button_CheckForIncident.TabIndex = 3;
            this.button_CheckForIncident.Text = "Check";
            this.button_CheckForIncident.UseVisualStyleBackColor = false;
            this.button_CheckForIncident.Click += new System.EventHandler(this.Button_CheckForIncident_Click);
            // 
            // timer_Icon
            // 
            this.timer_Icon.Tick += new System.EventHandler(this.Timer_Icon_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(425, 237);
            this.Controls.Add(this.button_CheckForIncident);
            this.Controls.Add(this.button_Settings);
            this.Controls.Add(this.button_Exit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RedAlert - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            this.contextMenuStrip_Icon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button_Exit;
        private Button button_Settings;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip_Icon;
        private ToolStripMenuItem ToolStripMenuItem_Show;
        private ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.Timer timer_Incident;
        private Button button_CheckForIncident;
        public System.Windows.Forms.Timer timer_Icon;
    }
}