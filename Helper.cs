using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static RA_Client.Database;

namespace RA_Client
{
    public static class Helper
    {
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
        /// Class for a AD user
        /// </summary>
        public class ADUser
        {
            public string? UserPrincipalName { get; set; }
            public string? Name { get; set; }
            public ResultPropertyCollection? Properties { get; set; }
        }

    }
}
