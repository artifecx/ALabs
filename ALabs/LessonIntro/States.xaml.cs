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
    /// Interaction logic for States.xaml
    /// </summary>
    public partial class States : Page
    {
        // Counters
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
            "Welcome to A-Labs!",
            // 1
            "A place where you will start your journey\nin learning all about Automata Theory!",
            // 2
            "For starters, what is Automata Theory all about?",
            // 3
            "Imagine you are dealing with building blocks\nfor computers and programming...",
            // 4
            "Automata Theory is like exploring the rules and structures \nthat controls these building blocks!",
            // 5
            "In this case, lets explore how Automata theory works by it down by 3 parts:\n\n"
            + "1. State machines\n"
            + "2. Transitions\n"
            + "3. Input\n",
            // 6
            "What are State Machines?",
            // 7
            "States in Automata Theory represent different situations or conditions that a system can be in at any given moment.",
            // 8
            "These dormant ellipses are \"states\".",
            // 9
            "They  help model the behavior of a system by capturing its current state and possible transitions to other states based on input.",
            // 10
            "States play a crucial role in defining the overall structure of automata and are essential for understanding how a system progresses from one state to another in response to input.",
            // 11
            "Now that we have all of that out of the way,\n"
            + "Let's have you challenge yourself to some quizzes!"
        };

        
        public States(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            InitializeTvScreen();
            RunAnimationLoop();
        }
        private bool endAnimation = false;
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Lesson1Page(mainWindow));
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

                // Set the state to indicate that printing is in progress
                printingInProgress = true;

                // Stop the timer and reset charIndex when spacebar is pressed T_T 
                timer.Stop();

                charIndex = 0;
                currentIndex = (currentIndex + 1) % textList.Count;
                // Change text on spacebar press
                UpdateTvScreenText();

            }

            if (currentIndex == 11)
            {
                Debug.WriteLine("11");
                spaceBar.Text = "";
                KeyDown -= MainWindow_KeyDown;
                StatesActivityBtn.Visibility = Visibility.Visible;
            }
        }

        private void StatesActivity_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new StatesActivity(mainWindow));
        }

        private void UpdateTvScreenText()
        {
            // Start the timer to print text character by character
            timer.Start();
        }

        private int stringArrCount = 0;
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
                // Stop the timer when the entire string is printed
                timer.Stop();

                // Set the state to indicate that printing is complete
                printingInProgress = false;

                if(currentIndex != 11)
                {
                    spaceBar.Text = "Press spacebar to continue";
                }

            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
