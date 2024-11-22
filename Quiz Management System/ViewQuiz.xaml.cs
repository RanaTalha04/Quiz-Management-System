using Microsoft.Data.SqlClient;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Management_System
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }
       
    public partial class ViewQuiz : Page
    {
        public ViewQuiz()
        {

            InitializeComponent();
            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            try
            {
                List<Quiz> quizzes = new List<Quiz>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT QuizID, Title, Description, 'Active' AS Status FROM Quizzes";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        quizzes.Add(new Quiz
                        {
                            QuizID = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Status = reader.GetString(3)
                        });
                    }
                }

                QuizDataGrid.ItemsSource = quizzes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading quizzes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            var button = sender as Button;
            var selectedQuiz = button?.DataContext as Quiz;

            if (selectedQuiz != null)
            {
                string newTitle = PromptInputDialog($"Edit Title for '{selectedQuiz.Title}'", selectedQuiz.Title);
                string newDescription = PromptInputDialog($"Edit Description for '{selectedQuiz.Title}'", selectedQuiz.Description);

                if (!string.IsNullOrWhiteSpace(newTitle) && !string.IsNullOrWhiteSpace(newDescription))
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string query = "UPDATE Quizzes SET Title = @Title, Description = @Description WHERE QuizID = @QuizID";

                            SqlCommand cmd = new SqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@Title", newTitle);
                            cmd.Parameters.AddWithValue("@Description", newDescription);
                            cmd.Parameters.AddWithValue("@QuizID", selectedQuiz.QuizID);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Quiz updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadQuizzes(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating quiz: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Title or Description cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

            var button = sender as Button;
            var selectedQuiz = button?.DataContext as Quiz;

            if (selectedQuiz != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the quiz '{selectedQuiz.Title}'?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            string deleteOptionsQuery = @"
                        DELETE FROM Options
                        WHERE QuestionID IN (SELECT QuestionID FROM Questions WHERE QuizID = @QuizID)";
                            using (SqlCommand deleteOptionsCmd = new SqlCommand(deleteOptionsQuery, connection))
                            {
                                deleteOptionsCmd.Parameters.AddWithValue("@QuizID", selectedQuiz.QuizID);
                                deleteOptionsCmd.ExecuteNonQuery();
                            }
                            string deleteQuestionsQuery = "DELETE FROM Questions WHERE QuizID = @QuizID";
                            using (SqlCommand deleteQuestionsCmd = new SqlCommand(deleteQuestionsQuery, connection))
                            {
                                deleteQuestionsCmd.Parameters.AddWithValue("@QuizID", selectedQuiz.QuizID);
                                deleteQuestionsCmd.ExecuteNonQuery();
                            }

                            string deleteQuizQuery = "DELETE FROM Quizzes WHERE QuizID = @QuizID";
                            using (SqlCommand deleteQuizCmd = new SqlCommand(deleteQuizQuery, connection))
                            {
                                deleteQuizCmd.Parameters.AddWithValue("@QuizID", selectedQuiz.QuizID);
                                deleteQuizCmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Quiz deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadQuizzes(); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting quiz: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private string PromptInputDialog(string message, string defaultValue)
        {
            Window inputDialog = new Window
            {
                Width = 400,
                Height = 200,
                Title = "Input Required",
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ResizeMode = ResizeMode.NoResize
            };

            StackPanel stackPanel = new StackPanel { Margin = new Thickness(20) };

            TextBlock messageText = new TextBlock
            {
                Text = message,
                Margin = new Thickness(0, 0, 0, 10),
                FontWeight = FontWeights.Bold
            };

            TextBox inputBox = new TextBox
            {
                Text = defaultValue,
                Margin = new Thickness(0, 0, 0, 10),
                Width = 350
            };

            Button confirmButton = new Button
            {
                Content = "OK",
                Width = 80,
                Margin = new Thickness(5),
                IsDefault = true
            };
            confirmButton.Click += (s, e) => inputDialog.DialogResult = true;

            Button cancelButton = new Button
            {
                Content = "Cancel",
                Width = 80,
                Margin = new Thickness(5),
                IsCancel = true
            };

            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            buttonPanel.Children.Add(confirmButton);
            buttonPanel.Children.Add(cancelButton);

            stackPanel.Children.Add(messageText);
            stackPanel.Children.Add(inputBox);
            stackPanel.Children.Add(buttonPanel);

            inputDialog.Content = stackPanel;

            bool? result = inputDialog.ShowDialog();
            return result == true ? inputBox.Text : null;
        }

    }
}
