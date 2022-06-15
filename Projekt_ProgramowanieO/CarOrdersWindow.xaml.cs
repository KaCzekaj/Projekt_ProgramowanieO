using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_ProgramowanieO
{
    /// <summary>
    /// Logika interakcji dla klasy CarOrdersWindow.xaml
    /// </summary>
    public partial class CarOrdersWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");
        public CarOrdersWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                string query = " select ID,SamochodID, DataZamowienia, Ilosc, StatusID From ZamowieniaSamochodow ";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dodajSamochod = new DataTable("ZamowieniaSamochodów");
                adapter.Fill(dodajSamochod);

                dodajSamochodDataGrid.ItemsSource = dodajSamochod.DefaultView;

                adapter.Update(dodajSamochod);
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
        private void previousWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();            
            addCarWindow.Show();

        }

        private void RemoveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            int? selectedOrder = dodajSamochodDataGrid.SelectedIndex;
            if (selectedOrder != -1)
            {
                 TextBlock ID = dodajSamochodDataGrid.Columns[0].GetCellContent(dodajSamochodDataGrid.Items[(int)selectedOrder]) as TextBlock;

                try
                {
                    connection.Open();
                    string query = "Delete From ZamowieniaSamochodow Where ID = @ID";

                    SqlCommand sqlCommand = new SqlCommand(query, connection);

                    sqlCommand.Parameters.AddWithValue("@ID", ID.Text);

                    sqlCommand.ExecuteNonQuery();

                    query = "Select * From ZamowieniaSamochodow";
                    sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                    DataTable zamowieniaSamochodow = new DataTable("ZamowieniaSamochodow");
                    adapter.Fill(zamowieniaSamochodow);

                    dodajSamochodDataGrid.ItemsSource = zamowieniaSamochodow.DefaultView;

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
            }

        }
       
    }
}

