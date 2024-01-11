using System;
using ALabs.Database;
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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ALabs.LessonRegEx
{
    /// <summary>
    /// Interaction logic for Lesson2Page.xaml
    /// </summary>
    public partial class Lesson2Page : Page
    {
        private readonly MainWindow mainWindow;
        private readonly User authenticatedUser;
        int lesson2progress;
        public Lesson2Page(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;

            lesson2progress = authenticatedUser.lesson2progress;

            if (lesson2progress >= 2)
            {
                btn2.IsEnabled = true;
            }
            if (lesson2progress >= 3)
            {
                btn3.IsEnabled = true;
            }
            if (lesson2progress >= 4)
            {
                btn4.IsEnabled = true;
            }
            if (lesson2progress >= 5)
            {
                btn5.IsEnabled = true;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow, authenticatedUser));
        }

        private async void btn1Click(object sender, RoutedEventArgs e)
        {
            String text = "\nRegex is a powerful tool for finding specific patterns in text.\r\n\nIn our regex adventure, we'll explore a simplified world with just two alphabets: 'a' and 'b'.\r\n\nThe symbols which we are going to use are: +, *, and parentheses\r\n";
            tbL.Text = text ;
            tbL.FontSize = 25;
            btn2.IsEnabled = true;
            
            using (UserDataContext context = new UserDataContext())
            {
                // Retrieve the user from the database
                User userToUpdate = context.Users.FirstOrDefault(user => user.Id == authenticatedUser.Id);

                if (userToUpdate != null && authenticatedUser.lesson2progress < 2)
                {
                    // Update the lesson2progress property
                    userToUpdate.lesson2progress = 2;

                    // Save changes to the database
                    context.SaveChanges();

                    // Update the authenticatedUser in memory to reflect the changes
                    authenticatedUser.lesson2progress = userToUpdate.lesson2progress;

                }
            }

        }
        private void btn2Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r \"Choose either 'a' or 'b'\"\r\nExamples: a+b, b+a.\r\n\n\n* (Kleene Star):\r\nIt is the set of all Strings that can be written zero to infinite number of times\r\nExample: \nb* can be:\n bb, bbb, b or simply {}(empty).\r\n\n\nParentheses ():\r\nThey help us group things together, adding flexibility.\r\nExamples: (a+b)*, (a*b).";
            tbL.Text = text;
            btn3.IsEnabled = true;
            using (UserDataContext context = new UserDataContext())
            {
                // Retrieve the user from the database
                User userToUpdate = context.Users.FirstOrDefault(user => user.Id == authenticatedUser.Id);

                if (userToUpdate != null && authenticatedUser.lesson2progress < 3)
                {
                    // Update the lesson2progress property
                    userToUpdate.lesson2progress = 3;

                    // Save changes to the database
                    context.SaveChanges();

                    // Update the authenticatedUser in memory to reflect the changes
                    authenticatedUser.lesson2progress = userToUpdate.lesson2progress;

                }
            }
        }
        private void btn3Click(object sender, RoutedEventArgs e)
        {
            String text = "Literal Matching:\r\n\r\nMatches 'a' or 'b' exactly.\r\nExamples: a, b.\r\nAlternation:\r\n\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\nExamples: a+b, b+a.\r\nZero or More Occurrences:\r\n\r\nUse '*' to match zero or more occurrences.\r\nExamples: b*, a*.\r\nGrouping with Parentheses:\r\n\r\nParentheses help us group expressions.\r\nExamples: (a+b)*, (a*b).";
            tbL.Text = text;
            btn4.IsEnabled = true;
            using (UserDataContext context = new UserDataContext())
            {
                // Retrieve the user from the database
                User userToUpdate = context.Users.FirstOrDefault(user => user.Id == authenticatedUser.Id);

                if (userToUpdate != null && authenticatedUser.lesson2progress < 4)
                {
                    // Update the lesson2progress property
                    userToUpdate.lesson2progress = 4;

                    // Save changes to the database
                    context.SaveChanges();

                    // Update the authenticatedUser in memory to reflect the changes
                    authenticatedUser.lesson2progress = userToUpdate.lesson2progress;

                }
            }
        }
        private void btn4Click(object sender, RoutedEventArgs e)
        {
            String text = "+ (Or):\r\nChoose between 'a' or 'b'.\r\n\r\n* (Kleene Star):\r\nChoosing the alphabet 0 or infinite number of times\r\n\r\nParentheses ():\r\nFor grouping alphabets\r\n\r\nBasic Patterns:\r\nLiteral Matching:\r\nMatches 'a' or 'b' exactly.\r\n\r\nAlternation:\r\nUse '+' for 'or' to match either 'a' or 'b'.\r\n\r\nZero or More Occurrences:\r\nUse '*' to match zero or more occurrences.\r\n\r\nGrouping with Parentheses:\r\nParentheses help us organize expressions.\r\n\r\n";
            tbL.Text = text;
            tbL.FontSize = 19;
            btn5.IsEnabled = true;
            using (UserDataContext context = new UserDataContext())
            {
                // Retrieve the user from the database
                User userToUpdate = context.Users.FirstOrDefault(user => user.Id == authenticatedUser.Id);

                if (userToUpdate != null && authenticatedUser.lesson2progress < 5)
                {
                    // Update the lesson2progress property
                    userToUpdate.lesson2progress = 5;

                    // Save changes to the database
                    context.SaveChanges();

                    // Update the authenticatedUser in memory to reflect the changes
                    authenticatedUser.lesson2progress = userToUpdate.lesson2progress;

                }
            }
        }
        private void btn5Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Practice(mainWindow, authenticatedUser));
        }
        

    }
}
