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
using System.Windows.Shapes;

namespace Quiz_Management_System
{
    public partial class AttemptQuiz : Window
    {
        private int QuizID;
        private string StudentID;
        public class Option
        {
            public int OptionID { get; set; }
            public string OptionText { get; set; } = string.Empty;
            public bool IsSelected { get; set; }
        }

        public class Question
        {
            public int QuestionID { get; set; }
            public string QuestionText { get; set; } = string.Empty;
            public string CorrectAnswer { get; set; } = string.Empty; 
            public List<Option> Options { get; set; } = new List<Option>();
        }

        public AttemptQuiz(int quizID, string studentID)
        {
            InitializeComponent();
            QuizID = quizID;
            LoadQuestions();
            StudentID = studentID;
        }

        private void LoadQuestions()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True";

            try
            {
                List<Question> questions = new List<Question>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    q.QuestionID, q.QuestionText, q.CorrectAnswer, 
                    o.OptionID, o.OptionText
                FROM Questions q
                LEFT JOIN Options o ON q.QuestionID = o.QuestionID
                WHERE q.QuizID = @QuizID
                ORDER BY q.QuestionID, o.OptionID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@QuizID", QuizID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int questionID = reader.GetInt32(0);

                                var question = questions.FirstOrDefault(q => q.QuestionID == questionID);
                                if (question == null)
                                {
                                    question = new Question
                                    {
                                        QuestionID = questionID,
                                        QuestionText = reader.GetString(1),
                                        CorrectAnswer = reader.GetString(2)
                                    };
                                    questions.Add(question);
                                }

                                if (!reader.IsDBNull(3)) 
                                {
                                    question.Options.Add(new Option
                                    {
                                        OptionID = reader.GetInt32(3),
                                        OptionText = reader.GetString(4)
                                    });
                                }
                            }
                        }
                    }
                }

                QuestionsListView.ItemsSource = questions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading questions: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int totalMarks = 0;
            int obtainedMarks = 0;

            foreach (var question in (List<Question>)QuestionsListView.ItemsSource)
            {
                totalMarks++; 

                var selectedOption = question.Options.FirstOrDefault(o => o.IsSelected);
                if (selectedOption != null && selectedOption.OptionText == question.CorrectAnswer)
                {
                    obtainedMarks++; 
                }
            }

            SaveResultToDatabase(QuizID, obtainedMarks, totalMarks);

            MessageBox.Show($"Quiz Submitted! You scored {obtainedMarks}/{totalMarks}.", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void SaveResultToDatabase(int quizId, int marksObtained, int totalMarks)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertResultQuery = @"
                    INSERT INTO Results (QuizID, StudentID, MarksObtained, TotalMarks)
                    VALUES (@QuizID, @StudentID, @MarksObtained, @TotalMarks);";
                    SqlCommand cmd = new SqlCommand(insertResultQuery, connection);
                    cmd.Parameters.AddWithValue("@QuizID", quizId);
                    cmd.Parameters.AddWithValue("@StudentID", StudentID); 
                    cmd.Parameters.AddWithValue("@MarksObtained", marksObtained);
                    cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving result: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

