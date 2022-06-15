using Projekt_ProgramowanieO.Helpers;
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

        SqlConnection connection = new SqlConnection(@"Data Source = BLONDAS\SQLSERVER2019; Initial Catalog = CarRent;  Integrated Security=True");

        //SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-L4JD3O1\TEW_SQLEXPRESS;Initial Catalog=CarRent;Integrated Security=True");
        public LoginWindowV2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool islogged = DBHelper.Login(LoginTxt.Text, PasswordTxt.passbox.Password);

 
            if (islogged)
            {
                MainWindow mainWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("paosdkoaskdo");
            }
        }
    }

 }

