 using MediatR;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Commands.Request
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string GenderType { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}
