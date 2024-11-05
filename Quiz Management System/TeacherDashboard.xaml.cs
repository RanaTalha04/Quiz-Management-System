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
    /// <summary>
    /// Interaction logic for TeacherDashboard.xaml
    /// </summary>
    public partial class TeacherDashboard : Window
    {
        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void menu_bttn_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the visibility of the left menu panel
            if (leftMenuPanel.Visibility == Visibility.Collapsed)
            {
                leftMenuPanel.Visibility = Visibility.Visible; // Show menu
            }
            else
            {
                leftMenuPanel.Visibility = Visibility.Collapsed; // Hide menu
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

       
    }
}
