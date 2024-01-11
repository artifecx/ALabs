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
        private User authenticatedUser;
        private int lesson1progress;
        public Lesson1Page(MainWindow mainWindow, User authenticatedUser)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.authenticatedUser = authenticatedUser;

            lesson1progress = authenticatedUser.lesson1progress;

            if(lesson1progress == 2)
            {
                Transitions.IsEnabled = true;
            }
            if(lesson1progress == 3)
            {
                Transitions.IsEnabled = true;
                Inputs.IsEnabled = true;
                ATInfo.IsEnabled = true;
            }
            if(lesson1progress == 4)
            {
                Transitions.IsEnabled = true;
                Inputs.IsEnabled = true;
                ATInfo.IsEnabled = true;
                IntroductionQuiz.IsEnabled = true;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }

        private void States_Click(object sender, RoutedEventArgs e)
        {
             mainWindow.mainFrame.Navigate(new States(mainWindow, authenticatedUser));
        }

        private void Transitions_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Transitions(mainWindow));
        }

        private void Inputs_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Input(mainWindow));
        }

        private void IntroductionQuiz_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate("");
        }

        private void ATInfo_Click(object sender, RoutedEventArgs e)
        {
            String text = "Automata Theory:\r\n\r\n" +
                "Complex Machines: Automata theory is like studying complex machines that follow specific rules or patterns.\r\n" +
                "Patterns and Rules: It's a branch of computer science that deals with understanding and designing systems that follow certain patterns or rules.\r\n" +
                "Modeling Systems: Think of it as creating models to represent how different systems or processes work, especially in the context of computation.\r\n\r\n\r\n" +

                "States:\r\n\r\n" +
                "In the context of automata theory, a \"state\" refers to a condition or situation in which a system or process can exist at a given point in time.\r\n" +
                "Conditions: States are like different conditions or situations a system can be in.\r\n" +
                "Stages: They represent various stages that a process or machine can go through.\r\n" +
                "Positions: Think of states as specific positions that a system occupies at a given time.\r\n\r\n\r\n" +
                "" +
                "Transitions:\r\n\r\n" +
                "These refer to the changes in the state of a system based on certain events, inputs, or conditions. They define how a system moves from one state to another, influencing its behavior or output." +
                "Changes: Transitions are the movements or changes from one state to another.\r\n" +
                "Shifts: They describe how a system moves or shifts from one condition to another.\r\n" +
                "Progression: Think of transitions as the progression or flow between different stages in a process.\r\n\r\n\r\n" +
                "" +
                "Input:\r\n\r\n" +
                "In Automata Theory, an \"input\" refers to the symbols or signals that a system processes, triggering transitions between different states. \r\n" +
                "Data In: Input is the information or data provided to a system.\r\n" +
                "Instructions: It's like the set of instructions given to a machine or process.\r\n" +
                "Starting Point: Input is what kick-starts the functioning of a system.\r\n\r\n\r\n"
                +
                "Finite Automatons:\r\n\r\n" +
                "A Finite Automaton is a mathematical model depicting a system with a limited set of states, transitions between these states, and inputs that prompt these transitions.\r\n" +
                "Limited Machines: Finite automatons are like machines with a limited set of possible states and transitions.\r\n" +
                "Restricted Systems: They represent systems with a finite number of possible conditions and movements.\r\n" +
                "Simple Models: Think of finite automatons as simple models of computation with a fixed number of states and transitions.";

            tbL.Text = text;
            // btn3.IsEnabled = true;
        }

        private void States_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over States.";
        }

        private void Transitions_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over Transitions.";
        }

        private void Inputs_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over Inputs.";
        }

        private void IntroductionQuiz_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over IntroductionQuiz.";
        }

        private void States_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void Transitions_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void Inputs_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void IntroductionQuiz_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }
    }
}
