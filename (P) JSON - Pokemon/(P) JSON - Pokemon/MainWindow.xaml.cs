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
        List<BitmapImage> spriteImages = new List<BitmapImage>();
        int i = 0;

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
            i = 0;
            btn_Previous.IsEnabled = false;
            btn_Next.IsEnabled = false;
            Pokemon selectedPokemon = (Pokemon)combobx_Characters.SelectedItem;
            string pokemonURL = selectedPokemon.url;

            PokemonInfo pokemonInfo;
            using (var client = new HttpClient())
            {
                string results = client.GetStringAsync(pokemonURL).Result;

                pokemonInfo = JsonConvert.DeserializeObject<PokemonInfo>(results);
            }

            txtbx_PokemonInfo.Text = $"Height: {pokemonInfo.height}\nWeight: {pokemonInfo.weight}";

            List<string> spriteURLs = new List<string>();
            if (pokemonInfo.sprites.front_default != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.front_default);
            }
            if (pokemonInfo.sprites.back_default != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.back_default);
            }
            if (pokemonInfo.sprites.front_female != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.front_female);
            }
            if (pokemonInfo.sprites.back_female != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.back_female);
            }
            if (pokemonInfo.sprites.front_shiny != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.front_shiny);
            }
            if (pokemonInfo.sprites.back_shiny != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.back_shiny);
            }
            if (pokemonInfo.sprites.front_shiny_female != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.front_shiny_female);
            }
            if (pokemonInfo.sprites.back_shiny_female != null)
            {
                spriteURLs.Add(pokemonInfo.sprites.back_shiny_female);
            }

            spriteImages.Clear();
            foreach (var sprite in spriteURLs)
            {
                spriteImages.Add(ConvertToBitmap(sprite));
            }
            if (spriteImages.Count > 0)
            {
                img_PokemonImg.Source = spriteImages[i];
            }
            else
            {
                img_PokemonImg.Source = null;
            }
            if (spriteImages.Count > 1)
            {
                btn_Previous.IsEnabled = false;
                btn_Next.IsEnabled = true;
            }
        }

        public BitmapImage ConvertToBitmap(string spriteURL)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(spriteURL, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }

        private void btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            i = i - 1;
            img_PokemonImg.Source = spriteImages[i];
            if (i == 0)
            {
                btn_Previous.IsEnabled = false;
            }
            if (i < spriteImages.Count - 1)
            {
                btn_Next.IsEnabled = true;
            }
        }

        private void btn_Next_Click(object sender, RoutedEventArgs e)
        {
            i = i + 1;
            img_PokemonImg.Source = spriteImages[i];
            if (i == spriteImages.Count - 1)
            {
                btn_Next.IsEnabled = false;
            }
            if (i > 0)
            {
                btn_Previous.IsEnabled = true;
            }
        }
    }
}
