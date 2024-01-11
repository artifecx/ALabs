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

namespace ALabs
{
    /// <summary>
    /// Interaction logic for UserRegister.xaml
    /// </summary>
    public partial class UserRegister : Page
    {
        private readonly MainWindow mainWindow;
        public UserRegister(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                UsernamePlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void NameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new UserLogin(mainWindow));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Register button clicked!");
        }
    }
}
