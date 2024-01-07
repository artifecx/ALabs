using ALabs.LessonRegEx;
using ALabs.LessonNFA;
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

namespace ALabs.LessonNFA
{
    /// <summary>
    /// Interaction logic for Lesson3Page.xaml
    /// </summary>
    public partial class Lesson3Page : Page
    {
        private readonly MainWindow mainWindow;
        private int location;

        public Lesson3Page(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            InitializePanel(0);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }

        private void btn1Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(0);
        }
        private void btn2Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(1);
        }
        private void btn3Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(2);
        }
        private void btn4Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(3);
        }
        private void btn5Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(4);
        }
        private void btn6Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(5);
        }
        private void btn7Click(object sender, RoutedEventArgs e)
        {
            InitializePanel(6);
        }
        private void prevClick(object sender, RoutedEventArgs e)
        {
            InitializePanel(location - 1);
        }
        private void nextClick(object sender, RoutedEventArgs e)
        {
            string next = "btn" + (location + 2);

            if (((Button)this.FindName(next)).IsEnabled == true)
            {
                InitializePanel(location + 1);
            }
            else
            {
                MessageBox.Show("You must complete this chapter's assesment(s) before being allowed to proceed.");
            }
        }

        private void InitializePanel(int loc)
        {
            btnPrev.IsEnabled = loc == 0 ? false : true;
            btnNext.IsEnabled = loc == 6 ? false : true;
            location = loc;

            panelContent.Children.Clear();
            switch (loc)
            {
                case 0:
                    LessonContent.DisplayChapter1(panelContent, btn2);
                    break;
                case 1:
                    LessonContent.DisplayChapter2(panelContent, btn3);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                default:
                    break;
            }
        }
    }
}
