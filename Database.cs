using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using RA_Client.Models;
using System.Diagnostics;
using System.DirectoryServices;
using System.Xml.Linq;
using static RA_Client.Helper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RA_Client
{
    public class Database
    {
        public static void RegisterClientOnServer(string name, string ip, string adUser)
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
                        "name, ip, last_connection, user" +
                        ") " +
                        "VALUES " +
                        "(" +
                        $"'{name}','{ip}','{DateTime.Now:yyyy-MM-dd HH:mm:ss}', {adUser} " +
                        ")";

                    updateCommand.ExecuteNonQuery();
                }
                else
                {

                    MySqlCommand updateCommand = conn.CreateCommand();
                    updateCommand.CommandText = "UPDATE clients SET " +
                        $"name='{name}', ip='{ip}', last_connection='{DateTime.Now:yyyy-MM-dd HH:mm:ss}', online=1, user='{adUser}' " +
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

        public static List<Incident> CheckForIncidents()
        {
            MySqlConnection conn = new(Form_Main.appSettings.DatabaseServer);
            List<Incident> _incidentList = new();

            try
            {
                conn.Open();

                MySqlCommand selectCommand = conn.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM current_incidents INNER JOIN incidents ON incidents.id = current_incidents.incident_id where active = 1";

                MySqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    string _label = reader.GetString(reader.GetOrdinal("label"));
                    string _html = reader.GetString(reader.GetOrdinal("html"));

                    Incident _incident = new()
                    {
                        active = true,
                        label = _label,
                        html = _html
                    };

                    _incidentList.Add(_incident);

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

            //return (_incidentActive, Path.Combine(Application.CommonAppDataPath, "temp.html"));
            return _incidentList;
        }



    }
}
