namespace RA_Client
{
    partial class Form_Settings
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
            this.components = new System.ComponentModel.Container();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Conn_Push_Server = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Push = new System.Windows.Forms.RadioButton();
            this.textBox_Conn_Pull_Server = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Pull = new System.Windows.Forms.RadioButton();
            this.textBox_Conn_DatabaseString = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Database = new System.Windows.Forms.RadioButton();
            this.checkBox_ShowOnAllMonitors = new System.Windows.Forms.CheckBox();
            this.numericUpDown_MonitorNumber = new System.Windows.Forms.NumericUpDown();
            this.checkBox_StartMinimized = new System.Windows.Forms.CheckBox();
            this.checkBox_UnmuteOnAlert = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MonitorNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Save.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Location = new System.Drawing.Point(12, 399);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(85, 35);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Speichern";
            this.button_Save.UseVisualStyleBackColor = false;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(236, 399);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(85, 35);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Schließen";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Conn_Push_Server);
            this.groupBox1.Controls.Add(this.radioButton_Conn_Push);
            this.groupBox1.Controls.Add(this.textBox_Conn_Pull_Server);
            this.groupBox1.Controls.Add(this.radioButton_Conn_Pull);
            this.groupBox1.Controls.Add(this.textBox_Conn_DatabaseString);
            this.groupBox1.Controls.Add(this.radioButton_Conn_Database);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 210);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verbindungsart";
            // 
            // textBox_Conn_Push_Server
            // 
            this.textBox_Conn_Push_Server.Enabled = false;
            this.textBox_Conn_Push_Server.Location = new System.Drawing.Point(34, 165);
            this.textBox_Conn_Push_Server.Name = "textBox_Conn_Push_Server";
            this.textBox_Conn_Push_Server.Size = new System.Drawing.Size(251, 23);
            this.textBox_Conn_Push_Server.TabIndex = 14;
            // 
            // radioButton_Conn_Push
            // 
            this.radioButton_Conn_Push.AutoSize = true;
            this.radioButton_Conn_Push.Enabled = false;
            this.radioButton_Conn_Push.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton_Conn_Push.Location = new System.Drawing.Point(15, 140);
            this.radioButton_Conn_Push.Name = "radioButton_Conn_Push";
            this.radioButton_Conn_Push.Size = new System.Drawing.Size(140, 19);
            this.radioButton_Conn_Push.TabIndex = 13;
            this.radioButton_Conn_Push.TabStop = true;
            this.radioButton_Conn_Push.Text = "Push durch RA-Server";
            this.radioButton_Conn_Push.UseVisualStyleBackColor = true;
            this.radioButton_Conn_Push.CheckedChanged += new System.EventHandler(this.RadioButton_Conn_Push_CheckedChanged);
            // 
            // textBox_Conn_Pull_Server
            // 
            this.textBox_Conn_Pull_Server.Enabled = false;
            this.textBox_Conn_Pull_Server.Location = new System.Drawing.Point(34, 111);
            this.textBox_Conn_Pull_Server.Name = "textBox_Conn_Pull_Server";
            this.textBox_Conn_Pull_Server.Size = new System.Drawing.Size(251, 23);
            this.textBox_Conn_Pull_Server.TabIndex = 12;
            // 
            // radioButton_Conn_Pull
            // 
            this.radioButton_Conn_Pull.AutoSize = true;
            this.radioButton_Conn_Pull.Enabled = false;
            this.radioButton_Conn_Pull.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton_Conn_Pull.Location = new System.Drawing.Point(15, 86);
            this.radioButton_Conn_Pull.Name = "radioButton_Conn_Pull";
            this.radioButton_Conn_Pull.Size = new System.Drawing.Size(123, 19);
            this.radioButton_Conn_Pull.TabIndex = 11;
            this.radioButton_Conn_Pull.TabStop = true;
            this.radioButton_Conn_Pull.Text = "Pull von RA-Server";
            this.radioButton_Conn_Pull.UseVisualStyleBackColor = true;
            this.radioButton_Conn_Pull.CheckedChanged += new System.EventHandler(this.RadioButton_Conn_Pull_CheckedChanged);
            // 
            // textBox_Conn_DatabaseString
            // 
            this.textBox_Conn_DatabaseString.Location = new System.Drawing.Point(34, 57);
            this.textBox_Conn_DatabaseString.Name = "textBox_Conn_DatabaseString";
            this.textBox_Conn_DatabaseString.Size = new System.Drawing.Size(251, 23);
            this.textBox_Conn_DatabaseString.TabIndex = 10;
            // 
            // radioButton_Conn_Database
            // 
            this.radioButton_Conn_Database.AutoSize = true;
            this.radioButton_Conn_Database.ForeColor = System.Drawing.SystemColors.Control;
            this.radioButton_Conn_Database.Location = new System.Drawing.Point(15, 32);
            this.radioButton_Conn_Database.Name = "radioButton_Conn_Database";
            this.radioButton_Conn_Database.Size = new System.Drawing.Size(82, 19);
            this.radioButton_Conn_Database.TabIndex = 9;
            this.radioButton_Conn_Database.TabStop = true;
            this.radioButton_Conn_Database.Text = "Datenbank";
            this.radioButton_Conn_Database.UseVisualStyleBackColor = true;
            this.radioButton_Conn_Database.CheckedChanged += new System.EventHandler(this.RadioButton_Conn_Database_CheckedChanged);
            // 
            // checkBox_ShowOnAllMonitors
            // 
            this.checkBox_ShowOnAllMonitors.AutoSize = true;
            this.checkBox_ShowOnAllMonitors.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox_ShowOnAllMonitors.Location = new System.Drawing.Point(26, 255);
            this.checkBox_ShowOnAllMonitors.Name = "checkBox_ShowOnAllMonitors";
            this.checkBox_ShowOnAllMonitors.Size = new System.Drawing.Size(215, 19);
            this.checkBox_ShowOnAllMonitors.TabIndex = 10;
            this.checkBox_ShowOnAllMonitors.Text = "Alarm auf allen Monitoren anzeigen";
            this.toolTip1.SetToolTip(this.checkBox_ShowOnAllMonitors, "Die Alarm-Meldung auf allen verfügbaren Monitoren anzeigen oder nur auf einem bes" +
        "timmten Monitor. Monitor \"0\" ist die Haupt-Anzeige.");
            this.checkBox_ShowOnAllMonitors.UseVisualStyleBackColor = true;
            this.checkBox_ShowOnAllMonitors.CheckedChanged += new System.EventHandler(this.CheckBox_ShowOnAllMonitors_CheckedChanged);
            // 
            // numericUpDown_MonitorNumber
            // 
            this.numericUpDown_MonitorNumber.Location = new System.Drawing.Point(46, 280);
            this.numericUpDown_MonitorNumber.Name = "numericUpDown_MonitorNumber";
            this.numericUpDown_MonitorNumber.Size = new System.Drawing.Size(41, 23);
            this.numericUpDown_MonitorNumber.TabIndex = 11;
            // 
            // checkBox_StartMinimized
            // 
            this.checkBox_StartMinimized.AutoSize = true;
            this.checkBox_StartMinimized.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox_StartMinimized.Location = new System.Drawing.Point(26, 322);
            this.checkBox_StartMinimized.Name = "checkBox_StartMinimized";
            this.checkBox_StartMinimized.Size = new System.Drawing.Size(117, 19);
            this.checkBox_StartMinimized.TabIndex = 12;
            this.checkBox_StartMinimized.Text = "Minimiert starten";
            this.toolTip1.SetToolTip(this.checkBox_StartMinimized, "Das Programm beim Starten in minimierter Form, also nur in der Taskleiste sichtba" +
        "r, starten.");
            this.checkBox_StartMinimized.UseVisualStyleBackColor = true;
            // 
            // checkBox_UnmuteOnAlert
            // 
            this.checkBox_UnmuteOnAlert.AutoSize = true;
            this.checkBox_UnmuteOnAlert.ForeColor = System.Drawing.SystemColors.Control;
            this.checkBox_UnmuteOnAlert.Location = new System.Drawing.Point(26, 347);
            this.checkBox_UnmuteOnAlert.Name = "checkBox_UnmuteOnAlert";
            this.checkBox_UnmuteOnAlert.Size = new System.Drawing.Size(261, 19);
            this.checkBox_UnmuteOnAlert.TabIndex = 13;
            this.checkBox_UnmuteOnAlert.Text = "Audio-Stummschaltung aufheben bei Alarm";
            this.toolTip1.SetToolTip(this.checkBox_UnmuteOnAlert, "Beim Ausführen einer Alarm-Meldung die Stummschaltung der aktuell eingestellten L" +
        "autsprecher automatisch aufheben.");
            this.checkBox_UnmuteOnAlert.UseVisualStyleBackColor = true;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(337, 446);
            this.Controls.Add(this.checkBox_UnmuteOnAlert);
            this.Controls.Add(this.checkBox_StartMinimized);
            this.Controls.Add(this.numericUpDown_MonitorNumber);
            this.Controls.Add(this.checkBox_ShowOnAllMonitors);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Save);
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MonitorNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button_Save;
        private Button button_Close;
        private GroupBox groupBox1;
        private TextBox textBox_Conn_Push_Server;
        private RadioButton radioButton_Conn_Push;
        private TextBox textBox_Conn_Pull_Server;
        private RadioButton radioButton_Conn_Pull;
        private TextBox textBox_Conn_DatabaseString;
        private RadioButton radioButton_Conn_Database;
        private CheckBox checkBox_ShowOnAllMonitors;
        private NumericUpDown numericUpDown_MonitorNumber;
        private CheckBox checkBox_StartMinimized;
        private CheckBox checkBox_UnmuteOnAlert;
        private ToolTip toolTip1;
    }
}