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

        public LessonsPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new MainPage(mainWindow));
        }
        private void Lesson1_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new MainPage(mainWindow));
        }
        private void Lesson2_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new MainPage(mainWindow));
        }

        private void Lesson3_Click(object sender, RoutedEventArgs e)
        {
            // Go back to MainPage
            mainWindow.mainFrame.Navigate(new MainPage(mainWindow));
        }
    }
}
