using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ALabs.LessonNFA
{
    class LessonContent
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("ALabs.LessonNFA.ContentResources", typeof(LessonContent).Assembly);
        private static bool chapter1 = false;

        public static void DisplayContent1(StackPanel panel, Button button)
        {
            if (chapter1 == true)
            {
                button.IsEnabled = true;
            }
            else
            {
                button.IsEnabled = false;
            }

            // Get all the keys starting with "C1" from the resource manager, reverse the order
            var entries = ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(entry => entry.Key.ToString().StartsWith("C1P"))
                .Reverse();
            var questions = ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(question => question.Key.ToString().StartsWith("C1Q"))
                .Reverse();

            foreach (var entry in entries)
            {
                if (!entry.Key.ToString().EndsWith("E1") && !entry.Key.ToString().EndsWith("E2"))
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Text = entry.Value.ToString() + "\n",
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 16,
                        Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15,15,15,0) : new Thickness(15,0,15,0)
                    };

                    panel.Children.Add(textBlock);
                }
                else
                {
                    continue;
                }

                if (entry.Key.ToString().EndsWith("P2"))
                {
                    // Create a StackPanel for images
                    StackPanel imagePanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    Image image1 = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C1E1.png", UriKind.Absolute)),
                        Width = 650,
                        Stretch = Stretch.Uniform
                    };

                    Image image2 = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C1E2.png", UriKind.Absolute)),
                        Width = 650,
                        Stretch = Stretch.Uniform 
                    };

                    imagePanel.Children.Add(image1);
                    imagePanel.Children.Add(image2);

                    panel.Children.Add(imagePanel);
                }
            }

            foreach(var question in questions)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 800,
                    Margin = new Thickness(0,0,0,15)
                };

                StackPanel questionPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };

                TextBlock textBlock = new TextBlock
                {
                    Text = question.Value.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = new Thickness(10)
                };

                RadioButton radioButtonTrue = new RadioButton
                {
                    Content = "True",
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10,0,0,0)
                };

                RadioButton radioButtonFalse = new RadioButton
                {
                    Content = "False",
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                Button submitButton = new Button
                {
                    Content = "Submit",
                    Width = 100,
                    FontSize = 16,
                    Margin = new Thickness(0,0,0,10)
                };

                TextBlock resultTextBlock = new TextBlock 
                { 
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Padding = new Thickness(0,0,0,10)
                };
                submitButton.Click += (sender, e) =>
                {
                    if (radioButtonTrue.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C1A1");
                        resultTextBlock.Foreground = Brushes.Green;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);

                        chapter1 = true;
                    }
                    else if (radioButtonFalse.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C1A2");
                        resultTextBlock.Foreground = Brushes.Red;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);
                    }

                    if (chapter1 == true)
                    {
                        button.IsEnabled = true;
                    }
                    else
                    {
                        button.IsEnabled = false;
                    }
                };

                radioButtonTrue.Click += (sender, e) => radioButtonFalse.IsChecked = false;
                radioButtonFalse.Click += (sender, e) => radioButtonTrue.IsChecked = false;

                questionPanel.Children.Add(textBlock);
                questionPanel.Children.Add(radioButtonTrue);
                questionPanel.Children.Add(radioButtonFalse);
                questionPanel.Children.Add(submitButton);

                border.Child = questionPanel;

                panel.Children.Add(border);
            }
        }
    }
}