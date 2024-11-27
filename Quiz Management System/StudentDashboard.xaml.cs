using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using System.Windows;
using System.Windows.Media;
using ClosedXML.Excel;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Quiz_Management_System
{
    public partial class StudentDashboard : Window
    {
        private string StudentID;
        public StudentDashboard(string studentID)
        {
            InitializeComponent();
            MainFrame.Content = new TextBlock
            {
                Text = "Welcome to the Student Dashboard!",
                FontSize = 24,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            StudentID = studentID;
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

    
        private void ViewResultButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainFrame.Navigate(new ResultPage(StudentID));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening result page: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ViewQuizButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewQuizStudent(StudentID));
        }


        private void DownloadQuizButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    string connectionString = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

                    string query = "SELECT QuizID, StudentID, MarksObtained, TotalMarks, AttemptDate FROM Results";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            using (XLWorkbook workbook = new XLWorkbook())
                            {
                                workbook.Worksheets.Add(dataTable, "Results");
                                workbook.SaveAs(filePath);
                            }
                        }
                    }

                    MessageBox.Show("Results Exported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while exporting results: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
