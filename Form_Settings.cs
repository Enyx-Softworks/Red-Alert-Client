using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RA_Client
{
    public partial class Form_Settings : Form
    {
        public Form_Settings()
        {
            InitializeComponent();
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            Settings.LoadSettings();

            if (Form_Main.appSettings.ConnectionType == "Database")
                radioButton_Conn_Database.Checked = true;
            else if (Form_Main.appSettings.ConnectionType == "Pull")
                radioButton_Conn_Database.Checked = true;
            else if (Form_Main.appSettings.ConnectionType == "Push")
                radioButton_Conn_Database.Checked = true;

            textBox_Conn_DatabaseString.Text = Form_Main.appSettings.DatabaseServer;
            textBox_Conn_Pull_Server.Text = Form_Main.appSettings.PullServer;
            textBox_Conn_Push_Server.Text = Form_Main.appSettings.PushServer;
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (radioButton_Conn_Database.Checked)
                Form_Main.appSettings.ConnectionType = "Database";
            else if (radioButton_Conn_Pull.Checked)
                Form_Main.appSettings.ConnectionType = "Pull";
            else if (radioButton_Conn_Push.Checked)
                Form_Main.appSettings.ConnectionType = "Push";

            Form_Main.appSettings.DatabaseServer = textBox_Conn_DatabaseString.Text;
            Form_Main.appSettings.PullServer = textBox_Conn_Pull_Server.Text;
            Form_Main.appSettings.PushServer = textBox_Conn_Push_Server.Text;

            Settings.SaveSettings(Form_Main.appSettings);
        }

        private void RadioButton_Conn_Database_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Conn_DatabaseString.Enabled = radioButton_Conn_Database.Checked;
            textBox_Conn_Pull_Server.Enabled = radioButton_Conn_Pull.Checked;
            textBox_Conn_Push_Server.Enabled = radioButton_Conn_Push.Checked;
        }

        private void RadioButton_Conn_Pull_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Conn_DatabaseString.Enabled = radioButton_Conn_Database.Checked;
            textBox_Conn_Pull_Server.Enabled = radioButton_Conn_Pull.Checked;
            textBox_Conn_Push_Server.Enabled = radioButton_Conn_Push.Checked;
        }

        private void RadioButton_Conn_Push_CheckedChanged(object sender, EventArgs e)
        {
            textBox_Conn_DatabaseString.Enabled = radioButton_Conn_Database.Checked;
            textBox_Conn_Pull_Server.Enabled = radioButton_Conn_Pull.Checked;
            textBox_Conn_Push_Server.Enabled = radioButton_Conn_Push.Checked;
        }
    }
}
