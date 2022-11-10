using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace
{
    public struct Product
    {

        public int Available { get; set; }

        public Money Price { get; set; }

        public string Name { get; set; }

        public Product(string name, Money price, int quantity)
        {
            Name = name;
            Price = price;
            Available = quantity;
        }

        public Product(string name, Money? price, int quantity)
        {
            Name = name;
            Price = (Money)price;
            Available = quantity;
        }

        public override string ToString()
        {
            return $"{Name}, Price: {Price}€. Amount: {Available}";

        }
    }
}