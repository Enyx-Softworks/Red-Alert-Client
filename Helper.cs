using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RA_Client.Models;
using static RA_Client.Database;

namespace RA_Client
{
    public static class Helper
    {
        [DllImport("Winmm.dll", SetLastError = true)]
        static extern int mciSendString(string lpszCommand, [MarshalAs(UnmanagedType.LPStr)] StringBuilder lpszReturnString, int cchReturn, IntPtr hwndCallback);

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static string GetMachineName()
        {
            return Environment.MachineName;
        }

        public static string GetMachineIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string _workstationIp = "";

            foreach (var ipAddress in host.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    _workstationIp = ipAddress.ToString();
                    break;
                }
            }

            return _workstationIp;
        }

        public static string GetWindowsUser()
        {
            string _windowsUser = Environment.UserName; // Alternative with domain: System.Security.Principal.WindowsIdentity currentWindowsUser = System.Security.Principal.WindowsIdentity.GetCurrent();

            return _windowsUser;
        }

        public static ADUser? GetADUser()
        {
            // Get currently logged in user
            string windowsUser = Environment.UserName; // Alternative with domain: System.Security.Principal.WindowsIdentity currentWindowsUser = System.Security.Principal.WindowsIdentity.GetCurrent();

            // Get user info from the AD
            ADUser? adUser = GetActiveDirectoryUserInfo("plzft.net", windowsUser);

            return adUser;

            // Check if the user exists in the AD and is also active in the application database
            //user.userId = data.CheckUserInDB(user.windowsUser);
            //if (user.adUser != null && user.userId != 0)
            //{
            //    user.loggedIn = true;
            //}
            //else
            //    user.loggedIn = false;

            //if (user.loggedIn == true)
            //{
            //    settings = data.LoadSettings(user.userId);
            //}
            //else
            //{
            //    // User not logged in
            //    ProjectButtonGrid.Children.Clear();

            //    StatusBarUserLabel.Content = "Nicht angemeldet";
            //}

        }

        /// <summary>
        /// Get user information from the Active Directory via LDAP
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        private static ADUser? GetActiveDirectoryUserInfo(string domain, string userName)
        {
            string ldapBase = string.Format("LDAP://{0}", domain);

            using var entry = new DirectoryEntry(ldapBase);
            using var searcher = new DirectorySearcher(entry);

            ADUser? user;
            searcher.Filter = string.Format("(sAMAccountName={0})", userName);
            var result = searcher.FindOne();

            if (result != null)
            {
                // result.Properties - list of loaded user properties
                // result.Properties.PropertyNames - list of user property names                
                user = new ADUser
                {
                    UserPrincipalName = result.Properties["userprincipalname"].Cast<string>().FirstOrDefault(),
                    Name = result.Properties["name"].Cast<string>().FirstOrDefault(),
                    //PropertyNames = (Dictionary<string, string>)result.Properties.PropertyNames
                    Properties = result.Properties
                };
            }
            else
                user = null;

            return user;
        }

        /// <summary>
        /// Converts a Byte array into an icon
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Icon BytesToIcon(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return new Icon(ms);
            }
        }

        /// <summary>
        /// Gets all active incidents
        /// </summary>
        /// <returns></returns>
        public static List<Incident> GetIncidents()
        {
            List<Incident> _listIncidents = Database.CheckForIncidents();

            foreach (Incident _incident in _listIncidents)
            {
                string _htmlFile = Path.Combine(Application.CommonAppDataPath, "temp_" + Guid.NewGuid().ToString() + ".html");
                StreamWriter sw = File.CreateText(_htmlFile);
                sw.WriteLine(_incident.html);
                sw.Close();

                _incident.htmlFile = _htmlFile;
            }

            return _listIncidents;
        }

        public static void ShowIncidents(Form_Main formMain, List<Incident> incidentList)
        {
            // Currently only the first returned incident will be processed 
            Incident _incident = incidentList[0];

            if (_incident.active)
            {
                formMain.timer_Icon.Enabled = true;

                // Form
                Screen[] screens = Screen.AllScreens;

                if (Form_Main.appSettings.ShowOnAllMonitors == true)
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

                        form_Incident.webView_Incident.Source = new Uri(_incident.htmlFile);
                        form_Incident.webView_Incident.Update();
                    }
                }
                else
                {
                    Form_Incident form_Incident = new()
                    {
                        Location = screens[Form_Main.appSettings.MonitorNumber].WorkingArea.Location,
                        FormBorderStyle = FormBorderStyle.None,
                        TopMost = true,
                        WindowState = FormWindowState.Maximized
                    };

                    form_Incident.Show();

                    form_Incident.webView_Incident.Source = new Uri(_incident.htmlFile);
                    //form_Incident.webView_Incident.CoreWebView2.IsMuted = !form_Incident.webView_Incident.CoreWebView2.IsMuted;

                    form_Incident.webView_Incident.Update();
                }

                // Audio
                if (Form_Main.appSettings.UnmuteOnAlert == true)
                {
                    // Force system wide unmute of audio
                    // SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_MUTE);
                    // Multiple messages increase the volume
                    SendMessageW(formMain.Handle, WM_APPCOMMAND, formMain.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);

                    StringBuilder sb = new();
                    string sFileName = Path.Combine(Application.CommonAppDataPath, "tas_red_alert.mp3");
                    string sAliasName = "MP3";

                    int nRet = mciSendString("open \"" + sFileName + "\" alias " + sAliasName, sb, 0, IntPtr.Zero);
                    nRet = mciSendString("play " + sAliasName + " repeat", sb, 0, IntPtr.Zero);
                }
            }

        }

        /// <summary>
        /// Removes temporary files created by the application
        /// </summary>
        public static void RemoveTempFiles()
        {
            List<string> _files = Directory.GetFiles(Application.CommonAppDataPath, "temp_*.html", SearchOption.TopDirectoryOnly).ToList();
            foreach (string _file in _files)
            {
                File.Delete(_file);
            }
        }

    }
}
