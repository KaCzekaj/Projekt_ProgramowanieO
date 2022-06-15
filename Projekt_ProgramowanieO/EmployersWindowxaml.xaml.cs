using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_ProgramowanieO
{
    /// <summary>
    /// Logika interakcji dla klasy EmployersWindowxaml.xaml
    /// </summary>
    public partial class EmployersWindowxaml : Window
    {
        public EmployersWindowxaml()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
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

                pracownicydataGrid.ItemsSource = listaPracownikow.DefaultView;

                adapter.Update(listaPracownikow);
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
    }
}
