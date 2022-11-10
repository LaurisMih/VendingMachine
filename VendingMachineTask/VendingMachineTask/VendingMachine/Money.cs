using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }

        public Money(int euros, int cents)
        {
            Euros = euros;
            Cents = cents;
        }

        public override string ToString()
        {
            string centDisplay = Cents.ToString("00");
            return $"{Euros}.{centDisplay}";
        }
    }
}