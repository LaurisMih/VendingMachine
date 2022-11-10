using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace.Exceptions
{
    public class MachineDontHaveSpace : Exception
    {
        public MachineDontHaveSpace() : base("Vending machine dont have free space")
        {

        }
    }
}
