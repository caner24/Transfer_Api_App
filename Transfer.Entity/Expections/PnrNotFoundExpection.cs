using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.Expections
{
    public class PnrNotFoundExpection : NotFoundExpection
    {
        public PnrNotFoundExpection(string msg) : base(msg)
        {
        }
    }
}
