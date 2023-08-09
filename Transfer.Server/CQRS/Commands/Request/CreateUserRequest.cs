using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Models;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateUserRequest:IRequest<CreateUserResponse>
    {
        public UserViewModel userViewModel { get; set; }
    }
}
