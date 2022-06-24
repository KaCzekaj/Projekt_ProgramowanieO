using Microsoft.EntityFrameworkCore;
using Projekt_ProgramowanieO.Database;
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
        private readonly ApplicationDbContext _context;

        public LoginWindowV2(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isLogged = await _context.Users
                .Where(x => x.Login == LoginTxt.Text && x.Haslo == PasswordTxt.passbox.Password)
                .FirstOrDefaultAsync() != null;

 
            if (isLogged)
            {
                MainWindow mainWindow = new MainWindow(_context);
                this.Visibility = Visibility.Hidden;
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Make sure if you've entered a correct username or password.");
            }
        }
    }

 }

