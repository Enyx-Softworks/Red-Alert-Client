using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace RA_Client
{
    public class Database
    {
        public static void RegisterClientOnServer(string name, string ip)
        {
            MySqlConnection conn = new(Form_Main.appSettings.DatabaseServer);

            try
            {
                conn.Open();

                MySqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = $"SELECT COUNT(*) AS C FROM clients WHERE name='{name}' AND ip='{ip}'";
                MySqlDataReader reader = selectCommand.ExecuteReader();
                int count = 0;

                if (reader.Read())
                    count = reader.GetInt16(reader.GetOrdinal("C"));
                else
                    count = 0;

                reader.Close();

                if (count == 0)
                {
                    MySqlCommand updateCommand = conn.CreateCommand();
                    updateCommand.CommandText = "INSERT INTO clients " +
                        "(" +
                        "name, ip, last_connection" +
                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{name}','{ip}','{DateTime.Now:yyyy-MM-dd HH:mm:ss}' " +
                        ")";

                    updateCommand.ExecuteNonQuery();
                }
                else
                {

                    MySqlCommand updateCommand = conn.CreateCommand();
                    updateCommand.CommandText = "UPDATE clients SET " +
                        $"name='{name}', ip='{ip}', last_connection='{DateTime.Now:yyyy-MM-dd HH:mm:ss}', online=1 " +
                        $"WHERE name='{name}' AND ip='{ip}'";

                    updateCommand.ExecuteNonQuery();

                }

            }
            catch (MySqlException myEx)
            {
                Console.WriteLine(myEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void UnregisterClientOnServer(string name, string ip)
        {
            MySqlConnection conn = new(Form_Main.appSettings.DatabaseServer);

            try
            {
                conn.Open();

                MySqlCommand updateCommand = conn.CreateCommand();
                updateCommand.CommandText = "UPDATE clients SET " +
                    "online=0 " +
                    $"WHERE name='{name}' AND ip='{ip}'";

                updateCommand.ExecuteNonQuery();
            }
            catch (MySqlException myEx)
            {
                Console.WriteLine(myEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public static (bool, string) CheckForIncident()
        {
            MySqlConnection conn = new(Form_Main.appSettings.DatabaseServer);
            bool _incidentActive = false;

            try
            {
                conn.Open();

                MySqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM current_incidents INNER JOIN incidents ON incidents.id = current_incidents.incident_id where active = 1";

                MySqlDataReader reader = selectCommand.ExecuteReader();

                if (reader.Read())
                {
                    string label = reader.GetString(reader.GetOrdinal("label"));
                    string html = reader.GetString(reader.GetOrdinal("html"));
                    _incidentActive = true;

                    StreamWriter sw = File.CreateText(Path.Combine(Application.CommonAppDataPath, "temp.html"));
                    sw.WriteLine(html);
                    sw.Close();

                }

                reader.Close();
            }
            catch (MySqlException myEx)
            {
                Console.WriteLine(myEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return (_incidentActive, Path.Combine(Application.CommonAppDataPath, "temp.html"));
        }



    }
}
