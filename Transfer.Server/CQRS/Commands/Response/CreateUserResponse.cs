using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transfer.Server.CQRS.Commands.Response
{
    public class CreateUserResponse
    {
        public int UserId { get; set; }
        public string IsCreated { get; set; }
    }
}
