using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetUserQueryHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;

        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var returnUser = await _userService.GetAllAsync();
            return new GetUserResponse() {User=returnUser };
        }
    }
}

