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

namespace _P__Classes_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtbx_firstname.Text = "Nicholas";
            txtbx_lastname.Text = "Keller";
            txtbx_major.Text = "MIS";
            txtbx_GPA.Text = "4.0";
            txtbx_streetnumber.Text = "1100110011";
            txtbx_streetname.Text = "New York Ave Dr Ave";
            txtbx_state.Text = "New York";
            txtbx_city.Text = "New York City";
            txtbx_zipcode.Text = "73071";
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            student.SetAddress(Convert.ToInt32(txtbx_streetnumber.Text), txtbx_streetname.Text, txtbx_state.Text, txtbx_city.Text, Convert.ToInt32(txtbx_zipcode.Text));
            student.FirstName = txtbx_firstname.Text;
            student.LastName = txtbx_lastname.Text;
            student.Major = txtbx_major.Text;
            student.GPA = Convert.ToDouble(txtbx_GPA.Text);
            lstbx_Students.Items.Add(student);
            
        }

        private void lstbx_Students_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student selectedstudent = (Student)lstbx_Students.SelectedItem;
            StudentInfo studentInfo = new StudentInfo();

            studentInfo.setup(selectedstudent);
            studentInfo.Show();
        }
    }
}
