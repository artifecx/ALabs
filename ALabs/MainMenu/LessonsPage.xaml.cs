using ALabs.LessonIntro;
using ALabs.LessonNFA;
using ALabs.LessonRegEx;
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
    /// Interaction logic for LessonsPage.xaml
    /// </summary>
    public partial class LessonsPage : Page
    {
        private readonly MainWindow mainWindow;
        private User authenticatedUser;

        public LessonsPage(MainWindow mainWindow, User authenticatedUser)
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
        private void Lesson1_Click(object sender, RoutedEventArgs e)
        {
            // Go to Intro Lesson
            mainWindow.mainFrame.Navigate(new Lesson1Page(mainWindow, authenticatedUser));
        }
        private void Lesson2_Click(object sender, RoutedEventArgs e)
        {
            // Go to RegEx Lesson
            mainWindow.mainFrame.Navigate(new Lesson2Page(mainWindow, authenticatedUser));
        }
        private void Lesson3_Click(object sender, RoutedEventArgs e)
        {
            // Go to NFA Lesson
            mainWindow.mainFrame.Navigate(new Lesson3Page(mainWindow, authenticatedUser));
        }
    }
}
