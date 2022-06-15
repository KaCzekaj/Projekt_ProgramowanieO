using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_ProgramowanieO.Helpers
{
    public static class DBHelper
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");
        public static bool Login(string login, string password)
        {
            
           
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string loginQuery = "Select (1) From LoginHaslo WHERE Login = @Login AND Haslo = @Haslo";
                SqlCommand command = new SqlCommand(loginQuery, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Haslo", password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    return true;
                    
                }
                else
                {
                    return false;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public static DataTable GetCars()
        {
            try
            {
                connection.Open();
                string query = " select ID, Marka, Model, Nadwozie, MocSilnika, Ilosc, StatusID From ListaSamochodow ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable listaSamochodow = new DataTable("ListaSamochodów");
                adapter.Fill(listaSamochodow);
               

                adapter.Update(listaSamochodow);
                return listaSamochodow;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            
        }

    }
}
