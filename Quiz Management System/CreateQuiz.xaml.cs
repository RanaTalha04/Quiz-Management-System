using Microsoft.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Quiz_Management_System
{
    public static class DatabaseHelper
    {
        public static void SaveQuiz(string title, string description, int numberOfQuestions, string startTime, string endTime, List<QuestionData> questions)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuizQuery = "INSERT INTO Quizzes (Title, Description, NumberOfQuestions, StartTime, EndTime) " +
                                         "VALUES (@Title, @Description, @NumberOfQuestions, @StartTime, @EndTime); " +
                                         "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(insertQuizQuery, connection);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@NumberOfQuestions", numberOfQuestions);
                cmd.Parameters.AddWithValue("@StartTime", DateTime.ParseExact(startTime, "hh:mm tt", null));
                cmd.Parameters.AddWithValue("@EndTime", DateTime.ParseExact(endTime, "hh:mm tt", null));

                int quizId = Convert.ToInt32(cmd.ExecuteScalar());


                foreach (var question in questions)
                {
                    string insertQuestionQuery = "INSERT INTO Questions (QuizID, QuestionText, CorrectAnswer) " +
                                                 "VALUES (@QuizID, @QuestionText, @CorrectAnswer); SELECT SCOPE_IDENTITY();";
                    cmd = new SqlCommand(insertQuestionQuery, connection);
                    cmd.Parameters.AddWithValue("@QuizID", quizId);
                    cmd.Parameters.AddWithValue("@QuestionText", question.QuestionText);
                    cmd.Parameters.AddWithValue("@CorrectAnswer", question.CorrectAnswer);

                    int questionId = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (var option in question.Options)
                    {
                        string insertOptionQuery = "INSERT INTO Options (QuestionID, OptionText) " +
                                                   "VALUES (@QuestionID, @OptionText);";
                        cmd = new SqlCommand(insertOptionQuery, connection);
                        cmd.Parameters.AddWithValue("@QuestionID", questionId);
                        cmd.Parameters.AddWithValue("@OptionText", option);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    public class QuestionData
    {
        public string? QuestionText { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<string>? Options { get; set; }
    }

public partial class CreateQuizPage : Page
    {
        public CreateQuizPage()
        {
            InitializeComponent();
        }
      

        private void AddQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanel questionPanel = new StackPanel();
            questionPanel.Margin = new Thickness(0, 10, 0, 10);

            TextBlock questionLabel = new TextBlock
            {
                Text = "Question",
                FontWeight = FontWeights.Bold
            };
            questionPanel.Children.Add(questionLabel);

            TextBox questionTextBox = new TextBox
            {
                Width = 400,
                Height = 30,
                Background = new SolidColorBrush(Colors.White),
                BorderBrush = new SolidColorBrush(Colors.Gray),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(5)
            };
            questionPanel.Children.Add(questionTextBox);

            TextBlock optionsLabel = new TextBlock
            {
                Text = "Options",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 5)
            };
            questionPanel.Children.Add(optionsLabel);

            for (int i = 0; i < 4; i++)
            {
                TextBox optionTextBox = new TextBox
                {
                    Width = 300,
                    Height = 30,
                    Background = new SolidColorBrush(Colors.White),
                    BorderBrush = new SolidColorBrush(Colors.Gray),
                    BorderThickness = new Thickness(1),
                    Padding = new Thickness(5),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                questionPanel.Children.Add(optionTextBox);
            }

            TextBlock correctAnswerLabel = new TextBlock
            {
                Text = "Correct Answer (e.g., A)",
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 5)
            };
            questionPanel.Children.Add(correctAnswerLabel);

            TextBox correctAnswerTextBox = new TextBox
            {
                Width = 300,
                Height = 30,
                Background = new SolidColorBrush(Colors.White),
                BorderBrush = new SolidColorBrush(Colors.Gray),
                BorderThickness = new Thickness(1),
                Padding = new Thickness(5)
            };
            questionPanel.Children.Add(correctAnswerTextBox);

            QuestionsPanel.Children.Add(questionPanel);
        }

        private void SaveQuizButton_Click(object sender, RoutedEventArgs e)
        {
            string quizTitle = QuizTitleTextBox.Text;
            string quizDescription = QuizDescriptionTextBox.Text;
            string numberOfQuestions = NumberOfQuestionsTextBox.Text;
            string startTime = StartTimeTextBox.Text;
            string endTime = EndTimeTextBox.Text;

            if (string.IsNullOrEmpty(quizTitle) || string.IsNullOrEmpty(quizDescription) || string.IsNullOrEmpty(numberOfQuestions) || string.IsNullOrEmpty(startTime) || string.IsNullOrEmpty(endTime))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!IsValidTimeFormat(startTime) || !IsValidTimeFormat(endTime))
            {
                MessageBox.Show("Please enter a valid time format (HH:mm AM/PM).", "Time Format Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<QuestionData> questions = new List<QuestionData>();

            foreach (UIElement element in QuestionsPanel.Children)
            {
                if (element is StackPanel questionPanel)
                {
                    // Get the question text
                    string questionText = ((TextBox)questionPanel.Children[1]).Text;

                    // Collect options from the dynamically added textboxes
                    List<string> options = new List<string>();
                    for (int i = 3; i < questionPanel.Children.Count - 1; i++) // Iterate through option TextBoxes
                    {
                        if (questionPanel.Children[i] is TextBox optionTextBox)
                        {
                            options.Add(optionTextBox.Text);
                        }
                    }

                    // Get the correct answer
                    string correctAnswer = ((TextBox)questionPanel.Children[questionPanel.Children.Count - 1]).Text;

                    questions.Add(new QuestionData
                    {
                        QuestionText = questionText,
                        CorrectAnswer = correctAnswer,
                        Options = options
                    });
                }
            }

            try
            {
                DatabaseHelper.SaveQuiz(quizTitle, quizDescription, int.Parse(numberOfQuestions), startTime, endTime, questions);
                MessageBox.Show("Quiz saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private bool IsValidTimeFormat(string time)
        {
            return DateTime.TryParseExact(time, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None, out _);
        }

        private void ClearForm()
        {
            QuizTitleTextBox.Clear();
            QuizDescriptionTextBox.Clear();
            NumberOfQuestionsTextBox.Clear();
            StartTimeTextBox.Clear();
            EndTimeTextBox.Clear();

            QuestionsPanel.Children.Clear();
        }
    }
}
