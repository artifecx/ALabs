using ALabs.LessonRegEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ALabs.LessonIntro
{
    /// <summary>
    /// Interaction logic for Lesson1Page.xaml
    /// </summary>
    public partial class Lesson1Page : Page
    {
        private readonly MainWindow mainWindow;
        public Lesson1Page(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;         
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }

        private void btn1Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new TutorialIntro(mainWindow));
        }
        private void btn2Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r\nChoose between 'a' or 'b'.\r\n\r\n* (Kleene Star):\r\nChoosing the alphabet 0 or infinite number of times\r\n\r\nParentheses ():\r\nFor grouping alphabets\r\n\r\nBasic Patterns:\r\nLiteral Matching:\r\nMatches 'a' or 'b' exactly.\r\n\r\nAlternation:\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\n\r\nZero or More Occurrences:\r\nUse '*' to match zero or more occurrences.\r\n\r\nGrouping with Parentheses:\r\nParentheses help us organize expressions.\r\n\r\n";
            tbL.Text = text;
            tbL.FontSize = 19;
            btn3.IsEnabled = true;
        }
        private void btn3Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r\nChoose between 'a' or 'b'.\r\n\r\n* (Kleene Star):\r\nChoosing the alphabet 0 or infinite number of times\r\n\r\nParentheses ():\r\nFor grouping alphabets\r\n\r\nBasic Patterns:\r\nLiteral Matching:\r\nMatches 'a' or 'b' exactly.\r\n\r\nAlternation:\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\n\r\nZero or More Occurrences:\r\nUse '*' to match zero or more occurrences.\r\n\r\nGrouping with Parentheses:\r\nParentheses help us organize expressions.\r\n\r\n";
            tbL.Text = text;
            tbL.FontSize = 19;
            btn4.IsEnabled = true;
        }
        private void btn4Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r\nChoose between 'a' or 'b'.\r\n\r\n* (Kleene Star):\r\nChoosing the alphabet 0 or infinite number of times\r\n\r\nParentheses ():\r\nFor grouping alphabets\r\n\r\nBasic Patterns:\r\nLiteral Matching:\r\nMatches 'a' or 'b' exactly.\r\n\r\nAlternation:\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\n\r\nZero or More Occurrences:\r\nUse '*' to match zero or more occurrences.\r\n\r\nGrouping with Parentheses:\r\nParentheses help us organize expressions.\r\n\r\n";
            tbL.Text = text;
            tbL.FontSize = 19;
            btn5.IsEnabled = true;
        }

        private void btn5Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r\nChoose between 'a' or 'b'.\r\n\r\n* (Kleene Star):\r\nChoosing the alphabet 0 or infinite number of times\r\n\r\nParentheses ():\r\nFor grouping alphabets\r\n\r\nBasic Patterns:\r\nLiteral Matching:\r\nMatches 'a' or 'b' exactly.\r\n\r\nAlternation:\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\n\r\nZero or More Occurrences:\r\nUse '*' to match zero or more occurrences.\r\n\r\nGrouping with Parentheses:\r\nParentheses help us organize expressions.\r\n\r\n";
            tbL.Text = text;
            tbL.FontSize = 19;
            btn5.IsEnabled = true;
        }
    }
}
