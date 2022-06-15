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
        
        public CarOrdersWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This button moves to previous Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        /// <summary>
        /// This button moves to AddCarWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();            
            addCarWindow.Show();

        }

        private void CarOrdersWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable getCarOrders = DBHelper.GetCarOrders();
           AddCarDataGrid.ItemsSource = getCarOrders.DefaultView;
        }

        private void RemoveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            
            int? selectedOrder = AddCarDataGrid.SelectedIndex;
            if (selectedOrder != -1)
            {
                TextBlock ID = AddCarDataGrid.Columns[0].GetCellContent(AddCarDataGrid.Items[(int)selectedOrder]) as TextBlock;

                DBHelper.RemoveOrder(int.Parse(ID.Text));
                DataTable refreshCarOrders = DBHelper.GetCarOrders();
                AddCarDataGrid.ItemsSource = refreshCarOrders.DefaultView;
            }
        }



        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            DataTable refreshCarOrders = DBHelper.RefreshCarOrders();
            AddCarDataGrid.ItemsSource = refreshCarOrders.DefaultView;


        }
    }
}

