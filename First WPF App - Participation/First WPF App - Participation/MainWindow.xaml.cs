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
using System.Timers;
using System.Threading;

namespace First_WPF_App___Participation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_finished_MouseEnter(object sender, RoutedEventArgs e)
        {
            Random number = new Random();
            var bc = new SolidColorBrush(Color.FromRgb(Convert.ToByte(number.Next(1, 255)), Convert.ToByte(number.Next(1, 255)), Convert.ToByte(number.Next(1, 255))));
                win_MainWindow.Background = bc;
        }
        private void btn_finished_MouseLeave(object sender, RoutedEventArgs e)
        {
            win_MainWindow.Background = Brushes.Red;
        }

        private void btn_finished_Click(object sender, RoutedEventArgs e)
        {
            string Name = txtbx_Name.Text;
            //DateTime DOB = Convert.ToDateTime(DP_dateofbirth.SelectedDate);
            DateTime DOB = Convert.ToDateTime(txtbx_DOB.Text);
            double howold = ((DateTime.Today - DOB).TotalDays) / 365;

            MessageBox.Show($"{Name}, you are {howold.ToString("N0")} Years Old");
        }

        
    }
}
