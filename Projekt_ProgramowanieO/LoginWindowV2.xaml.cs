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
    /// Interaction logic for LogiWinfowV2.xaml
    /// </summary>
    public partial class LoginWindowV2 : Window
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L4JD3O1\TEW_SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
        public LoginWindowV2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                command.Parameters.AddWithValue("@Login", LoginTxt.Text);
                command.Parameters.AddWithValue("@Haslo", PasswordTxt.Text);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("You've entered wrong login or password! Please check again if you write it correctly.");
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
        }
    }

 }

