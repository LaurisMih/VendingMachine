using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace.Exceptions
{
    public class InvalidProductNumber : Exception
    {
        public InvalidProductNumber() : base ("Invalid product number")
        {

        }
    }
}
