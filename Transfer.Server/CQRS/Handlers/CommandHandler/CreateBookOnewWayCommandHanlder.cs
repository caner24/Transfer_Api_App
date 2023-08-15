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
using Transfer.Client;
using Transfer.Client.Response;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookOnewWayCommandHanlder : IRequestHandler<CreateBookTransferRequest, TransferServiceSearchResponse>
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly TransferClient _transferClient;

        public CreateBookOnewWayCommandHanlder(TransferClient transferClient, IUserService userService, IBookService bookService)
        {
            _transferClient = transferClient;
            _userService = userService;
            _bookService = bookService;

        }
        public async Task<TransferServiceSearchResponse> Handle(CreateBookTransferRequest request, CancellationToken cancellationToken)
        {
            
            _bookService.CreateAsync
            _transferClient.PostBook(request);
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
