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
    /// Interaction logic for Transitions.xaml
    /// </summary>
    public partial class Transitions : Page
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
            "Welcome back!",
            // 1
            "In the previous lesson, we learned about what States are.",
            // 2
            "Now let's move on to Transitions!",
            // 3
            "Transitions are like the arrows in a roadmap system. They show how the system moves from one state to another when it receives a specific input!",
            // 4
            "The lines connecting between each states are what we call \"Transitions\"!",
            // 5
            "Transitions connect one state to another, indicating how the system evolves or moves from its current condition to a new one.",
            // 6
            "They depict the change of state that occurs when a specific input is received by the system.",
            // 7
            "They define the rules or conditions under which a state change occurs, providing the fundamental mechanism for the automaton to process input and navigate through different states.",
            // 8
            "Now that's finished, let's test your learnings about Transitions!"
        };

        public Transitions(MainWindow mainWindow)
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

            if (currentIndex == 8)
            {
                Debug.WriteLine("11");
                spaceBar.Text = "";
                KeyDown -= MainWindow_KeyDown;
                StatesActivityBtn.Visibility = Visibility.Visible;
            }
        }

        private void StatesActivity_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new TransitionsActivity(mainWindow));
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

                if (currentIndex != 8)
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
