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
using ALabs.Database;

namespace ALabs
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly MainWindow mainWindow;
        private readonly User authenticatedUser;

        public MainPage(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;
            MessageBox.Show(authenticatedUser.Name.ToString());
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            mainWindow.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new SettingsPage(mainWindow, authenticatedUser));
        }

        private void LessonsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow, authenticatedUser));
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new PlayPage(mainWindow, authenticatedUser));
        }
    }
}
