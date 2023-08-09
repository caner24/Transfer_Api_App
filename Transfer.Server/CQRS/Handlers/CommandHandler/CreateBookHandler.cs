using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        public Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
