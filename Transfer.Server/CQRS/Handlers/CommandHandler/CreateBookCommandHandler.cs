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
using Transfer.Client.Request;
using Transfer.Client.Response;
using Transfer.Entity;
using Transfer.Entity.Expections;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapper;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly TransferClient _transferClient;

        public CreateBookCommandHandler(TransferClient transferClient, IUserService userService, IBookService bookService)
        {
            _transferClient = transferClient;
            _userService = userService;
            _bookService = bookService;

        }

        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            var user = await _userService.GetAsync(x => x.Id == request.UserId);
            if (user != null)
            {

                var bookRequest = mapper.Map<TransferServiceCreateBookRequest>(request);
                var bookResponse = await _transferClient.CreateBook(bookRequest);
                var book = mapper.Map<Books>(bookResponse);
                book.UserId = user.Id;
                await _bookService.CreateAsync(book);
                var booksResponse = mapper.Map<CreateBookResponse>(bookResponse);
                return booksResponse;
            }

            throw new UserNotFoundExpection($"id : {request.UserId} user did not found");
        }
    }
}
