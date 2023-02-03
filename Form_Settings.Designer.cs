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
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Conn_Push_Server = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Push = new System.Windows.Forms.RadioButton();
            this.textBox_Conn_Pull_Server = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Pull = new System.Windows.Forms.RadioButton();
            this.textBox_Conn_DatabaseString = new System.Windows.Forms.TextBox();
            this.radioButton_Conn_Database = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Save.Location = new System.Drawing.Point(12, 251);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 1;
            this.button_Save.Text = "Speichern";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(250, 251);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 2;
            this.button_Close.Text = "Schließen";
            this.button_Close.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 210);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verbindungsart";
            // 
            // textBox_Conn_Push_Server
            // 
            this.textBox_Conn_Push_Server.Location = new System.Drawing.Point(34, 165);
            this.textBox_Conn_Push_Server.Name = "textBox_Conn_Push_Server";
            this.textBox_Conn_Push_Server.Size = new System.Drawing.Size(251, 23);
            this.textBox_Conn_Push_Server.TabIndex = 14;
            // 
            // radioButton_Conn_Push
            // 
            this.radioButton_Conn_Push.AutoSize = true;
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
            this.textBox_Conn_Pull_Server.Location = new System.Drawing.Point(34, 111);
            this.textBox_Conn_Pull_Server.Name = "textBox_Conn_Pull_Server";
            this.textBox_Conn_Pull_Server.Size = new System.Drawing.Size(251, 23);
            this.textBox_Conn_Pull_Server.TabIndex = 12;
            // 
            // radioButton_Conn_Pull
            // 
            this.radioButton_Conn_Pull.AutoSize = true;
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
            this.radioButton_Conn_Database.Location = new System.Drawing.Point(15, 32);
            this.radioButton_Conn_Database.Name = "radioButton_Conn_Database";
            this.radioButton_Conn_Database.Size = new System.Drawing.Size(82, 19);
            this.radioButton_Conn_Database.TabIndex = 9;
            this.radioButton_Conn_Database.TabStop = true;
            this.radioButton_Conn_Database.Text = "Datenbank";
            this.radioButton_Conn_Database.UseVisualStyleBackColor = true;
            this.radioButton_Conn_Database.CheckedChanged += new System.EventHandler(this.RadioButton_Conn_Database_CheckedChanged);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 286);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Save);
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
    }
}