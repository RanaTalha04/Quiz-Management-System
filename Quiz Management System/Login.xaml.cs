using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
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

        private void Sign_up_bttn_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(215, 232, 186));
                button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void Sign_up_bttn_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = new SolidColorBrush(Color.FromRgb(77, 161, 169));
                button.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }
        }
        private void Sign_up_bttn_Click(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Close();
        }

        private void Close_bttn_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
            if (string.IsNullOrEmpty(user_id_tb.Text) || string.IsNullOrEmpty(pass_tb.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (user_id_tb.Text.StartsWith("S"))
            {
                try
                {
                    string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();


                        string query = "SELECT S_Id, S_Name FROM Student WHERE S_Id = @id AND S_Password = @password";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass_tb.Text;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();

                                    string studentId = reader["S_Id"].ToString();
                                    string studentName = reader["S_Name"].ToString();

                                    MessageBox.Show($"Welcome, {studentName}!", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                                    StudentDashboard s_dashboard = new StudentDashboard();
                                    s_dashboard.Show();

                                    user_id_tb.Clear();
                                    pass_tb.Clear();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid ID or Password", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
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
                    string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QMS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        con.Open();


                        string query = "SELECT T_Id, T_Name FROM Teacher WHERE T_Id = @id AND T_Password = @password";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = user_id_tb.Text;
                            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = pass_tb.Text;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    reader.Read();

                                    string teacherId = reader["T_Id"].ToString();
                                    string teacherName = reader["T_Name"].ToString();

                                    MessageBox.Show($"Welcome, {teacherName}!","Welcome", MessageBoxButton.OK,MessageBoxImage.Information);

                                    TeacherDashboard T_dashboard = new TeacherDashboard();
                                    T_dashboard.Show();

                                    user_id_tb.Clear();
                                    pass_tb.Clear();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please enter a valid ID or Password ", "ID Error", MessageBoxButton.OK, MessageBoxImage.Error);

                                }
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

        private void forgotPass_bttn_Click(object sender, RoutedEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }
    }
}