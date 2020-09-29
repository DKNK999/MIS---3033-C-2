using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
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

namespace _P__JSON___Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string apiURL = @"https://pokeapi.co/api/v2/pokemon?limit=2000";

            PokemonAPI api;
            using (var client = new HttpClient())
            {
                string results = client.GetStringAsync(apiURL).Result;

                api = JsonConvert.DeserializeObject<PokemonAPI>(results);
            }

            foreach (var pokemon in api.results)
            {
                combobx_Characters.Items.Add(pokemon);
            }


        }

        private void combobx_Characters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selectedPokemon = (Pokemon)combobx_Characters.SelectedItem;
            string pokemonURL = selectedPokemon.url;

            PokemonInfo pokemonInfo;
            using (var client = new HttpClient())
            {
                string results = client.GetStringAsync(pokemonURL).Result;

                pokemonInfo = JsonConvert.DeserializeObject<PokemonInfo>(results);
            }

            txtbx_PokemonInfo.Text = $"Height: {pokemonInfo.height}\nWeight: {pokemonInfo.weight}";

            
            var spriteURL = pokemonInfo.sprites.front_default;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(spriteURL, UriKind.Absolute);
            bitmap.EndInit();
            
            img_PokemonImg.Source = bitmap;
        }

        
    }
}
