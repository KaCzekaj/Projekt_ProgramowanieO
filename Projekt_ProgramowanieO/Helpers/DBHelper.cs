using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Projekt_ProgramowanieO.Helpers
{
    public static class DBHelper
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");
        //public static SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L4JD3O1\TEW_SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");

        /// <summary>
        /// Logic to LoginWindow.xaml.cs
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns Data from Car list Table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCars()
        {
            try
            {
                connection.Open();
                string query = " select ID, Marka, Model, Nadwozie, MocSilnika,StatusID From ListaSamochodow ";
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

        /// <summary>
        /// Returns Data from Employees Table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetEmployees()
        {
            try
            {
                connection.Open();
                string query = " select ID, Imie, Nazwisko, Email, Telefon, StatusID From Pracownicy";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable listaPracownikow = new DataTable("ListaPracownikow");
                adapter.Fill(listaPracownikow);

                adapter.Update(listaPracownikow);
                return listaPracownikow;
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

        /// <summary>
        /// Returns Data from CarOrders Table.
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCarOrders()
        {
            try
            {
                connection.Open();
                string query = " select ID,SamochodID, DataZamowienia, StatusID From ZamowieniaSamochodow ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dodajSamochod = new DataTable("ZamowieniaSamochodów");
                adapter.Fill(dodajSamochod);

                adapter.Update(dodajSamochod);
                return dodajSamochod;
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
        /// <summary>
        /// Refreshes Data from CarOrders Table.
        /// </summary>
        /// <returns></returns>
        public static DataTable RefreshCarOrders()
        {
            try
            {
                connection.Open();
                string query = "Select * From ZamowieniaSamochodow";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable zamowieniaSamochodow = new DataTable("ZamowieniaSamochodow");
                adapter.Fill(zamowieniaSamochodow);

                

                adapter.Update(zamowieniaSamochodow);
                return zamowieniaSamochodow;
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
        /// <summary>
        /// Removes record from CarOrders Table
        /// </summary>
        /// <param name="selectedOrder"></param>
        /// <param name="ID"></param>
        public static void RemoveOrder(int ID)
        {
            //int? selectedOrder = dodajSamochodDataGrid.SelectedIndex;
            //if (selectedOrder != -1)
            //{
                //TextBlock ID = dodajSamochodDataGrid.Columns[0].GetCellContent(dodajSamochodDataGrid.Items[(int)selectedOrder]) as TextBlock;

                try
                {
                    connection.Open();
                    string query = "Delete From ZamowieniaSamochodow Where ID = @ID";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@ID", ID);

                    sqlCommand.ExecuteNonQuery();

                    query = "Select * From ZamowieniaSamochodow";
                    sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                    DataTable zamowieniaSamochodow = new DataTable("ZamowieniaSamochodow");
                    adapter.Fill(zamowieniaSamochodow);


                    adapter.Update(zamowieniaSamochodow);


                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    connection.Close();
                }

            //}
        }


        /// <summary>
        /// Adds record to CarsOrder Table
        /// </summary>
        /// <param name="SamochodId"></param>
        /// <param name="Ilosc"></param>
        /// <param name="StatusId"></param>
        /// <param name="DataZamowienia"></param>
        public static void AddCarOrder(string SamochodId,string StatusId, DateTime DataZamowienia)
        {
            try
            {
                connection.Open();
                string query = "Insert Into ZamowieniaSamochodow(SamochodID,DataZamowienia,StatusID) VALUES(@SamochodID,@DataZamowienia,@StatusID)";

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                sqlCommand.Parameters.AddWithValue("@SamochodID", SamochodId);               
                sqlCommand.Parameters.AddWithValue("@StatusID", StatusId);
                sqlCommand.Parameters.AddWithValue("@DataZamowienia", DataZamowienia);

                sqlCommand.ExecuteNonQuery();                                            
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
