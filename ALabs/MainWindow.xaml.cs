using System;
using System.Collections.Generic;
using System.Configuration;
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
using ALabs.Database;

namespace ALabs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User authenticatedUser;
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new UserLogin(this, authenticatedUser));
        }

        public void CloseMainWindow()
        {
            // Close the main window
            Close();
        }
    }
}
