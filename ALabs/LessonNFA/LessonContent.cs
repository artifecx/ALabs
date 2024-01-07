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

        public static void DisplayContent1(StackPanel panel)
        {
            // Get all the keys starting with "C1" from the resource manager, reverse the order
            var entries = ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(entry => entry.Key.ToString().StartsWith("C1"))
                .Reverse();

            foreach (var entry in entries)
            {
                if (!entry.Key.ToString().EndsWith("E1") && !entry.Key.ToString().EndsWith("E2"))
                {
                    TextBlock textBlock = new TextBlock
                    {
                        Text = entry.Value.ToString() + "\n",
                        TextWrapping = TextWrapping.Wrap,
                        Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(10,10,0,0) : new Thickness(10, 0, 0, 0)
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
                        Width = 600,
                        Stretch = Stretch.Uniform
                    };

                    Image image2 = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C1E2.png", UriKind.Absolute)),
                        Width = 600,
                        Stretch = Stretch.Uniform 
                    };

                    imagePanel.Children.Add(image1);
                    imagePanel.Children.Add(image2);

                    panel.Children.Add(imagePanel);
                }
            }
        }
    }
}