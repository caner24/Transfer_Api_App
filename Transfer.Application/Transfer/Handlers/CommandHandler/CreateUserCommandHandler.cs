
using MediatR;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;
using Transfer.Business.Abstract;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequestDto, CreateUserResponse>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequestDto request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            var user = mapper.Map<User>(request);
            var addedUser = await _userService.CreateAsync(user);
            return new CreateUserResponse() { IsCreated = "Created", UserId = addedUser.Id };
        }
    }
}
