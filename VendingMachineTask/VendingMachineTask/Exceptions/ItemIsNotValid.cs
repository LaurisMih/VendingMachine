using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineNameSpace.Exceptions
{
    public class ItemIsNotValid : Exception
    {
        public ItemIsNotValid() : base("Item is not valid")
        {

        }
    }
}
