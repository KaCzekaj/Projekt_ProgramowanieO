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
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

           
        }

        SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");

        private void LoginButton_Click(object s, RoutedEventArgs e)
        {
            try
            {
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string loginQuery = "Select (1) From LoginHaslo WHERE Login = @Login AND Haslo = @Haslo";
                SqlCommand command = new SqlCommand(loginQuery, connection);

                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Login", LoginTxt.Text);
                command.Parameters.AddWithValue("@Haslo",PasswordTxt.Password);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if(count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("You've entered wrong login or password! Please check again if you wrote it correctly.");
                }
             
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
