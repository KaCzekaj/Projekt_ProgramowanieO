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

namespace Projekt_ProgramowanieO.Controls
{
    /// <summary>
    /// Interaction logic for UserNameContolTextBox.xaml
    /// </summary>
    public partial class UserNameContolTextBox : UserControl
    {
        public UserNameContolTextBox()
        {
            InitializeComponent();
        }



        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...  USERNAME BOX
        public static readonly DependencyProperty PlaceHolderProperty =
            DependencyProperty.Register("PlaceHolder", typeof(string), typeof(UserNameContolTextBox));





        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...  PASSWPRD
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UserNameContolTextBox));



        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPassword.  This enables animation, styling, binding, etc...   HIHING PASSWORD
        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register("IsPassword", typeof(bool), typeof(UserNameContolTextBox));

        private void passbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
             Login.Text = passbox.Password;

        }
    }
}
