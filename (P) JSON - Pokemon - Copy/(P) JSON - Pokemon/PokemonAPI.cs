using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace _P__JSON___Pokemon
{
    class PokemonAPI
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<Pokemon> results { get; set; }
    }

    public class Pokemon
    { 
        public string name { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return $"{char.ToUpper(name[0]) + name.Substring(1)}";
        }
    }

    public class PokemonInfo
    { 
        public int id { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public Sprite sprites { get; set; }

    }

    public class Sprite
    {
        public string back_default { get; set; }
        public string back_female { get; set; }
        public string back_shiny { get; set; }
        public string back_shiny_female { get; set; }
        public string front_default { get; set; }
        public string front_female { get; set; }
        public string front_shiny { get; set; }
        public string front_shiny_female { get; set; }

    }

}
