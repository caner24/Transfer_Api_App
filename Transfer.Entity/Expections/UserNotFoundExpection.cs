using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Entity.Expections
{
    public class UserNotFoundExpection : NotFoundExpection
    {
        public UserNotFoundExpection(string msg) : base(msg)
        {
        }
    }
}
