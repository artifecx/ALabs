using ALabs.Database;
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
        private User authenticatedUser;
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
            NamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text))
            {
                NamePlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new UserLogin(mainWindow, authenticatedUser));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;
            var name = NameBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter all required information.");
                return;
            }

            using (UserDataContext context = new UserDataContext())
            {
                // Check if the username already exists
                if (context.Users.Any(user => user.Username == username))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }

                // Create a new user and save it to the database
                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Name = name
                };

                context.Users.Add(newUser);
                context.SaveChanges();

                MessageBox.Show("Registration successful!");
                mainWindow.mainFrame.Navigate(new UserLogin(mainWindow, authenticatedUser));
            }
        }
    }
}
