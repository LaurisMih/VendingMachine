using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTests.Exceptions
{
    public class MachineDontHaveProducts : Exception
    {
        public MachineDontHaveProducts() : base("Vending machine dont have products")
        {

        }
    }
}
