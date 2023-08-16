using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Transfer.Client;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapper;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateValidationCommandHandler : IRequestHandler<CreateValidateRequest, CreateValidateResponse>
    {
        private readonly TransferClient _transferClient;
        public CreateValidationCommandHandler(TransferClient transferClient)
        {
                _transferClient = transferClient;
        }
        public Task<CreateValidateResponse> Handle(CreateValidateRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            throw new NotImplementedException();


        }
    }
}
