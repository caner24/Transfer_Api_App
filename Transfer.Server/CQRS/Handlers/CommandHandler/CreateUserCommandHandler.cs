using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapper;

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
            try
            {
                var mapper = MapperConfig.ConfigureMappings();
                var user = mapper.Map<User>(request.userViewModel);
                Log.Information($"{nameof(CreateUserRequest)} isteği oluşturuluyor . . . ");
                var addedUser = await _userService.CreateAsync(user);
                return new CreateUserResponse() { IsCreated = "Created", UserId = addedUser.Id };
            }
            catch (Exception ex)
            {
                Log.Error($" {nameof(CreateUserRequest)} isteği oluşturulurken bir hata meydana geldi :{ex.Message} . . .");
                return new CreateUserResponse() { IsCreated = "Non-Created" };
            }
            finally
            {
                Log.Information($"{nameof(CreateUserResponse)}  isteği sonlandırldı . . .");
            }
        }
    }
}
