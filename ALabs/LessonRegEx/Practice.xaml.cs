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

namespace ALabs.LessonRegEx
{
    /// <summary>
    /// Interaction logic for Practice.xaml
    /// </summary>
    public partial class Practice : Page
    {
        private readonly MainWindow mainWindow;
        private readonly User authenticatedUser;
        int q = 1;
        public Practice(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;
            tb1.TextAlignment = TextAlignment.Center;
            tb1.Text = "Regular Expression that starts with bba";
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Lesson2Page(mainWindow, authenticatedUser));
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (q != 4)
            {
                btnNext.IsEnabled = false;
                switch (q)
                {
                    case 2:
                        tb1.Text = "Regular Expression that end with bab";//Question2
                        break;
                    case 3:
                        tb1.Text = "Regular Expression that contains bb";
                        break;
                }
            } else
            {
                MessageBox.Show("Congratulations you are now ready to take on the Challenges.");
                mainWindow.mainFrame.Navigate(new PlayPage(mainWindow, authenticatedUser));//change to the regexchallenges page
            }

        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            String answer = tbAns.Text;
            Boolean check = Check(q, answer);
            if (check)
            {
                q++;
                MessageBox.Show("Correct");
                btnNext.IsEnabled = true;
                myProgressBar.Value += 33.3;
            }
            else
            {
                MessageBox.Show("Answer is incorrect");
            }
        }

        private Boolean Check(int q, String ans)
        {
            switch (q)
            {
                case 1:
                    if(ans == "bba(a+b)*")
                        return true;
                    else
                        return false;
                case 2:
                    if (ans == "(a+b)*bab")
                        return true;
                    else
                        return false;
                case 3:
                    if (ans == "(a+b)*bb(a+b)*")
                        return true;
                    else
                        return false;    
                default:
                    return false;
            }
            return false;
        }
    }
}
