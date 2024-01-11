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
using ALabs.Database;
using System.Collections;

namespace ALabs.LessonNFA
{
    /// <summary>
    /// Interaction logic for Lesson3Page.xaml
    /// </summary>
    public partial class Lesson3Page : Page
    {
        private readonly MainWindow mainWindow;
        private int location;
        private bool skipReveal = false;
        private User authenticatedUser;

        public Lesson3Page(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;

            InitializePanel(0, false);
            InitializeButtonStates();
        }

        private void InitializeButtonStates()
        {
            btn2.IsEnabled = LessonContent.GetChapterStatus(1);
            btn3.IsEnabled = LessonContent.GetChapterStatus(2);
            btn4.IsEnabled = LessonContent.GetChapterStatus(3);
            btn5.IsEnabled = LessonContent.GetChapterStatus(4);
            btn6.IsEnabled = LessonContent.GetChapterStatus(5);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow, authenticatedUser));
        }

        private void btnChapterClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int chapterNumber = int.Parse(clickedButton.Name.Substring(3));

            InitializePanel(chapterNumber - 1, true);
        }

        private void prevClick(object sender, RoutedEventArgs e)
        {
            InitializePanel(location - 1, true);
        }
        private void nextClick(object sender, RoutedEventArgs e)
        {
            string next = "btn" + (location + 2);
            string nextNext = "btn" + (location + 3);
            bool skipCurrent = nextNext != "btn7" ? ((Button)this.FindName(nextNext)).IsEnabled : LessonContent.GetChapterStatus(6);

            if (((Button)this.FindName(next)).IsEnabled == true)
            {
                InitializePanel(location + 1, skipCurrent);
            }
            else
            {
                MessageBox.Show("You must complete this chapter's assesment(s) before being allowed to proceed.");
            }
        }

        private void InitializePanel(int loc, bool skip)
        {
            btnPrev.IsEnabled = loc == 0 ? false : true;
            btnNext.IsEnabled = loc == 5 ? false : true;
            location = loc;

            panelContent.Children.Clear();
            switch (loc)
            {
                case 0:
                    LessonContent.DisplayChapter1(panelContent, btn2, skip);
                    break;
                case 1:
                    LessonContent.DisplayChapter2(panelContent, btn3, skip);
                    break;
                case 2:
                    LessonContent.DisplayChapter3(panelContent, btn4, skip);
                    break;
                case 3:
                    LessonContent.DisplayChapter4(panelContent, btn5, skip);
                    break;
                case 4:
                    LessonContent.DisplayChapter5(panelContent, btn6, skip);
                    break;
                case 5:
                    LessonContent.DisplayChapter6(panelContent, skip);
                    break;
                default:
                    break;
            }
        }
    }
}
