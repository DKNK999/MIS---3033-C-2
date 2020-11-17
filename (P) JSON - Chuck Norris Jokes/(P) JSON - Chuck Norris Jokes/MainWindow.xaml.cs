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
using Newtonsoft.Json;
using System.Net.Http;

namespace _P__JSON___Chuck_Norris_Jokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] categories;
            using (var client = new HttpClient())
            { 
                string results = client.GetStringAsync(@"https://api.chucknorris.io/jokes/categories").Result;
                categories = JsonConvert.DeserializeObject<string[]>(results);


                cmbobx_Categories.Items.Add("All");
                foreach (var item in categories)
                {
                    cmbobx_Categories.Items.Add(item);
                }
            }
                

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            JokeCall joke = new JokeCall();
            using (var client = new HttpClient())
            {
                
                if (cmbobx_Categories.SelectedItem.ToString() == "All")
                {
                    
                    string result = client.GetStringAsync(@$"https://api.chucknorris.io/jokes/random").Result;
                    joke = JsonConvert.DeserializeObject<JokeCall>(result);
                }
                else
                {
                    string result = client.GetStringAsync(@$"https://api.chucknorris.io/jokes/random?category={cmbobx_Categories.SelectedItem.ToString()}").Result;
                    joke = JsonConvert.DeserializeObject<JokeCall>(result);

                }
                
            }
            txtbx_Qoute.Visibility = Visibility.Visible;
            txtbx_Qoute.IsReadOnly = true;
            txtbx_Qoute.Text = joke.value;
        }
    }
}
