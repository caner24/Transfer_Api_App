using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetBookQueryHandler : IRequestHandler<GetBookRequest, GetBookResponse>
    {
        private readonly IUserService _userService;
        public GetBookQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            using (HttpClient client = new HttpClient())
            {
                var user = await _userService.GetAsync(x => x.Id == request.UserId);
                var response = await client.GetFromJsonAsync<GetBookResponse>($"https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io/transfers/reservations/{request.Pnr}?LastName={user.LastName}");
                response.Contact = new
                {
                    email = "admin@roofstacks.com",
                    firstName = user.FirstName,
                    genderType = user.GenderType,
                    lastName = user.LastName,
                    phone = user.PhoneNumber
                };
                return response;
            }
        }
    }
}
