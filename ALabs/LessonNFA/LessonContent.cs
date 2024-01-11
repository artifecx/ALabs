using ALabs.LessonIntro;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Windows.Threading;

namespace ALabs.LessonNFA
{
    class LessonContent
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("ALabs.LessonNFA.ContentResources", typeof(LessonContent).Assembly);
        private static Dictionary<int, bool> chapterStatus = new Dictionary<int, bool>();
        private static DispatcherTimer? revealTimer;
        private static RadioButton? radioButtonA;
        private static RadioButton? radioButtonB;

        public static IEnumerable<DictionaryEntry> AssignVar(string start, int end)
        {
            List<DictionaryEntry> entries = new List<DictionaryEntry>();
            for (int i = 1; i <= end; i++)
            {
                string key = $"{start}{i}";
                DictionaryEntry entry = new DictionaryEntry
                {
                    Key = key,
                    Value = ResourceManager.GetString(key)
                };
                entries.Add(entry);
            }
            return entries;
        }

        public static void SetButtonState(Button button, bool isChapterEnabled)
        {
            button.IsEnabled = isChapterEnabled;
        }

        public static void CompleteChapter(int chapterNumber)
        {
            if (!chapterStatus.ContainsKey(chapterNumber))
            {
                chapterStatus.Add(chapterNumber, false);
            }

            chapterStatus[chapterNumber] = true;
        }

        public static bool GetChapterStatus(int chapterNumber)
        {
            return chapterStatus.TryGetValue(chapterNumber, out bool status) ? status : false;
        }

        private static async void DisplayChapter(StackPanel panel, Button button, int chapterNumber, string prefixP, string positionQ, int paragraphCount, int imageCount, bool skip)
        {
            var entries = AssignVar($"{prefixP}", paragraphCount);

            foreach (var entry in entries)
            {
                /*TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);*/

                await RevealText(panel, entry.Value.ToString(), 5, skip);

                if (entry.Key.ToString().EndsWith(positionQ))
                {
                    MessageBox.Show("Here");
                    StackPanel imagePanel = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    for (int i = 1; i <= imageCount; i++)
                    {
                        Image image = new Image
                        {
                            Source = new BitmapImage(new Uri($"pack://application:,,,/ALabs;component/Resources/C{chapterNumber}E{i}.png", UriKind.Absolute)),
                            Width = 650,
                            Stretch = Stretch.Uniform
                        };

                        imagePanel.Children.Add(image);
                    }

                    panel.Children.Add(imagePanel);
                }
            }

            DisplayQuestion(panel, button, chapterNumber);
        }

