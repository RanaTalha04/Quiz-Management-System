﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;

namespace Quiz_Management_System
{
    public partial class ResultPage : Page
    {
        string connectionString = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private string StudentID;
        private bool IsTeacher;

        public ResultPage(string studentId, bool isTeacher = false)
        {
            InitializeComponent();
            StudentID = studentId;
            IsTeacher = isTeacher;
            LoadResults();
        }

        private void LoadResults()
        {
            List<StudentResult> results = new List<StudentResult>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query;

                    if (IsTeacher)
                    {
                        query = @"
                            SELECT r.StudentID, q.Title, r.MarksObtained, r.TotalMarks, r.AttemptDate
                            FROM Results r
                            INNER JOIN Quizzes q ON r.QuizID = q.QuizID";
                    }
                    else
                    {
                        query = @"
                            SELECT r.StudentID, q.Title, r.MarksObtained, r.TotalMarks, r.AttemptDate
                            FROM Results r
                            INNER JOIN Quizzes q ON r.QuizID = q.QuizID
                            WHERE r.StudentID = @StudentID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (!IsTeacher)
                        {
                            cmd.Parameters.AddWithValue("@StudentID", StudentID);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new StudentResult
                                {
                                    StudentID = reader.GetString(0),
                                    Title = reader.GetString(1),
                                    MarksObtained = reader.GetInt32(2),
                                    TotalMarks = reader.GetInt32(3),
                                    AttemptDate = reader.GetDateTime(4)
                                });
                            }
                        }
                    }
                }

                ResultsDataGrid.ItemsSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading results: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class StudentResult
    {
        public string StudentID { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int MarksObtained { get; set; }
        public int TotalMarks { get; set; }
        public DateTime AttemptDate { get; set; }
    }
}
