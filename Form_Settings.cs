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

            checkBox_ShowOnAllMonitors.Checked = Form_Main.appSettings.ShowOnAllMonitors;

            Screen[] screens = Screen.AllScreens;
            numericUpDown_MonitorNumber.Maximum = screens.Length - 1;
            numericUpDown_MonitorNumber.Value = Form_Main.appSettings.MonitorNumber;

            checkBox_StartMinimized.Checked = Form_Main.appSettings.StartMinimized;
            checkBox_UnmuteOnAlert.Checked = Form_Main.appSettings.UnmuteOnAlert;

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
            Form_Main.appSettings.ShowOnAllMonitors = checkBox_ShowOnAllMonitors.Checked;
            Form_Main.appSettings.MonitorNumber = (int)numericUpDown_MonitorNumber.Value;
            Form_Main.appSettings.StartMinimized = checkBox_StartMinimized.Checked;
            Form_Main.appSettings.UnmuteOnAlert = checkBox_UnmuteOnAlert.Checked;

            Settings.SaveSettings(Form_Main.appSettings);

            Button_Close_Click(sender, e);
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

        private void CheckBox_ShowOnAllMonitors_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown_MonitorNumber.Enabled = !checkBox_ShowOnAllMonitors.Checked;
        }
    }
}
