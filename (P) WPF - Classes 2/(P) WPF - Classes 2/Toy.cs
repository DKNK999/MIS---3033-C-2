using System;
using System.Collections.Generic;
using System.Text;

namespace _P__WPF___Classes_2
{
    class Toy
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        private string Aisle { get; }

        public Toy()
        {
            Manufacturer = string.Empty;
            Name = string.Empty;
            Price = -1;
            Aisle = string.Empty;
        }

        public Toy( string Manufacturer, string Name, double Price)
        {
            this.Manufacturer = Manufacturer;
            this.Name = Name;
            this.Price = Price;
        }

        public string GetAisle()
        {
            string Aisle = $"{Manufacturer[0].ToString().ToUpper()}{Price.ToString()}";
            return Aisle;
        }

        public override string ToString()
        {
            string Formatted = $"{{{Manufacturer}}}-{{{Name}}}";
            return Formatted;
        }


    }
}
