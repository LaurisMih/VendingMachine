using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTests.Exceptions
{
    public class MachineDontHaveSpace : Exception
    {
        public MachineDontHaveSpace() : base("Vending machine dont have free space")
        {

        }
    }
}
