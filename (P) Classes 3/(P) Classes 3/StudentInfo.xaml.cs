using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _P__Classes_3
{
    /// <summary>
    /// Interaction logic for StudentInfo.xaml
    /// </summary>
    public partial class StudentInfo : Window
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        public void setup(Student selectedstudent)
        {
            txtbx_StudentInfo.Text = $"{selectedstudent.FirstName} {selectedstudent.LastName}\n" +
                $"Major: {selectedstudent.Major}, GPA {selectedstudent.GPA}\n" +
                $"{selectedstudent.address.StreetNumber} {selectedstudent.address.StreetName}\n" +
                $"{selectedstudent.address.Zipcode} {selectedstudent.address.City} {selectedstudent.address.State}";
        }
    }
}
