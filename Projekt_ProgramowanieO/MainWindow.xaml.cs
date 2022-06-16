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
       
        private void PracownicyButton_Click(object s, RoutedEventArgs e)  
        {
            EmployersWindowxaml employersWindow = new EmployersWindowxaml();
            this.Visibility = Visibility.Hidden;
            employersWindow.Show();
        }
        private void ZamowSamochodButton_Click(object s, RoutedEventArgs e)
        {
            CarOrdersWindow carOrdersWindow = new CarOrdersWindow();
            this.Visibility = Visibility.Hidden;
            carOrdersWindow.Show();
        }
        private void WylogujButton_Click(object s, RoutedEventArgs e)
        {
            LoginWindowV2 loginWindow2 = new LoginWindowV2();
            this.Visibility= Visibility.Hidden;
            loginWindow2.Show();
        }
        
        private void CarListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable Carslist = DBHelper.GetCars();
            CarListdataGrid.ItemsSource = Carslist.DefaultView;
        }
    }
}
