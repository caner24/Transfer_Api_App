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

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;

        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information($"{nameof(CreateUserRequest)} isteği oluşturuluyor . . . ");
                var user = _mapper.Map<User>(request);
                var addedUser = await _userService.CreateAsync(user);
                return new CreateUserResponse() { IsCreated = "Created", UserId = addedUser.Id };
            }
            catch (Exception ex)
            {
                Log.Error($" {nameof(CreateBookRequest)} isteği oluşturulurken bir hata meydana geldi :{ex.Message} . . .");
                return new CreateUserResponse() { IsCreated = "Non-Created" };
            }
            finally
            {
                Log.Information($"{nameof(CreateUserResponse)}  isteği sonlandırldı . . .");
            }
        }
    }
}
