using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;

namespace RA_Client
{
    public partial class Form_Main : Form
    {
        public static Settings appSettings = new();
        public static string workstationName = "";
        public static string workstationIp = "";

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Settings.LoadSettings();

            workstationName = Environment.MachineName;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    workstationIp = ipAddress.ToString();
                    break;
                }
            }

            // Register workstation at server
            Database.RegisterClientOnServer(workstationName, workstationIp);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unregister workstation from server
            Database.UnregisterClientOnServer(workstationName, workstationIp);

            notifyIcon1.Dispose();
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Focus();
        }

        private void ToolStripMenuItem_Show_Click(object sender, EventArgs e)
        {
            NotifyIcon1_DoubleClick(sender, e);
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new();
            form_Settings.ShowDialog();
        }

        private void Timer_Database_Tick(object sender, EventArgs e)
        {

        }
    }
}