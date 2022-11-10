using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace.Exceptions
{
    public class IncorrectCoinValue : Exception
    {
        public IncorrectCoinValue() : base("Machine dont accept this coin value")
        {

        } 
    }
}
