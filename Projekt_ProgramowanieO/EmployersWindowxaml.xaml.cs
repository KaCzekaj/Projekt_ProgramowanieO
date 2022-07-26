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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_ProgramowanieO
{
    /// <summary>
    /// Logika interakcji dla klasy EmployersWindowxaml.xaml
    /// </summary>
    public partial class EmployersWindowxaml : Window
    {
        private readonly ApplicationDbContext _context;

        public EmployersWindowxaml(ApplicationDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private async void EmployeesListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Pracownicy> workers = await _context.Pracownicy.ToListAsync();
            EmployeesListdataGrid.ItemsSource = workers;
        }

        private void previousWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(_context);
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
    }
}
