using Projekt_ProgramowanieO.Helpers;
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
        
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DBHelper.AddCarOrder(SamochodIdTxt.Text,  StatusIdTxt.Text, (DateTime)DataZamowieniaCalendar.SelectedDate);
            Close();        
        }

        private void SamochodIdTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            SamochodIdTxt.Clear();
        }
     
        private void StatusIdTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            StatusIdTxt.Clear();
        }
    }
}
