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
using ALabs.Database;

namespace ALabs.LessonIntro
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class Input : Page
    {
        private readonly User authenticatedUser;
        private int currentIndex = 0;
        private int charIndex = 0;

        // Object stuff
        private DispatcherTimer timer;
        private readonly MainWindow mainWindow;

        // Flags
        private bool printingInProgress = false;
        private bool processingEvent = false;

        private List<string> textList = new List<string>
            {   
            // 0
            "We're down to the last topic for this lesson!",
            // 1
            "In the previous lesson, we learned about what Transitions are.",
            // 2
            "Let's move on to Inputs!",
            // 3
            "In Automata Theory, an \"input\" refers to the symbols or signals that a system processes, triggering transitions between different states ",
            // 4
            "The circle traversing throughout the program is the \"Input\" in this case!",
            // 5
            "Input is the information or data provided to a system.",
            // 6
            "It's like the set of instructions given to a machine or process.",
            // 7
            "In formal definition, Inputs are the signals or symbols that an automaton receives to determine its next action or state!",
            // 8
            "Now that's finished, let's get this quiz over with, shall we?",
        };
        public Input(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            InitializeTvScreen();
            RunAnimationLoop();
            this.authenticatedUser = authenticatedUser;
        }

        private bool endAnimation = false;

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Lesson1Page(mainWindow, authenticatedUser));
        }

        private void InitializeTvScreen()
        {
            tvScreen.Text = "";
            spaceBar.Text = "";

            Loaded += (s, e) => Focus();
            KeyDown += MainWindow_KeyDown;
            Loaded += (s, e) => myGrid.Focus();


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;

            // Initial text
            UpdateTvScreenText();
        }
        private void StopAnimations()
        {
            // Stop the timer
            timer.Stop();

            // Stop any ongoing storyboards or animations
            // Add additional storyboard or animation stopping logic based on your specific implementation
            // Example:
            animatedObject.BeginAnimation(Canvas.TopProperty, null);
            animatedObject2.BeginAnimation(Canvas.LeftProperty, null);
            animatedObject3.BeginAnimation(Canvas.TopProperty, null);
        }

        private async void RunAnimationLoop()
        {
            // add Flag here to end while loop
            while (endAnimation == false)
            {
                Debug.WriteLine(endAnimation);
                await PathAnimationTop1();
                await PathAnimationLeft1();
                await PathAnimationLeft2();
                await PathAnimationTop2();
            }
        }
        private Task PathAnimationTop1()
        {
            var tcs = new TaskCompletionSource<object>();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 185;
            animation.To = 920;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == 920 && !processingEvent)
                {
                    Debug.WriteLine("AHUAHUA top");
                    tcs.SetResult(null); // Signal completion
                }
            };

            storyboard.Begin();

            return tcs.Task;
        }
        private Task PathAnimationLeft1()
        {
            var tcs = new TaskCompletionSource<object>();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 150;
            animation.To = 960;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject2);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject2) == 960 && !processingEvent)
                {
                    Debug.WriteLine("AHUAHUA left");
                    tcs.SetResult(null); // Signal completion
                }
            };

            storyboard.Begin();

            return tcs.Task;
        }
        private Task PathAnimationLeft2()
        {
            var tcs = new TaskCompletionSource<object>();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 960;
            animation.To = 1760;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject2);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject2) == 1760 && !processingEvent)
                {
                    Debug.WriteLine("AHUAHUA left");
                    tcs.SetResult(null); // Signal completion
                }
            };

            storyboard.Begin();

            return tcs.Task;
        }
        private Task PathAnimationTop2()
        {
            var tcs = new TaskCompletionSource<object>();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 900;
            animation.To = 185;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject3);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject3) == 185 && !processingEvent)
                {
                    storyboard.Stop();
                    Canvas.SetLeft(animatedObject, 140);
                    Canvas.SetTop(animatedObject, 175);
                    Debug.WriteLine("AHUAHUA top");
                    tcs.SetResult(null);
                }
            };

            storyboard.Begin();

            return tcs.Task;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && !printingInProgress)
            {
                spaceBar.Text = "";
                tvScreen.Text = ""; // Clears the txtbox before running again
                Debug.WriteLine("Spacebar is pressed");

                printingInProgress = true;

                timer.Stop();

                charIndex = 0;
                currentIndex = (currentIndex + 1) % textList.Count;
                UpdateTvScreenText();

            }

            if (currentIndex == 8)
            {
                spaceBar.Text = "";
                KeyDown -= MainWindow_KeyDown;
                InputActivityBtn.Visibility = Visibility.Visible;
            }
        }

        private void StatesActivity_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new TransitionsActivity(mainWindow, authenticatedUser));
        }

        private void UpdateTvScreenText()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Print characters one by one
            if (charIndex < textList[currentIndex].Length)
            {
                tvScreen.Text += textList[currentIndex][charIndex];
                charIndex++;
            }
            else
            {
                timer.Stop();
                printingInProgress = false;

                if (currentIndex != 8)
                {
                    spaceBar.Text = "Press spacebar to continue";
                }

            }
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {

        }
        private void InputActivityBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new InputActivity(mainWindow, authenticatedUser));
        }
    }
}
