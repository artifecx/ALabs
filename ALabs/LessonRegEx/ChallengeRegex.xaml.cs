using ALabs.LessonIntro;
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

namespace ALabs.LessonRegEx
{
    /// <summary>
    /// Interaction logic for ChallengeRegex.xaml
    /// </summary>
    public partial class ChallengeRegex : Page
    {
        private readonly MainWindow mainWindow;
        private int r1, l = 1;
        private String text = "";
        private Random random = new Random();
        public ChallengeRegex(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new PlayPage(mainWindow));
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {

            String answer = tbAns.Text;
            Boolean checker = Check(l, r1, answer);
            if (myProgressBar.Value > 98)
            {
                MessageBox.Show("Challenge has been completed");
            } else {
                if (checker)
                {
                    myProgressBar.Value += 8.33;
                    tb1.Text = "";
                    tbAns.Text = "";
                    MessageBox.Show("Correct, Proceed to the next level");
                    switch (l)
                    {
                        case 1:
                            btnl2.Visibility = Visibility.Visible;
                            break;
                        case 2:
                            btnl3.Visibility = Visibility.Visible;
                            break;
                        case 3:
                            btnl4.Visibility = Visibility.Visible;
                            break;
                        case 4:
                            btnl5.Visibility = Visibility.Visible;
                            break;
                        case 5:
                            btnl6.Visibility = Visibility.Visible;
                            break;
                        case 6:
                            btnl7.Visibility = Visibility.Visible;
                            break;
                        case 7:
                            btnl8.Visibility = Visibility.Visible;
                            break;
                        case 8:
                            btnl9.Visibility = Visibility.Visible;
                            break;
                        case 9:
                            btnl10.Visibility = Visibility.Visible;
                            break;
                        case 10:
                            btnl11.Visibility = Visibility.Visible;
                            break;
                        case 11:
                            btnl12.Visibility = Visibility.Visible;
                            break;
                    }
                } else
                {
                    MessageBox.Show("Incorrect");
                }
            }
        }