        public static void DisplayQuestion(StackPanel panel, Button button, int chapterNumber)
        {
            var questions = ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(question => question.Key.ToString().StartsWith($"C{chapterNumber}Q"));

            foreach (var question in questions)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 800,
                    Margin = new Thickness(15)
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

                if(chapterNumber == 1) { 
                    RadioButton radioButtonTrue = new RadioButton
                    {
                        Content = "True",
                        GroupName = "AnswerGroup",
                        FontSize = 16,
                        Margin = new Thickness(10, 0, 0, 0)
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
                        Margin = new Thickness(0, 0, 0, 10)
                    };

                    TextBlock resultTextBlock = new TextBlock
                    {
                        FontSize = 16,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextWrapping = TextWrapping.Wrap,
                        Padding = new Thickness(10)
                    };
                    submitButton.Click += (sender, e) =>
                    {
                        if (radioButtonTrue.IsChecked == true)
                        {
                            resultTextBlock.Text = ResourceManager.GetString("C1A1");
                            resultTextBlock.Foreground = Brushes.Green;
                            questionPanel.Children.Remove(resultTextBlock);
                            questionPanel.Children.Add(resultTextBlock);

                            CompleteChapter(1);
                        }
                        else if (radioButtonFalse.IsChecked == true)
                        {
                            resultTextBlock.Text = ResourceManager.GetString("C1A2");
                            resultTextBlock.Foreground = Brushes.Red;
                            questionPanel.Children.Remove(resultTextBlock);
                            questionPanel.Children.Add(resultTextBlock);
                        }

                        SetButtonState(button, GetChapterStatus(1));
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
                else if(chapterNumber == 2)
                {
                    Image image1 = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IBQ1.png", UriKind.Absolute)),
                        Height = 60,
                        Stretch = Stretch.Uniform
                    };

                    Image image2 = new Image
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IAQ1.png", UriKind.Absolute)),
                        Height = 60,
                        Stretch = Stretch.Uniform
                    };

                    RadioButton radioButtonA = new RadioButton
                    {
                        Content = image1,
                        GroupName = "AnswerGroup",
                        FontSize = 16,
                        Margin = new Thickness(10, 0, 0, 0)
                    };

                    RadioButton radioButtonB = new RadioButton
                    {
                        Content = image2,
                        GroupName = "AnswerGroup",
                        FontSize = 16,
                        Margin = new Thickness(10, 10, 0, 0)
                    };

                    Button submitButton = new Button
                    {
                        Content = "Submit",
                        Width = 100,
                        FontSize = 16,
                        Margin = new Thickness(0, 10, 0, 10)
                    };

                    TextBlock resultTextBlock = new TextBlock
                    {
                        FontSize = 16,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextWrapping = TextWrapping.Wrap,
                        Padding = new Thickness(10)
                    };
                    submitButton.Click += (sender, e) =>
                    {
                        if (radioButtonB.IsChecked == true)
                        {
                            resultTextBlock.Text = ResourceManager.GetString("C2A1");
                            resultTextBlock.Foreground = Brushes.Green;
                            questionPanel.Children.Remove(resultTextBlock);
                            questionPanel.Children.Add(resultTextBlock);

                            CompleteChapter(2);
                        }
                        else if (radioButtonA.IsChecked == true)
                        {
                            resultTextBlock.Text = ResourceManager.GetString("C2A2");
                            resultTextBlock.Foreground = Brushes.Red;
                            questionPanel.Children.Remove(resultTextBlock);
                            questionPanel.Children.Add(resultTextBlock);
                        }

                        SetButtonState(button, GetChapterStatus(2));
                    };

                    radioButtonA.Click += (sender, e) => radioButtonB.IsChecked = false;
                    radioButtonB.Click += (sender, e) => radioButtonA.IsChecked = false;

                    questionPanel.Children.Add(textBlock);
                    questionPanel.Children.Add(radioButtonA);
                    questionPanel.Children.Add(radioButtonB);
                    questionPanel.Children.Add(submitButton);

                    border.Child = questionPanel;

                    panel.Children.Add(border);
                }
            }
        }

        public static void DisplayChapter1(StackPanel panel, Button button, bool skip)
        {
            // StackPanel panel, Button button, int chapterNumber, string prefixP, string positionQ, string prefixQ, int paragraphCount, int imageCount
            DisplayChapter(panel, button, 1, "C1P", "P2", 4, 2, skip);
        }

        private static async Task RevealText(StackPanel panel, string text, int revealDelay, bool skipReveal)
        {
            int currentIndex = 0;

            if (revealTimer != null)
            {
                revealTimer.Stop();
            }

            revealTimer = new DispatcherTimer();
            revealTimer.Interval = TimeSpan.FromMilliseconds(revealDelay);

            TextBlock textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                FontSize = 16,
                Padding = new Thickness(15)
            };

            panel.Children.Add(textBlock);

            var tcs = new TaskCompletionSource<bool>();
            
            revealTimer.Tick += async (sender, e) =>
            {
                if (currentIndex < text.Length)
                {
                    if (skipReveal)
                    {
                        textBlock.Text = text; // Skip to the end
                        revealTimer.Stop();
                        tcs.SetResult(true); // Signal completion
                    }
                    else
                    {
                        textBlock.Text = text.Substring(0, currentIndex + 1);
                        currentIndex++;
                    }
                }
                else
                {
                    revealTimer.Stop();
                    tcs.SetResult(true); // Signal completion
                }
            };
            revealTimer.Start();

            await tcs.Task;
        }

        public static void DisplayChapter2(StackPanel panel, Button button, bool skip)
        {
            DisplayChapter(panel, button, 2, "C2P", "P4", 5, 1, skip);
        }

        public static void DisplayChapter3(StackPanel panel, Button button, bool skip)
        {
            DisplayChapter(panel, button, 3, "C3P", "P3", 4, 0, skip);
        }

        public static void DisplayChapter4(StackPanel panel, Button button, bool skip)
        {
            DisplayChapter(panel, button, 4, "C4P", "P3", 5, 0, skip);
        }

        public static void DisplayChapter5(StackPanel panel, Button button, bool skip)
        {
            DisplayChapter(panel, button, 5, "C5P", "P5", 6, 0, skip);
        }

        public static void DisplayChapter6(StackPanel panel, bool skip)
        {
            DisplayChapter(panel, null, 6, "C6P", "P3", 4, 0, skip);
        }

        /*public static void DisplayChapter1(StackPanel panel, Button button)
        {
            //SetButtonState(button, chapter1);

            var entries = AssignVar("C1P", 0, 4);
            var questions = AssignVar("C1Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

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
                    Padding = new Thickness(10)
                };
                submitButton.Click += (sender, e) =>
                {
                    if (radioButtonTrue.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C1A1");
                        resultTextBlock.Foreground = Brushes.Green;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);

                        CompleteChapter(1);
                    }
                    else if (radioButtonFalse.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C1A2");
                        resultTextBlock.Foreground = Brushes.Red;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);
                    }

                    SetButtonState(button, GetChapterStatus(1));
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

        public static void DisplayChapter2(StackPanel panel, Button button)
        {
            //SetButtonState(button, chapter2);

            var entries = AssignVar("C2P", 0, 5);
            var questions = AssignVar("C2Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

                if (entry.Key.ToString().EndsWith("P4"))
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
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2E1.png", UriKind.Absolute)),
                        Width = 650,
                        Stretch = Stretch.Uniform
                    };

                    imagePanel.Children.Add(image1);

                    panel.Children.Add(imagePanel);
                }
            }

            foreach (var question in questions)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 800,
                    Margin = new Thickness(0, 0, 0, 15)
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

                Image image1 = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IBQ1.png", UriKind.Absolute)),
                    Height = 60,
                    Stretch = Stretch.Uniform
                };

                Image image2 = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IAQ1.png", UriKind.Absolute)),
                    Height = 60,
                    Stretch = Stretch.Uniform
                };

                RadioButton radioButtonA = new RadioButton
                {
                    Content = image1,
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                RadioButton radioButtonB = new RadioButton
                {
                    Content = image2,
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10, 10, 0, 0)
                };

                Button submitButton = new Button
                {
                    Content = "Submit",
                    Width = 100,
                    FontSize = 16,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                TextBlock resultTextBlock = new TextBlock
                {
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Padding = new Thickness(10)
                };
                submitButton.Click += (sender, e) =>
                {
                    if (radioButtonB.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C2A1");
                        resultTextBlock.Foreground = Brushes.Green;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);

                        CompleteChapter(2);
                    }
                    else if (radioButtonA.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C2A2");
                        resultTextBlock.Foreground = Brushes.Red;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);
                    }

                    SetButtonState(button, GetChapterStatus(2));
                };

                radioButtonA.Click += (sender, e) => radioButtonB.IsChecked = false;
                radioButtonB.Click += (sender, e) => radioButtonA.IsChecked = false;

                questionPanel.Children.Add(textBlock);
                questionPanel.Children.Add(radioButtonA);
                questionPanel.Children.Add(radioButtonB);
                questionPanel.Children.Add(submitButton);

                border.Child = questionPanel;

                panel.Children.Add(border);
            }
        }

        public static void DisplayChapter3(StackPanel panel, Button button)
        {
            //SetButtonState(button, chapter2);

            var entries = AssignVar("C3P", 0, 4);
            var questions = AssignVar("C3Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

                if (entry.Key.ToString().EndsWith("P3"))
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
                        Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2E1.png", UriKind.Absolute)),
                        Width = 650,
                        Stretch = Stretch.Uniform
                    };

                    imagePanel.Children.Add(image1);

                    panel.Children.Add(imagePanel);
                }
            }

            foreach (var question in questions)
            {
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Width = 800,
                    Margin = new Thickness(0, 0, 0, 15)
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

                Image image1 = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IBQ1.png", UriKind.Absolute)),
                    Height = 60,
                    Stretch = Stretch.Uniform
                };

                Image image2 = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/ALabs;component/Resources/C2IAQ1.png", UriKind.Absolute)),
                    Height = 60,
                    Stretch = Stretch.Uniform
                };

                RadioButton radioButtonA = new RadioButton
                {
                    Content = image1,
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10, 0, 0, 0)
                };

                RadioButton radioButtonB = new RadioButton
                {
                    Content = image2,
                    GroupName = "AnswerGroup",
                    FontSize = 16,
                    Margin = new Thickness(10, 10, 0, 0)
                };

                Button submitButton = new Button
                {
                    Content = "Submit",
                    Width = 100,
                    FontSize = 16,
                    Margin = new Thickness(0, 10, 0, 10)
                };

                TextBlock resultTextBlock = new TextBlock
                {
                    FontSize = 16,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Padding = new Thickness(10)
                };
                submitButton.Click += (sender, e) =>
                {
                    if (radioButtonB.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C2A1");
                        resultTextBlock.Foreground = Brushes.Green;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);

                        CompleteChapter(2);
                    }
                    else if (radioButtonA.IsChecked == true)
                    {
                        resultTextBlock.Text = ResourceManager.GetString("C2A2");
                        resultTextBlock.Foreground = Brushes.Red;
                        questionPanel.Children.Remove(resultTextBlock);
                        questionPanel.Children.Add(resultTextBlock);
                    }

                    SetButtonState(button, GetChapterStatus(2));
                };

                radioButtonA.Click += (sender, e) => radioButtonB.IsChecked = false;
                radioButtonB.Click += (sender, e) => radioButtonA.IsChecked = false;

                questionPanel.Children.Add(textBlock);
                questionPanel.Children.Add(radioButtonA);
                questionPanel.Children.Add(radioButtonB);
                questionPanel.Children.Add(submitButton);

                border.Child = questionPanel;

                panel.Children.Add(border);
            }
        }

        public static void DisplayChapter4(StackPanel panel, Button button)
        {
            var entries = AssignVar("C4P", 0, 5);
            var questions = AssignVar("C4Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

                if (entry.Key.ToString().EndsWith("P3"))
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
        }
        public static void DisplayChapter5(StackPanel panel, Button button)
        {
            var entries = AssignVar("C5P", 0, 6);
            var questions = AssignVar("C5Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

                if (entry.Key.ToString().EndsWith("P5"))
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
        }

        public static void DisplayChapter6(StackPanel panel)
        {
            var entries = AssignVar("C6P", 0, 4);
            var questions = AssignVar("C6Q", 1, 0);

            foreach (var entry in entries)
            {
                TextBlock textBlock = new TextBlock
                {
                    Text = entry.Value.ToString() + "\n",
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 16,
                    Padding = entry.Key.ToString().EndsWith("P1") ? new Thickness(15, 15, 15, 0) : new Thickness(15, 0, 15, 0)
                };

                panel.Children.Add(textBlock);

                if (entry.Key.ToString().EndsWith("P3"))
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
        }*/
    }
}