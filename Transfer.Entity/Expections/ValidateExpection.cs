using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.Expections
{
    public class ValidateExpection : Exception
    {
        public ValidateExpection(string msg) : base(msg)
        {

        }
    }
}
