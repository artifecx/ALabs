﻿using System;
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

namespace ALabs.LessonNFA
{
    /// <summary>
    /// Interaction logic for Lesson3Page.xaml
    /// </summary>
    public partial class Lesson3Page : Page
    {
        private readonly MainWindow mainWindow;
        public Lesson3Page(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new LessonsPage(mainWindow));
        }
    }
}
