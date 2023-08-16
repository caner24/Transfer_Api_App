using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateValidationCommandHandler : IRequestHandler<CreateValidateRequest, CreateValidateResponse>
    {
        public Task<CreateValidateResponse> Handle(CreateValidateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
