using AutoMapper;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IBookService bookService, IMapper mapper)
        {
            _mapper = mapper;
            _bookService = bookService;

        }
        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information($"{nameof(CreateBookRequest)} isteği oluşturuluyor . . . ");
                var bookTransfer = await _bookService.CreateAsync(new Books() { UserId = request.UserId, VehicleId = request.VehicleId, BookingStatusType = "TickedSuccess" });
                return new CreateBookResponse() { BookingStatusType = "TickedSuccess", Pnr = bookTransfer.Pnr };
            }
            catch (Exception ex)
            {
                Log.Error($" {nameof(CreateBookRequest)} isteği oluşturulurken bir hata meydana geldi :{ex.Message} . . .");
                return new CreateBookResponse() { BookingStatusType = "Ticked{un}succeded" };
            }
            finally
            {
                Log.Information($"{nameof(CreateBookResponse)}  isteği sonlandırldı . . .");
            }

        }

    }
}