        private Boolean Check(int l, int q, String ans)
        {
            if(l == 1)
            {
                if(r1 == 1)
                {
                    if(ans == "a(a+b)*")
                    {
                        return true;
                    }
                } 
                else
                {
                    if (ans == "b(a+b)*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 2)
            {
                if (r1 == 1)
                {
                    if (ans == "(a+b)*a")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a+b)*b")
                    {
                        return true;
                    }
                }
            }
            else if (l == 3)
            {
                if (r1 == 1)
                {
                    if (ans == "(a+b)*bb(a+b)*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a+b)*ab(a+b)*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 4)
            {
                if (r1 == 1)
                {
                    if (ans == "bb(a+b)*ba")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "bb(a+b)*bb+bb")
                    {
                        return true;
                    }
                }
            }
            else if (l == 5)
            {
                if (r1 == 1)
                {
                    if (ans == "aaa(a+b)*bb(a+b)*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "bab(a+b)*bb(a+b)*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 6)
            {
                if (r1 == 1)
                {
                    if (ans == "(a+b)*bb(a+b)*aaa")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a+b)*ab(a+b)*aab")
                    {
                        return true;
                    }
                }
            }
            else if (l == 7)
            {
                if (r1 == 1)
                {
                    if (ans == "(a+b*)(a+b*)(a+b*)")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a*+b)(a*+b)(a*+b)(a*+b)")
                    {
                        return true;
                    }
                }
            }
            else if (l == 8)
            {
                if (r1 == 1)
                {
                    if (ans == "(a+b)*(bb+ba+ab)+b*+a" || ans == "(aa+b)*(bb+ba+ab)+a+b*" || ans == "(aa+b)*(ba+bb+ab)+a+b*" || ans == "(aa+b)*(ba+ab+bb)+a+b*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a+b)*(aa+ba+ab)+a*+b" || ans == "(aa+b)*(a+ba+ab)+b+a*" || ans == "(aa+b)*(ba+a+ab)+b+a*" || ans == "(aa+b)*(ba+ab+a)+b+a*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 9)
            {
                if (r1 == 1)
                {
                    if (ans == "((a+b)(a+b)(a+b)(a+b)(a+b))*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "((a+b)(a+b)(a+b))*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 10)
            {
                if (r1 == 1)
                {
                    if (ans == "(b*ab*ab*)*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a*ba*ba*)*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 11)
            {
                if (r1 == 1)
                {
                    if (ans == "(a*ba*ba*ba*ba*ba*ba*)*")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(b*ab*ab*ab*)*")
                    {
                        return true;
                    }
                }
            }
            else if (l == 12)
            {
                if (r1 == 1)
                {
                    if (ans == "(b(a+b)*)*+b")
                    {
                        return true;
                    }
                }
                else
                {
                    if (ans == "(a(a+b)*)*+a")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //levels
        private void btnl1_Click(object sender, RoutedEventArgs e)
        {
            l = 1;
            r1 = random.Next(1, 3);
            if(r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts with a";
            }else
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts with b";
            }
            tb1.Text = text;
            btnl1.IsEnabled = false;
        }
        private void btnl2_Click(object sender, RoutedEventArgs e)
        {
            l = 2;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that ends with a";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that ends with b";
            }

            tb1.Text = text;
            btnl2.IsEnabled = false;
        }
        private void btnl3_Click(object sender, RoutedEventArgs e)
        {
            l = 3;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains bb";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains ab";
            }

            tb1.Text = text;
            btnl3.IsEnabled = false;
        }
        private void btnl4_Click(object sender, RoutedEventArgs e)
        {
            l = 4;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts bb and ends with ba";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts and ends with bb";
            }

            tb1.Text = text;
            btnl4.IsEnabled = false;
        }
        private void btnl5_Click(object sender, RoutedEventArgs e)
        {
            l = 5;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts with aaa and contains bb";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that starts with bab and contains bb";
            }

            tb1.Text = text;
            btnl5.IsEnabled = false;
        }
        private void btnl6_Click(object sender, RoutedEventArgs e)
        {
            l = 6;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains bb and ends with aaa";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains ab and ends with aab";
            }

            tb1.Text = text;
            btnl6.IsEnabled = false;
        }
        private void btnl7_Click(object sender, RoutedEventArgs e)
        {
            l = 7;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains at most 3 occurences of a";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains at most 4 occurences of b";
            }

            tb1.Text = text;
            btnl7.IsEnabled = false;
        }

        private void btnl8_Click(object sender, RoutedEventArgs e)
        {
            l = 8;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that does not end in aa";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that does not end in bb";
            }

            tb1.Text = text;
            btnl8.IsEnabled = false;
        }
        private void btnl9_Click(object sender, RoutedEventArgs e)
        {
            l = 9;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that is divisible by 5";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that is disivible by 3";
            }

            tb1.Text = text;
            btnl9.IsEnabled = false;
        }
        private void btnl10_Click(object sender, RoutedEventArgs e)
        {
            l = 10;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains an even number of a's";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains an even number of b's";
            }

            tb1.Text = text;
            btnl10.IsEnabled = false;
        }
        private void btnl11_Click(object sender, RoutedEventArgs e)
        {
            l = 11;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} where b is disivible by 6";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} where a is divisible by 3";
            }

            tb1.Text = text;
            btnl11.IsEnabled = false;
        }
        
        private void btnl12_Click(object sender, RoutedEventArgs e)
        {
            l = 12;
            r1 = random.Next(1, 3);
            if (r1 == 1)
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains at least 1 occurence of b";
            }
            else
            {
                text = "Give a regular expression whose language is strings over {a,b} that contains at least 1 occurence of a";
            }

            tb1.Text = text;
            btnl12.IsEnabled = false;
        }
    }
}
