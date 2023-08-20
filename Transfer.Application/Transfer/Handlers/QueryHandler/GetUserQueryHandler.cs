using MediatR;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Campaign.Queries.Response.DataTransferObjects;
using Transfer.Business.Abstract;
using Transfer.Server.CQRS.Queries.Request;


namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetUserQueryHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IUserService _userService;
        public GetUserQueryHandler(IUserService userService)
        {
            _userService = userService;

        }
        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var returnUser = await _userService.GetAllAsync();
            return new GetUserResponse() {User= returnUser };
        }
    }
}

