using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                string query = "Insert Into ZamowieniaSamochodow(SamochodID,DataZamowienia,Ilosc,StatusID) VALUES(@SamochodID,@DataZamowienia,@Ilosc,@StatusID)";
                
                SqlCommand sqlCommand = new SqlCommand(query,connection);

                sqlCommand.Parameters.AddWithValue("@SamochodID", SamochodIdTxt.Text);
                sqlCommand.Parameters.AddWithValue("@DataZamowienia", DataZamowieniaCalendar.SelectedDate);
                sqlCommand.Parameters.AddWithValue("@Ilosc", IloscTxt.Text);
                sqlCommand.Parameters.AddWithValue("@StatusID", StatusIdTxt.Text);

                sqlCommand.ExecuteNonQuery();
                Close();

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        private void IdTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            IdTxt.Clear();
        }
    }
}
