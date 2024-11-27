using Azure;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
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
using System.Configuration;


namespace Quiz_Management_System
{
    /// <summary>
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Window
    {
        string connectionString = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public Signup()
        {
            InitializeComponent();
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void login_bttn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(77, 161, 169));
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }

        private void login_bttn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(215, 232, 186));
                button.Foreground = new SolidColorBrush(Color.FromRgb(77, 161, 169));
            }
        }
        private void login_bttn_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void sign_up_bttn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(208, 230, 212));
                button.Foreground = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            }
        }

        private void sign_up_bttn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(77, 161, 169));
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        private void sign_up_bttn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(user_id_tb.Text) || string.IsNullOrEmpty(pass_tb.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (pass_tb.Text != confirm_pass_tb.Text)
                {
                    MessageBox.Show("Password does not match.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (user_id_tb.Text.StartsWith("S"))
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();


                            string query = "INSERT INTO Student (S_Id, S_Name, S_Password) VALUES (@id, @name, @password)";


                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = username_tb.Text;
                                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass_tb.Text;



                                int num = cmd.ExecuteNonQuery();


                                if (num > 0)
                                {
                                    MessageBox.Show("Student registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Login login = new Login();
                                    login.Show();
                                    user_id_tb.Clear();
                                    username_tb.Clear();
                                    pass_tb.Clear();
                                    confirm_pass_tb.Clear();
                                    this.Close();
                                }

                                else
                                {
                                    MessageBox.Show("Account already exist", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Account already exist", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                else if (user_id_tb.Text.StartsWith("T"))
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            con.Open();


                            string query = "INSERT INTO Teacher (T_Id, T_Name, T_Password) VALUES (@id, @name, @password)";


                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = username_tb.Text;
                                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass_tb.Text;



                                int num = cmd.ExecuteNonQuery();


                                if (num > 0)
                                {
                                    MessageBox.Show("Teacher registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Login login = new Login();
                                    login.Show();
                                    user_id_tb.Clear();
                                    username_tb.Clear();
                                    pass_tb.Clear();
                                    confirm_pass_tb.Clear();
                                    this.Close();
                                }

                                else
                                {
                                    MessageBox.Show("Account already exist", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Account already exist", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid ID format (T, S).", "ID Format Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error Occured", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Close_bttn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
