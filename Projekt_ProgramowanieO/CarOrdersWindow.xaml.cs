using Microsoft.EntityFrameworkCore;
using Projekt_ProgramowanieO.Database;
using Projekt_ProgramowanieO.Database.Tables;
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
        private readonly ApplicationDbContext _context;

        public CarOrdersWindow(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        /// <summary>
        /// This button moves to previous Window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(_context);
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
            AddCarWindow addCarWindow = new AddCarWindow(_context);            
            addCarWindow.Show();

        }

        private async void CarOrdersWindow_Loaded(object sender, RoutedEventArgs e)
        {
           List<ZamowieniaSamochodow> cars = await _context.ZamowieniaSamochodow.ToListAsync();
           AddCarDataGrid.ItemsSource = cars;
        }

        private async void RemoveCarBtn_Click(object sender, RoutedEventArgs e)
        {
            
            int? selectedOrder = AddCarDataGrid.SelectedIndex;
            if (selectedOrder != -1)
            {
                TextBlock ID = AddCarDataGrid.Columns[0].GetCellContent(AddCarDataGrid.Items[(int)selectedOrder]) as TextBlock;

                ZamowieniaSamochodow reservationToDelete = _context.ZamowieniaSamochodow.Where(x => x.ID == int.Parse(ID.Text)).FirstOrDefault();
                _context.Remove(reservationToDelete);
                _context.SaveChanges();
                List<ZamowieniaSamochodow> cars = await _context.ZamowieniaSamochodow.ToListAsync();
                AddCarDataGrid.ItemsSource = cars;
            }
        }



        private async void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            List<ZamowieniaSamochodow> cars = await _context.ZamowieniaSamochodow.ToListAsync();
            AddCarDataGrid.ItemsSource = cars;
        }
    }
}

