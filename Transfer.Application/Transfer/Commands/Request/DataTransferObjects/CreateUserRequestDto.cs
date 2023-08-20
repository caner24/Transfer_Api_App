using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Application.Transfer.Commands.Request.DataTransferObjects
{
    public record class CreateUserRequestDto : IRequest<CreateUserResponse>
    {
        public string? Email { get; init; }
        public string? FirstName { get; init; }
        public string? GenderType { get; init; }
        public string? LastName { get; init; }
        public string? Phone { get; init; }
    }
}
