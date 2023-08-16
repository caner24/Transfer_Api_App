using AutoMapper;
using MediatR;
using Transfer.Business.Abstract;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            //try
            //{
            var _mapper = MapperConfig.ConfigureMappings();
            var user = _mapper.Map<User>(request);
            var addedUser = await _userService.CreateAsync(user);
            return new CreateUserResponse() { IsCreated = "Created", UserId = addedUser.Id };
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($" {nameof(CreateUserRequest)} isteği oluşturulurken bir hata meydana geldi :{ex.Message} . . .");
            //    return new CreateUserResponse() { IsCreated = "Non-Created" };
            //}
            //finally
            //{
            //    Log.Information($"{nameof(CreateUserResponse)}  isteği sonlandırldı . . .");
            //}
        }
    }
}
