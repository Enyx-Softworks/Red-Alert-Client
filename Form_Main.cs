using MySql.Data.MySqlClient;
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

        private void Timer_Database_Tick(object sender, EventArgs e)
        {
            Database.CheckForIncident();
        }

        private void Button_CheckForIncident_Click(object sender, EventArgs e)
        {
            (bool active, string _htmlFile) = Database.CheckForIncident();

            if (active)
            {
                timer_Icon.Enabled = true;

                Screen[] screens = Screen.AllScreens;

                if (appSettings.ShowOnAllMonitors == true)
                {
                    foreach (Screen screen in screens)
                    {
                        Form_Incident form_Incident = new()
                        {
                            Location = screen.WorkingArea.Location,
                            FormBorderStyle = FormBorderStyle.None,
                            TopMost = true,
                            WindowState = FormWindowState.Maximized
                        };

                        form_Incident.Show();

                        form_Incident.webView_Incident.Source = new Uri(_htmlFile);
                        form_Incident.webView_Incident.Update();
                    }
                }
                else
                {
                    Form_Incident form_Incident = new()
                    {
                        Location = screens[appSettings.MonitorNumber].WorkingArea.Location,
                        FormBorderStyle = FormBorderStyle.None,
                        TopMost = true,
                        WindowState = FormWindowState.Maximized
                    };

                    form_Incident.Show();

                    form_Incident.webView_Incident.Source = new Uri(_htmlFile);
                    //form_Incident.webView_Incident.CoreWebView2.IsMuted = !form_Incident.webView_Incident.CoreWebView2.IsMuted;

                    form_Incident.webView_Incident.Update();
                }

                if (appSettings.UnmuteOnAlert == true)
                {
                    // Force system wide unmute of audio
                    // SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                    // Multiple messages increase the volume
                    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);

                    StringBuilder sb = new();
                    string sFileName = Path.Combine(Application.CommonAppDataPath, "tas_red_alert.mp3");
                    string sAliasName = "MP3";

                    int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);
                    nRet = mciSendString("play " + sAliasName + " repeat", sb, 0, IntPtr.Zero);
                }
            }
            else
            {
                timer_Icon.Enabled = false;
                notifyIcon1.Icon = Helper.BytesToIcon(Properties.Resources.ra_icon);
                iconTimerStatus = true;
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