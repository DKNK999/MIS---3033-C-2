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

namespace _P__WPF___Classes_2
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

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            double testDouble;
            string testString;
            if (double.TryParse(txtbx_Price.Text, out testDouble) == true && txtbx_Manufacturer.Text != string.Empty && txtbx_Name.Text != string.Empty)
            {
                Toy userToy = new Toy();
                userToy.Manufacturer = txtbx_Manufacturer.Text;
                userToy.Name = txtbx_Name.Text;
                userToy.Price = Convert.ToDouble(txtbx_Price.Text);
                userToy.GetAisle();
                listbx_ToyInfo.Items.Add(userToy);
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void listbx_ToyInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Toy selectedToy = (Toy)listbx_ToyInfo.SelectedItem;
            MessageBox.Show($"Manufacturer: {selectedToy.Manufacturer}\nName: {selectedToy.Name}\nPrice: {selectedToy.Price.ToString()}\nAisle: {selectedToy.GetAisle()}");
        }
    }
}
