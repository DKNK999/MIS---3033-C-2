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
using System.IO;

namespace CSV_Example
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

        private void btn__ValidateFileExist_Click(object sender, RoutedEventArgs e)
        {
            string filePath = txbx_FilePath.Text;

            if (File.Exists(filePath) == true)
            {
                btn_ProcessFile.IsEnabled = true;
                btn__ValidateFileExist.IsEnabled = false;
                txbx_FilePath.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Invalid File Path. Please Try Again!", "ERROR", MessageBoxButton.OK);
                txbx_FilePath.Clear();
                txbx_FilePath.Focus();
            }
        }

        private void btn_ProcessFile_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(txbx_FilePath.Text);
            double sum = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                var pieces = line.Split(",");
                double price;
                if (double.TryParse(pieces[2], out price) == true)
                {
                    sum += Convert.ToDouble(pieces[2]);
                }
                else
                {
                    MessageBox.Show($"Sorry, Problem with Data Set\nInvalid Price: {pieces[2]} on line {i+1}");
                }
                
                lbx_Lines.Items.Add(line);

            }

            MessageBox.Show($"The sum of all the product prices is {sum.ToString("C2")}");

        }
    }
}
