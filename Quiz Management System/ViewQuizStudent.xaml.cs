using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace Quiz_Management_System
{
    public class Quizes
    {
        public int QuizID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
    }

    public partial class ViewQuizStudent : Page
    {


        string connectionString = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private string StudentID;
        public ViewQuizStudent(string studentID)
        {
            InitializeComponent();
            LoadQuizzes();
            StudentID = studentID;
        }

        private void LoadQuizzes()
        {
            try
            {
                List<Quizes> quizzes = new List<Quizes>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT QuizID, Title, Description, 'Active' AS Status FROM Quizzes";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        quizzes.Add(new Quizes
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

        private void AttemptButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                MessageBox.Show("The sender is not a Button.");
                return;
            }

            var context = button.DataContext;

            if (context == null)
            {
                MessageBox.Show("The Button's DataContext is null.");
                return;
            }

            var selectedQuiz = context as Quizes;

            if (selectedQuiz == null)
            {
                MessageBox.Show("The Button's DataContext is not a Quiz object.");
            }
            else
            {
                AttemptQuiz attempt = new AttemptQuiz(selectedQuiz.QuizID, StudentID);
                attempt.Show();
            }
        }

    }
}
