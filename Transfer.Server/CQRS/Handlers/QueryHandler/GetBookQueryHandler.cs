using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Client;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetBookQueryHandler : IRequestHandler<GetBookRequest, GetBookResponse>
    {
        private readonly TransferClient _transferClient;
        private readonly IUserService _userService;
        private readonly ICacheManager _cacheManager;
        public GetBookQueryHandler(ICacheManager cacheManager, TransferClient transferClient, IUserService userService)
        {
            {
                _cacheManager = cacheManager;
                _transferClient = transferClient;
                _userService = userService;
            }
        }

        public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            if (_cacheManager.IsAdd("GetBookResponse"))
            {
                return _cacheManager.Get<GetBookResponse>("GetBookResponse");
            }
            var user = await _userService.GetAsync(x => x.Id == request.UserId);
            using (var httpClient = _transferClient.GetTransferClient())
            {
                var response = await httpClient.GetFromJsonAsync<GetBookResponse>($"/transfers/reservations/{request.Pnr}?LastName={user.LastName}");

                response.Contact = new
                {
                    email = "admin@roofstacks.com",
                    firstName = user.FirstName,
                    genderType = user.GenderType,
                    lastName = user.LastName,
                    phone = user.PhoneNumber
                };
                _cacheManager.Add("GetBookResponse", response, 60);
                return _cacheManager.Get<GetBookResponse>("GetBookResponse");
            }
        }
    }
}


