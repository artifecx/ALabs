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
    /// Interaction logic for StatesActivity.xaml
    /// </summary>
    public partial class StatesActivity : Page
    {
        private readonly MainWindow mainWindow;

        // This code is strictly and lazily made for this True/False quiz game.
        // You can add as many questions as you want. Provided that you manually set the paths for the animations and assign the correct and incorrect answers

        private List<Question> questionList = new List<Question>
        {   
            // 0
            new Question("States in Automata Theory represent different situations or conditions that a system can be in at any given moment.", true),
            // 1
            new Question(" In automata theory, States alone do not capture the behavior of a system; rather, they work in conjunction with transitions to represent the system's dynamics and response to input.", false),
            // 2
            new Question("States play a crucial role in defining the overall structure of automata and are essential for understanding how a system progresses from one state to another in response to input.", true),
            new Question("...",false), // lazy debugging again 
          
        };

        private int currentQuestionIndex = 0;
        private int currentCharIndex = 0;

        private DispatcherTimer timer;

        private DispatcherTimer dotTimer;
        private int dotCount = 0;

        // Flags
        private bool printingInProgress = false;
        private bool processingEvent = false;
        private bool isAnimationInProgress = false;
        private bool EndStateReached = false;

        // User Score
        private int userScore = 0;
        public StatesActivity(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            True1.Click += True1_Click;
            False1.Click += False1_Click;
            True2.Click += True2_Click;
            False2.Click += False2_Click;
            True3.Click += True3_Click;
            False3.Click += False3_Click;
            BackToDashboard.Click += BackToDashboard_Click;
            GoToNextLesson.Click += GoToNextLesson_Click;


            InitializeAnimation();
        }
        private void InitializeAnimation()
        {
            DotAnimationTimer();
            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;

            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            True1.IsEnabled = false;
            False1.IsEnabled = false;
            True2.IsEnabled = false;
            False2.IsEnabled = false;
            True3.IsEnabled = false;
            False3.IsEnabled = false;

            True2.Visibility = Visibility.Collapsed;
            False2.Visibility = Visibility.Collapsed;
            True3.Visibility = Visibility.Collapsed;
            False3.Visibility = Visibility.Collapsed;
            BackToDashboard.Visibility = Visibility.Collapsed;
            GoToNextLesson.Visibility = Visibility.Collapsed;


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 185;
            animation1.To = 920;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 920)
                {
                    dotTimer.Stop();
                    DisplayCurrentQuestionOnTvScreen();
                    True1.IsEnabled = true;
                    False1.IsEnabled = true;
                    isAnimationInProgress = false;
                }
            };

            storyboard.Begin();
        }
        private void False1_Click(object sender, RoutedEventArgs e)
        {
            
            UpdateUserScoreText();
            dotTimer.Start();
            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True1.Visibility = Visibility.Collapsed;
            False1.Visibility = Visibility.Collapsed;
            True2.Visibility = Visibility.Visible;
            False2.Visibility = Visibility.Visible;
            True1.IsEnabled = false;
            False1.IsEnabled = false;
            True2.IsEnabled = false;
            False2.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 150;
            animation1.To = 960;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 960)
                {
                    dotTimer.Stop();
                    DisplayCurrentQuestionOnTvScreen();
                    True2.IsEnabled = true;
                    False2.IsEnabled = true;
                    isAnimationInProgress = false;
                }
            };

            storyboard.Begin();
        }

        private void True1_Click(object sender, RoutedEventArgs e)
        {
            
            
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True1.Visibility = Visibility.Collapsed;
            False1.Visibility = Visibility.Collapsed;
            True2.Visibility = Visibility.Visible;
            False2.Visibility = Visibility.Visible;
            True1.IsEnabled = false;
            False1.IsEnabled = false;
            True2.IsEnabled = false;
            False2.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 150;
            animation1.To = 960;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 960)
                {
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    DisplayCurrentQuestionOnTvScreen();
                    True2.IsEnabled = true;
                    False2.IsEnabled = true;
                    isAnimationInProgress = false;
                }
            };

            storyboard.Begin();
        }
        // This is very lazy I know. And I hate myself for it
        private void False2_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True2.Visibility = Visibility.Collapsed;
            False2.Visibility = Visibility.Collapsed;
            True3.Visibility = Visibility.Visible;
            False3.Visibility = Visibility.Visible;
            True2.IsEnabled = false;
            False2.IsEnabled = false;
            True3.IsEnabled = false;
            False3.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 960;
            animation1.To = 1760;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1760)
                {
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True3.IsEnabled = true;
                    False3.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void True2_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True2.Visibility = Visibility.Collapsed;
            False2.Visibility = Visibility.Collapsed;
            True3.Visibility = Visibility.Visible;
            False3.Visibility = Visibility.Visible;
            True2.IsEnabled = false;
            False2.IsEnabled = false;
            True3.IsEnabled = false;
            False3.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 960;
            animation1.To = 1760;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1760)
                {

                    dotTimer.Stop();
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True3.IsEnabled = true;
                    False3.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }


        private void False3_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 900;
            animation1.To = 185;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 185)
                {
                    
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;

                    if (userScore == 1)
                    {
                        tvScreen.Text = $"Better luck next time!\n Your Score: {userScore}";
                    }
                    else if (userScore == 2)
                    {
                        tvScreen.Text = $"You're almost there!\n Your Score: {userScore}";
                    }
                    else if (userScore == 3)
                    {
                        tvScreen.Text = $"Very well done!\n Your Score: {userScore}";
                    }
                    True1.Visibility = Visibility.Collapsed;
                    False1.Visibility = Visibility.Collapsed;
                    True2.Visibility = Visibility.Collapsed;
                    False2.Visibility = Visibility.Collapsed;
                    True3.Visibility = Visibility.Collapsed;
                    False3.Visibility = Visibility.Collapsed;
                }
            };

            storyboard.Begin();
        }

        private void True3_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 900;
            animation1.To = 185;
            animation1.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 185)
                {
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;

                    // No more questions, display the final score or handle game completion logic
                    if(userScore == 1)
                    {
                        tvScreen.Text = $"Better luck next time!\n Your Score: {userScore}";
                    } else if (userScore == 2)
                    {
                        tvScreen.Text = $"You're almost there!\n Your Score: {userScore}";
                    } else if(userScore == 3)
                    {
                        tvScreen.Text = $"Very well done!\n Your Score: {userScore}";
                    }
                    BackToDashboard.Visibility = Visibility.Visible;
                    GoToNextLesson.Visibility = Visibility.Visible;

                    True1.Visibility = Visibility.Collapsed;
                    False1.Visibility = Visibility.Collapsed;
                    True2.Visibility = Visibility.Collapsed;
                    False2.Visibility = Visibility.Collapsed;
                    True3.Visibility = Visibility.Collapsed;
                    False3.Visibility = Visibility.Collapsed;

                }
            };

            storyboard.Begin();
        }

        // Dot Animation // 
        private void DotAnimationTimer()
        {
            dotCount = 0;
            dotTimer = new DispatcherTimer();
            dotTimer.Interval = TimeSpan.FromSeconds(0.2);
            dotTimer.Tick += DotAnimation;
            dotTimer.Start();
        }
        private void DotAnimation(object sender, EventArgs e)
        {
            // Increment dot count and update text
            dotCount = (dotCount + 1) % 4;
            string dots = new string('.', dotCount + 1);
            tvScreen.Text = dots;
        }

        // Tv Screen Animation // 
        private void DisplayCurrentQuestionOnTvScreen()
        {
            processingEvent = true;
            tvScreen.Text = "";

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += TextAnimationTimer_Tick;

            if (questionList[currentQuestionIndex].QuestionText.Length > 0)
            {
                currentCharIndex = 0;
                timer.Start();
            }
            else
            {
                processingEvent = false;
                printingInProgress = false;
            }
        }

        private void TextAnimationTimer_Tick(object sender, EventArgs e)
        {
            // Update the tvScreen with one more character
            if (currentCharIndex < questionList[currentQuestionIndex].QuestionText.Length)
            {
                tvScreen.Text = questionList[currentQuestionIndex].QuestionText.Substring(0, currentCharIndex + 1);
                currentCharIndex++;
            }
            else
            {
                // Stop the timer when the whole text is displayed
                timer.Stop();
                processingEvent = false;
                printingInProgress = false;

            }
        }

        private void MoveToNextQuestion()
        {
            if (currentQuestionIndex < questionList.Count - 1)
            {
                Debug.WriteLine(currentQuestionIndex + "wtf");
                currentQuestionIndex++;
            }
        }
        private void UpdateUserScoreText()
        {
            userScoreText.Text = $"Score: {userScore}";
        }

        private void BackToDashboard_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate("");
        }

        private void GoToNextLesson_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate("");
        }
    }
}
