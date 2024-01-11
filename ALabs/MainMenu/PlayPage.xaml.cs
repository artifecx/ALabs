using ALabs.LessonRegEx;
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
    /// Interaction logic for PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        private readonly MainWindow mainWindow;
        private User authenticatedUser;
        public PlayPage(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new MainPage(mainWindow, authenticatedUser));
        }

        private void RegexChallenge_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new ChallengeRegex(mainWindow, authenticatedUser));
        }
    }
}
