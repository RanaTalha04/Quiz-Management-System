using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quiz_Management_System
{
    public partial class TeacherDashboard : Window
    {
        public TeacherDashboard()
        {
            InitializeComponent();
            MainFrame.Content = new TextBlock
                {
                    Text = "Welcome to the Teacher Dashboard!",
                    FontSize = 24,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                    
                };
            }


        private void bttn_MouseEnter(object sender, MouseEventArgs e)
                {
                    if (sender is Button button)
                    {
                        button.Background = new SolidColorBrush(Color.FromRgb(208, 230, 212));
                        button.Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 128));
                    }
                }

        private void bttn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(77, 161, 169));
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        private void max_bttn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void min_bttn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_bttn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ViewQuizzesButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewQuiz());
        }

        private void CreateQuiz_Button_Click(object sender, RoutedEventArgs e)
        {
            CreateQuizPage createQuizPage = new CreateQuizPage();
            MainFrame.Content = createQuizPage;  

        }

        private void LogOut_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }
    }
}
