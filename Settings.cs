using System.Xml.Linq;

namespace RA_Client
{
    public class Settings
    {
        public string? ConnectionType { get; set; }
        public string? DatabaseServer { get; set; }
        public string? PullServer { get; set; }
        public string? PushServer { get; set; }

        public static void LoadSettings()
        {
            XDocument xDoc = XDocument.Load(Path.Combine(Application.CommonAppDataPath, "settings.xml"));

            Form_Main.appSettings.ConnectionType = xDoc.Elements("root").Elements("connection_type").First().Value.ToString();
            Form_Main.appSettings.DatabaseServer = xDoc.Elements("root").Elements("database_server").First().Value.ToString();
            Form_Main.appSettings.PullServer = xDoc.Elements("root").Elements("pull_server").First().Value.ToString();
            Form_Main.appSettings.PushServer = xDoc.Elements("root").Elements("push_server").First().Value.ToString();
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

                root.Add(settings_connection_database);
                root.Add(settings_connection_pullserver);
                root.Add(settings_connection_pushserver);

                xDoc.Save(Path.Combine(Application.CommonAppDataPath, "settings.xml"));
            }
        }

    }

}
