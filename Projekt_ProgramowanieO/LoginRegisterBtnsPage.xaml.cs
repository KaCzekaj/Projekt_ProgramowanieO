﻿using System;
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
    /// Logika interakcji dla klasy LoginRegisterBtnsPage.xaml
    /// </summary>
    public partial class LoginRegisterBtnsPage : Page
    {
        
        public LoginRegisterBtnsPage()
        {
            InitializeComponent();
            

        }

        private void LoginBtn_1(object sender, RoutedEventArgs e)
        {          
            MainFrame.Content = new LoginPage();
            
        }
        private void RegisterBtn_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new RegisterPage();
            
            
        }
    }

}
