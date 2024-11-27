using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        string connectionString = "Data Source=TALHA\\SQLEXPRESS;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public ForgotPassword()
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

        private void Close_bttn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_bttn_MouseEnter(object sender, MouseEventArgs e)
        {

            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(77, 161, 169));
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }             

        private void save_bttn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(215, 232, 186));
                button.Foreground = new SolidColorBrush(Color.FromRgb(77, 161, 169));
            }
        }

        private void save_bttn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(user_id_tb.Text) || string.IsNullOrEmpty(new_pass_tb.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (new_pass_tb.Text != confirm_pass_tb.Text)
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


                        string query = "UPDATE Student SET S_Password = @password WHERE S_Id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = new_pass_tb.Text;

                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Password Updated", "Successfull", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Login login = new Login();
                                    login.Show();
                                    this.Close();

                                    user_id_tb.Clear();
                                    new_pass_tb.Clear();
                                    this.Close();
                            }
                            else
                            {
                                    MessageBox.Show("Please enter a valid ID", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("An error occured ", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
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


                        string query = "UPDATE Teacher SET T_Password = @password WHERE T_Id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = new_pass_tb.Text;

                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                    MessageBox.Show("Password Updated", "Successfull", MessageBoxButton.OK, MessageBoxImage.Information);
                                    Login login = new Login();
                                    login.Show();
                                    this.Close();

                                    user_id_tb.Clear();
                                    new_pass_tb.Clear();
                                    this.Close();
                            }
                            else
                            {
                                    MessageBox.Show("Please enter a valid ID", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error Occured. ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid ID format (T, S).", "ID Format Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
