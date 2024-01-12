using ALabs.Database;
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
    /// Interaction logic for IntroductionQuiz.xaml
    /// </summary>
    public partial class IntroductionQuiz : Page
    {
        private readonly MainWindow mainWindow;
        private User authenticatedUser;

        // This code is strictly and lazily made for this True/False quiz game.
        // You can add as many questions as you want. Provided that you manually set the paths for the animations and assign the correct and incorrect answers

        private List<Question> questionList = new List<Question>
        {   
            // 0
            new Question("Inputs are the symbols or signals that an automation receives, triggering transitions between states and influencing its behavior.", true),
            // 1
            new Question("Input is the information or data provided to a system by which the automaton reads and accepts when the input is accepted by the predetermined states. ", true),
            // 2
            new Question("An Automaton can function without an input.", true),
            // 3
            new Question("Inputs are the symbols or signals that an automation receives, triggering transitions between states and influencing its behavior.", true),
            // 4
            new Question("Input is the information or data provided to a system by which the automaton reads and accepts when the input is accepted by the predetermined states. ", true),
            // 5
            new Question("An Automaton can function without an input.", true),
            // 6
            new Question("Inputs are the symbols or signals that an automation receives, triggering transitions between states and influencing its behavior.", true),
            // 7
            new Question("Input is the information or data provided to a system by which the automaton reads and accepts when the input is accepted by the predetermined states. ", true),
            // 8
            new Question("An Automaton can function without an input.", true),
            // 9
            new Question("Inputs are the symbols or signals that an automation receives, triggering transitions between states and influencing its behavior.", true),
            // 10
            new Question("Input is the information or data provided to a system by which the automaton reads and accepts when the input is accepted by the predetermined states. ", true),
            // 11
            new Question("...", false),


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
        public IntroductionQuiz(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;
            True1.Click += True1_Click;
            False1.Click += False1_Click;
            True2.Click += True2_Click;
            False2.Click += False2_Click;
            True3.Click += True3_Click;
            False3.Click += False3_Click;
            True4.Click += True4_Click;
            False4.Click += False4_Click;
            True5.Click += True5_Click;
            False5.Click += False5_Click;
            True6.Click += True6_Click;
            False6.Click += False6_Click;
            True7.Click += True7_Click;
            False7.Click += False7_Click;
            True8.Click += True8_Click;
            False8.Click += False8_Click;
            True9.Click += True9_Click;
            False9.Click += False9_Click;
            True10.Click += True10_Click;
            False10.Click += False10_Click;
            BackToDashboard.Click += BackToDashboard_Click;

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
            True4.IsEnabled = false;
            False4.IsEnabled = false;
            True5.IsEnabled = false;
            False5.IsEnabled = false;
            True6.IsEnabled = false;
            False6.IsEnabled = false;
            True7.IsEnabled = false;
            False7.IsEnabled = false;
            True8.IsEnabled = false;
            False8.IsEnabled = false;
            True9.IsEnabled = false;
            False9.IsEnabled = false;
            True10.IsEnabled = false;
            False10.IsEnabled = false;

            True2.Visibility = Visibility.Collapsed;
            False2.Visibility = Visibility.Collapsed;
            True3.Visibility = Visibility.Collapsed;
            False3.Visibility = Visibility.Collapsed;
            True4.Visibility = Visibility.Collapsed;
            False4.Visibility = Visibility.Collapsed;
            True5.Visibility = Visibility.Collapsed;
            False5.Visibility = Visibility.Collapsed;
            True6.Visibility = Visibility.Collapsed;
            False6.Visibility = Visibility.Collapsed;
            True7.Visibility = Visibility.Collapsed;
            False7.Visibility = Visibility.Collapsed;
            True8.Visibility = Visibility.Collapsed;
            False8.Visibility = Visibility.Collapsed;
            True9.Visibility = Visibility.Collapsed;
            False9.Visibility = Visibility.Collapsed;
            True10.Visibility = Visibility.Collapsed;
            False10.Visibility = Visibility.Collapsed;
            BackToDashboard.Visibility = Visibility.Collapsed;


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 185;
            animation1.To = 366;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 366)
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
            animation1.From = 366;
            animation1.To = 621;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 621)
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
            animation1.From = 366;
            animation1.To = 621;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 621)
                {
                    // Answer is True
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
            animation1.From = 621;
            animation1.To = 920;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 920)
                {
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
            animation1.From = 621;
            animation1.To = 920;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 920)
                {
                    // Answer is True
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


        private void False3_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True3.Visibility = Visibility.Collapsed;
            False3.Visibility = Visibility.Collapsed;
            True4.Visibility = Visibility.Visible;
            False4.Visibility = Visibility.Visible;
            True3.IsEnabled = false;
            False3.IsEnabled = false;
            True4.IsEnabled = false;
            False4.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 150;
            animation1.To = 380;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 380)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True4.IsEnabled = true;
                    False4.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True3_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True3.Visibility = Visibility.Collapsed;
            False3.Visibility = Visibility.Collapsed;
            True4.Visibility = Visibility.Visible;
            False4.Visibility = Visibility.Visible;
            True3.IsEnabled = false;
            False3.IsEnabled = false;
            True4.IsEnabled = false;
            False4.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 150;
            animation1.To = 380;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 380)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True4.IsEnabled = true;
                    False4.IsEnabled = true;


                }
            };

            storyboard.Begin();
        }

        private void False4_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True4.Visibility = Visibility.Collapsed;
            False4.Visibility = Visibility.Collapsed;
            True5.Visibility = Visibility.Visible;
            False5.Visibility = Visibility.Visible;
            True4.IsEnabled = false;
            False4.IsEnabled = false;
            True5.IsEnabled = false;
            False5.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 380;
            animation1.To = 715;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 715)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True5.IsEnabled = true;
                    False5.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True4_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True4.Visibility = Visibility.Collapsed;
            False4.Visibility = Visibility.Collapsed;
            True5.Visibility = Visibility.Visible;
            False5.Visibility = Visibility.Visible;
            True4.IsEnabled = false;
            False4.IsEnabled = false;
            True5.IsEnabled = false;
            False5.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 380;
            animation1.To = 715;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 715)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True5.IsEnabled = true;
                    False5.IsEnabled = true;


                }
            };

            storyboard.Begin();
        }

        private void False5_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True5.Visibility = Visibility.Collapsed;
            False5.Visibility = Visibility.Collapsed;
            True6.Visibility = Visibility.Visible;
            False6.Visibility = Visibility.Visible;
            True5.IsEnabled = false;
            False5.IsEnabled = false;
            True6.IsEnabled = false;
            False6.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 715;
            animation1.To = 1042;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1042)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True6.IsEnabled = true;
                    False6.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True5_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True5.Visibility = Visibility.Collapsed;
            False5.Visibility = Visibility.Collapsed;
            True6.Visibility = Visibility.Visible;
            False6.Visibility = Visibility.Visible;
            True5.IsEnabled = false;
            False5.IsEnabled = false;
            True6.IsEnabled = false;
            False6.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 715;
            animation1.To = 1042;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1042)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True6.IsEnabled = true;
                    False6.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void False6_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True6.Visibility = Visibility.Collapsed;
            False6.Visibility = Visibility.Collapsed;
            True7.Visibility = Visibility.Visible;
            False7.Visibility = Visibility.Visible;
            True6.IsEnabled = false;
            False6.IsEnabled = false;
            True7.IsEnabled = false;
            False7.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 1042;
            animation1.To = 1384;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1384)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True7.IsEnabled = true;
                    False7.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True6_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True6.Visibility = Visibility.Collapsed;
            False6.Visibility = Visibility.Collapsed;
            True7.Visibility = Visibility.Visible;
            False7.Visibility = Visibility.Visible;
            True6.IsEnabled = false;
            False6.IsEnabled = false;
            True7.IsEnabled = false;
            False7.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 1042;
            animation1.To = 1384;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1384)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True7.IsEnabled = true;
                    False7.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void False7_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True7.Visibility = Visibility.Collapsed;
            False7.Visibility = Visibility.Collapsed;
            True8.Visibility = Visibility.Visible;
            False8.Visibility = Visibility.Visible;
            True7.IsEnabled = false;
            False7.IsEnabled = false;
            True8.IsEnabled = false;
            False8.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 1384;
            animation1.To = 1760;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1760)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True8.IsEnabled = true;
                    False8.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True7_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True7.Visibility = Visibility.Collapsed;
            False7.Visibility = Visibility.Collapsed;
            True8.Visibility = Visibility.Visible;
            False8.Visibility = Visibility.Visible;
            True7.IsEnabled = false;
            False7.IsEnabled = false;
            True8.IsEnabled = false;
            False8.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 1384;
            animation1.To = 1760;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == 1760)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True8.IsEnabled = true;
                    False8.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void False8_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True8.Visibility = Visibility.Collapsed;
            False8.Visibility = Visibility.Collapsed;
            True9.Visibility = Visibility.Visible;
            False9.Visibility = Visibility.Visible;
            True8.IsEnabled = false;
            False8.IsEnabled = false;
            True9.IsEnabled = false;
            False9.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 920;
            animation1.To = 621;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 621)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True9.IsEnabled = true;
                    False9.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True8_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True8.Visibility = Visibility.Collapsed;
            False8.Visibility = Visibility.Collapsed;
            True9.Visibility = Visibility.Visible;
            False9.Visibility = Visibility.Visible;
            True8.IsEnabled = false;
            False8.IsEnabled = false;
            True9.IsEnabled = false;
            False9.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 920;
            animation1.To = 621;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 621)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True9.IsEnabled = true;
                    False9.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void False9_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            True9.Visibility = Visibility.Collapsed;
            False9.Visibility = Visibility.Collapsed;
            True10.Visibility = Visibility.Visible;
            False10.Visibility = Visibility.Visible;
            True9.IsEnabled = false;
            False9.IsEnabled = false;
            True10.IsEnabled = false;
            False10.IsEnabled = false;

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 621;
            animation1.To = 366;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 366)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True10.IsEnabled = true;
                    False10.IsEnabled = true;

                }
            };

            storyboard.Begin();
        }

        private void True9_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            True9.Visibility = Visibility.Collapsed;
            False9.Visibility = Visibility.Collapsed;
            True10.Visibility = Visibility.Visible;
            False10.Visibility = Visibility.Visible;
            True9.IsEnabled = false;
            False9.IsEnabled = false;
            True10.IsEnabled = false;
            False10.IsEnabled = false;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 621;
            animation1.To = 366;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 366)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;
                    DisplayCurrentQuestionOnTvScreen();
                    True10.IsEnabled = true;
                    False10.IsEnabled = true;
                }
            };

            storyboard.Begin();
        }

        private void False10_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();
            

            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 366;
            animation1.To = 150;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 150)
                {
                    // Answer is False
                    userScore = userScore + 1;
                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    isAnimationInProgress = false;

                    BackToDashboard.Visibility = Visibility.Visible;

                    True10.Visibility = Visibility.Collapsed;
                    False10.Visibility = Visibility.Collapsed;

                }
            };

            storyboard.Begin();
        }

        private void True10_Click(object sender, RoutedEventArgs e)
        {
            dotTimer.Start();

            if (isAnimationInProgress)
                return;
            

            isAnimationInProgress = true;
            Debug.WriteLine(currentQuestionIndex + "dqweqwe");
            MoveToNextQuestion();


            DoubleAnimation animation1 = new DoubleAnimation();
            animation1.From = 366;
            animation1.To = 150;
            animation1.Duration = TimeSpan.FromSeconds(1);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation1);

            Storyboard.SetTarget(animation1, animatedObject);
            Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.TopProperty));


            animation1.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 150)
                {

                    UpdateUserScoreText();
                    dotTimer.Stop();
                    EndStateReached = true;
                    Debug.WriteLine("Endstate reached!");
                    isAnimationInProgress = false;

                    BackToDashboard.Visibility = Visibility.Visible;

                    True10.Visibility = Visibility.Collapsed;
                    False10.Visibility = Visibility.Collapsed;

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
            using (UserDataContext context = new UserDataContext())
            {
                // Retrieve the user from the database
                User userToUpdate = context.Users.FirstOrDefault(user => user.Id == authenticatedUser.Id);

                if (userToUpdate != null && authenticatedUser.lesson1progress < 4)
                {
                    // Update the lesson2progress property
                    userToUpdate.lesson1progress = 4;

                    // Save changes to the database
                    context.SaveChanges();

                    // Update the authenticatedUser in memory to reflect the changes
                    authenticatedUser.lesson1progress = userToUpdate.lesson1progress;

                    MessageBox.Show("User's lesson 2 progress updated!");
                }
            }
            mainWindow.mainFrame.Navigate(new Lesson1Page(mainWindow, authenticatedUser));
        }
    }
}
