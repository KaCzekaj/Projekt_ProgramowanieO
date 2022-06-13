using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_ProgramowanieO
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MyReservationsBtn_1(object sender, RoutedEventArgs e)
        {
            MyReservationWindow reservationWindow = new MyReservationWindow();
            Visibility = Visibility.Hidden;
            reservationWindow.Show();
        }
        private void MyDataBtn_1(object sender, RoutedEventArgs e)
        {
            MyDataWindow dataWindow = new MyDataWindow();
            Visibility = Visibility.Hidden;
            dataWindow.Show();
        }
        private void LogOutBtn_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LoginPage();
        }
    }
}
