using MySql.Data.MySqlClient;
using RA_Client.Models;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static RA_Client.Helper;
using static RA_Client.Program;

namespace RA_Client
{
    public partial class Form_Main : Form
    {
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static Settings appSettings = new();
        public static string workstationName = "";
        public static string workstationIp = "";
        public static string windowsUser = "";
        public static ADUser? adUser = null;
        public static bool audioMuted = false;

        public bool iconTimerStatus = false;
        public bool incidentsActive = false;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Text = Assembly.GetExecutingAssembly().GetName().Name + " (v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
            notifyIcon1.Text = Text;

            Settings.LoadSettings();

            workstationName = Helper.GetMachineName();
            workstationIp = Helper.GetMachineIp();
            windowsUser = Helper.GetWindowsUser();
            adUser = Helper.GetADUser();

            // Register workstation at server
            Database.RegisterClientOnServer(workstationName, workstationIp, windowsUser);

        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Unregister workstation from server
            Database.UnregisterClientOnServer(workstationName, workstationIp);

            // Remove temporary files
            Helper.RemoveTempFiles();

            notifyIcon1.Dispose();
        }

        private void Form_Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            BringToFront();
            Focus();
        }

        /// <summary>
        /// Override for WndProc to receive a custom message
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                NotifyIcon1_DoubleClick(this, new EventArgs());
            }
            base.WndProc(ref m);
        }

        private void ToolStripMenuItem_Show_Click(object sender, EventArgs e)
        {
            NotifyIcon1_DoubleClick(sender, e);
        }

        private void ToolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new();
            if (form_Settings.ShowDialog() == DialogResult.OK)
                Settings.LoadSettings();
        }

        private void Timer_Incident_Tick(object sender, EventArgs e)
        {
            if (incidentsActive == false)
            {
                incidentsActive = true;
                List<Incident> _incidentList = Helper.GetIncidents();
                if (_incidentList.Count > 0)
                {
                    Helper.ShowIncidents(this, _incidentList);
                }
            }
        }

        private void Button_CheckForIncident_Click(object sender, EventArgs e)
        {
            List<Incident> _incidentList = Helper.GetIncidents();

            if (_incidentList.Count > 0)
            {
                incidentsActive = true;
                Helper.ShowIncidents(this, _incidentList);
            }
            else
            {
                timer_Icon.Enabled = false;
                notifyIcon1.Icon = Helper.BytesToIcon(Properties.Resources.ra_icon);
                iconTimerStatus = true;
                incidentsActive = false;
            }
        }

        private void Timer_Icon_Tick(object sender, EventArgs e)
        {
            if (iconTimerStatus == true)
            {
                notifyIcon1.Icon = Helper.BytesToIcon(Properties.Resources.ra_icon);
            }
            else
            {
                notifyIcon1.Icon = Helper.BytesToIcon(Properties.Resources.ra_icon_white);
            }

            iconTimerStatus = !iconTimerStatus;
        }


    }
}