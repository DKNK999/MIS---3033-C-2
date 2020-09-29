using System;
using System.Collections.Generic;
using System.Text;

namespace WPF1
{
    class EntryForm
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        public EntryForm()
        {
            Name = string.Empty;
            Address = string.Empty;
            ZipCode = -1;
        }

        public EntryForm(string Name, string Address, int ZipCode)
        {
            this.Name = Name;
            this.Address = Address;
            this.ZipCode = ZipCode;
        }

        public override string ToString()
        {
            return ($"{Name}, {Address}, {ZipCode}");
        }



    }
}
