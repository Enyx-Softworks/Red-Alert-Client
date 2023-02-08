using System.Xml.Linq;

namespace RA_Client
{
    public class Settings
    {
        public string? ConnectionType { get; set; }
        public string? DatabaseServer { get; set; }
        public string? PullServer { get; set; }
        public string? PushServer { get; set; }
        public bool ShowOnAllMonitors { get; set; }
        public int MonitorNumber { get; set; }
        public bool StartMinimized { get; set; }
        public bool UnmuteOnAlert { get; set; }


        public static void LoadSettings()
        {
            if (!File.Exists(Path.Combine(Application.CommonAppDataPath, "settings.xml")))
            {
                // Create new config file
                Settings _settings = new();
                _settings.ConnectionType = "";
                _settings.DatabaseServer = "";
                _settings.PullServer = "";
                _settings.PushServer = "";
                _settings.ShowOnAllMonitors = true;
                _settings.MonitorNumber = 0;
                _settings.StartMinimized = true;
                _settings.UnmuteOnAlert = true;

                SaveSettings(_settings);
            }

            XDocument xDoc = XDocument.Load(Path.Combine(Application.CommonAppDataPath, "settings.xml"));

            Form_Main.appSettings.ConnectionType = xDoc.Elements("root").Elements("connection_type").First().Value.ToString();
            Form_Main.appSettings.DatabaseServer = xDoc.Elements("root").Elements("database_server").First().Value.ToString();
            Form_Main.appSettings.PullServer = xDoc.Elements("root").Elements("pull_server").First().Value.ToString();
            Form_Main.appSettings.PushServer = xDoc.Elements("root").Elements("push_server").First().Value.ToString();
            Form_Main.appSettings.ShowOnAllMonitors = bool.TryParse(xDoc.Elements("root").Elements("show_on_all_monitors").First().Value.ToString(), out bool _showonallmonitors) == true ? _showonallmonitors : false;
            Form_Main.appSettings.MonitorNumber = int.TryParse(xDoc.Elements("root").Elements("monitor_number").First().Value.ToString(), out int _monitornumber) == true ? _monitornumber : 0;
            Form_Main.appSettings.StartMinimized = bool.TryParse(xDoc.Elements("root").Elements("start_minimized").First().Value.ToString(), out bool _startminimized) == true ? _startminimized : false;
            Form_Main.appSettings.UnmuteOnAlert = bool.TryParse(xDoc.Elements("root").Elements("unmute_on_alert").First().Value.ToString(), out bool _unmuteonalert) == true ? _unmuteonalert : false;
        }

        public static void SaveSettings(Settings settings)
        {
            if (settings != null)
            {
                XDocument xDoc = new();
                XElement root = new("root");
                xDoc.Add(root);


                XElement settings_connection = new("connection_type", settings.ConnectionType);
                root.Add(settings_connection);

                XElement settings_connection_database = new("database_server", settings.DatabaseServer);
                XElement settings_connection_pullserver = new("pull_server", settings.PullServer);
                XElement settings_connection_pushserver = new("push_server", settings.PushServer);
                XElement settings_app_showonallmonitors = new("show_on_all_monitors", settings.ShowOnAllMonitors);
                XElement settings_app_monitornumber = new("monitor_number", settings.MonitorNumber);
                XElement settings_app_startminimized = new("start_minimized", settings.StartMinimized);
                XElement settings_app_unmuteonalert = new("unmute_on_alert", settings.UnmuteOnAlert);

                root.Add(settings_connection_database);
                root.Add(settings_connection_pullserver);
                root.Add(settings_connection_pushserver);
                root.Add(settings_app_showonallmonitors);
                root.Add(settings_app_monitornumber);
                root.Add(settings_app_startminimized);
                root.Add(settings_app_unmuteonalert);

                xDoc.Save(Path.Combine(Application.CommonAppDataPath, "settings.xml"));
            }
        }

    }

}
