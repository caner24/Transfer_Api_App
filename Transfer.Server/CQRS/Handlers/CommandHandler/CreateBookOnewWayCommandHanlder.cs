using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookOnewWayCommandHanlder : IRequestHandler<CreateBookTransferRequest, CreateBookTransferResponse>
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        public CreateBookOnewWayCommandHanlder(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;

        }
        public async Task<CreateBookTransferResponse> Handle(CreateBookTransferRequest request, CancellationToken cancellationToken)
        {

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://f311752a-e715-4445-be21-842206f699ec.mock.pstmn.io");
            string jsonData = string.Format(@"
            {{
                ""VehicleIds"": [
                    ""{0}""
                ],
                ""Adults"": {1},
                ""Children"": {2},
                ""Tags"": [
                    {{
                        ""key"": ""mock"",
                        ""value"": ""server""
                    }}
                ]
            }}", request.VehicleIds,request.Adults,request.Children);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync("/transfer/book", content);
            if (response.IsSuccessStatusCode)
            {
                var returnedJson = await response.Content.ReadFromJsonAsync<CreateBookTransferResponse>();
                _bookService.CreateAsync(new Books { Pnr = returnedJson.Pnr, UserId = request.UserId });
                return new CreateBookTransferResponse() { BookingStatusType = returnedJson.BookingStatusType, Contact = returnedJson.Contact, Pnr = returnedJson.Pnr, Transfers = returnedJson.Transfers };
            }
            else
            {
                return new CreateBookTransferResponse() { BookingStatusType = "Error" + response.StatusCode.ToString() };
            }


        }

    }
}
