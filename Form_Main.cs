using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

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
            Database.CheckForIncident();
        }

        private void Button_CheckForIncident_Click(object sender, EventArgs e)
        {
            (bool active, string _htmlFile) = Database.CheckForIncident();

            if (active)
            {

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

    }
}