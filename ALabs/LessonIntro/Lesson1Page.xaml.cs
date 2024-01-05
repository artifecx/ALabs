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
        public Lesson1Page(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }

        private void btn1Click(object sender, RoutedEventArgs e)
        {
            
            mainWindow.mainFrame.Navigate(new TutorialIntro(mainWindow));

        }
        private void btn2Click(object sender, RoutedEventArgs e)
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
                "A Finite Automaton is a mathematical model depicting a system with a limited set of states, transitions between these states, and inputs that prompt these transitions." +
                "Limited Machines: Finite automatons are like machines with a limited set of possible states and transitions.\r\n" +
                "Restricted Systems: They represent systems with a finite number of possible conditions and movements.\r\n" +
                "Simple Models: Think of finite automatons as simple models of computation with a fixed number of states and transitions.";

            tbL.Text = text; 
            btn3.IsEnabled = true;
        }
        private void btn3Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Challenge1Intro(mainWindow));
            btn4.IsEnabled = true;
        }
        private void btn4Click(object sender, RoutedEventArgs e)
        {
            
            btn5.IsEnabled = true;
        }

        private void btn5Click(object sender, RoutedEventArgs e)
        {
            btn5.IsEnabled = true;
        }

        private void btn1_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over btn1.";
        }
        private void btn3_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over btn3.";
        }

        private void btn4_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over btn4.";
        }

        private void btn5_MouseEnter(object sender, MouseEventArgs e)
        {
            tbL.Text = "This is the text for Tutorial when hovering over btn5.";
        }
        private void btn1_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void btn3_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void btn4_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }

        private void btn5_MouseLeave(object sender, MouseEventArgs e)
        {
            tbL.Clear();
        }
    }
}
