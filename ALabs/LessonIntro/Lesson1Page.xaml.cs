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

        private List<string> textList = new List<string>
        {
            "Welcome to A-Labs!",
            "A place where you will start your journey\nin learning all about Automata Theory!",
            "For starters, what is Automata Theory all about?",
            "Imagine you are dealing with building blocks\nfor computers and programming...",
            "Automata Theory is like exploring the rules and structures \nthat controls these building blocks!",
            "In this case, lets explore how Automata theory works by it down by 3 parts:\n\n"
            + "1. State machines\n"
            + "2. Transitions\n"
            + "3. Input\n"
            + "4. Finite Automaton (FA)\n",

            "State Machines:" +
            "\n\nIn the context of automata theory, a \"state\" refers to a condition or situation\n"
            + " in which a system or process can exist at a given point in time.",

            "This is an example of a state.\n"
            + "Normally, it does not look like this but for visualization purposes,\n"
            + "it accompanies a condition wherein it accepts or unaccepts an input.",

            "Transitions:"
            + "\n\nThese refer to the changes in the state of a system\n"
            + "based on certain events, inputs, or conditions.\n",

            "They define how a system moves from one state to another, \n"
            + "influencing its behavior or output.\n"
            + "\nAs for now, these 'lines' will serve as our best example for transitioning inputs.",

            "Inputs:\n\n"
            + "In Automata Theory, an \"input\" refers to the symbols or signals that a \n"
            + "system processes,triggering transitions between different states.",

            "This circle traversing through the lines serves as the input for this machine.",

            "Finite Automaton:\n\n"
            + "A Finite Automaton is a mathematical model depicting a system with a \n"
            + "limited set of states, transitions between these states, and inputs that prompt these transitions.",

            "In this case, with all of the three (State, Transitions, and Input) combined, "
            + "you have a Finite Automaton!"

        };
        private int currentIndex = 0;
        private int charIndex = 0;
        private DispatcherTimer timer;
        private bool printingInProgress = false;
        private int animationCounter = 0;


        public Lesson1Page(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            #region TV SCREEN
            tvScreen.Text = "";
            spaceBar.Text = "";
            // Attach key down event to the window
            Loaded += (s, e) => Focus();
            KeyDown += MainWindow_KeyDown;


            // Set focus to the Canvas
            Loaded += (s, e) => myGrid.Focus();
            //// Subscribe to the Loaded event to start the animation when the page is loaded.
            //Loaded += OnPageLoaded;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10); // Adjust interval as needed
            timer.Tick += Timer_Tick;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            Debug.WriteLine($"Screen Width: {screenWidth}, Screen Height: {screenHeight}");
            
            // Initial text
            UpdateTvScreenText();
            #endregion

            RunAnimationLoop();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }

        private async void RunAnimationLoop()
        {
            while (true)
            {
                await Task.Delay(1000);
                Dispatcher.Invoke(() => PathAnimationTop(185, 920));
                await Task.Delay(4000);
                Dispatcher.Invoke(() => PathAnimationLeft(150, 960));
                await Task.Delay(4000);
                Dispatcher.Invoke(() => PathAnimationLeft(960, 1760));
                await Task.Delay(4000);
                Dispatcher.Invoke(() => PathAnimationTop(900, 185));
                await Task.Delay(4000);

            }
        }

        private void PathAnimationLeft(double startX, double endpointX)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = startX;
            animation.To = endpointX;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetLeft(animatedObject) == endpointX)
                {
                    Debug.WriteLine("AHUAHUA left");

                }
            };

            storyboard.Begin();

        }

        private void PathAnimationTop(double startY, double endpointY)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = startY;
            animation.To = endpointY;
            animation.Duration = TimeSpan.FromSeconds(3);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);

            Storyboard.SetTarget(animation, animatedObject);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));

            animation.Completed += (sender, e) =>
            {
                if (Canvas.GetTop(animatedObject) == endpointY)
                {

                    Debug.WriteLine("AHUAHUA top");

                    //if (animationCounter > 2)
                    //{
                    //    // Reset the position of animatedObject
                    //    Canvas.SetLeft(animatedObject, 140);
                    //    Canvas.SetTop(animatedObject, 175);
                    //}

                }
            };

            storyboard.Begin();
        }




        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {

            // Check if the pressed key is the spacebar
            if (e.Key == Key.Space && !printingInProgress)
            {
                spaceBar.Text = "";
                tvScreen.Text = ""; // Clears the txtbox before running again
                Debug.WriteLine("Spacebar is pressed");

                // Set the state to indicate that printing is in progress
                printingInProgress = true;

                // Stop the timer and reset charIndex when spacebar is pressed
                timer.Stop();

                charIndex = 0;
                currentIndex = (currentIndex + 1) % textList.Count;
                // Change text on spacebar press
                UpdateTvScreenText();

            }
        }

        private void UpdateTvScreenText()
        {
            // Start the timer to print text character by character
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
                // Stop the timer when the entire string is printed
                timer.Stop();

                // Set the state to indicate that printing is complete
                printingInProgress = false;

                spaceBar.Text = "Press spacebar to continue";
            }
        }

    }
}
