using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Diagnostics;

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

    }
}
