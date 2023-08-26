
using MediatR;
using Microsoft.AspNetCore.Http;
using Stripe;
using Transfer.Application.Campaign.Email.Abstract;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;
using Transfer.Application.Transfer.Infrastructure;
using Transfer.Business.Abstract;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.MailService;
using Transfer.Core.Models;
using Transfer.Entity;
using Transfer.Entity.DataTransferObjects.Stripe;
using Transfer.Entity.Expections;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapping.AutoMapper;
namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookRequestDto, CreateBookResponse>
    {
        private readonly IStripeAppService _stripeService;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly TransferClient _transferClient;

        public CreateBookCommandHandler(IStripeAppService stripeService, IEmailService emailService, TransferClient transferClient, IUserService userService, IBookService bookService)
        {
            _stripeService = stripeService;
            _emailService = emailService;
            _transferClient = transferClient;
            _userService = userService;
            _bookService = bookService;

        }

        public async Task<CreateBookResponse> Handle(CreateBookRequestDto request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();
            var user = await _userService.GetAsync(x => x.Id == request.UserId);

            if (user != null)
            {
                //var valideResponse = await _transferClient.Validate(mapper.Map<TransferServiceBookValidateRequest>(request));

                //if (valideResponse != null)
                //{
                    var bookRequest = mapper.Map<TransferServiceCreateBookRequest>(request);
                    var bookResponse = await _transferClient.CreateBook(bookRequest);
                    var book = mapper.Map<Books>(bookResponse);
                    book.UserId = user.Id;

                    await _stripeService.AddStripePaymentAsync(
                new AddStripePayment("cus_OWWmYqTwWWNksC",user.Email, "Created", "USD", (long)Convert.ToDouble(333)),
                cancellationToken);

                    await _bookService.CreateAsync(book);

                    var message = new Message(new string[] { user.Email }, "Biletiniz H.K :)", MailBody.MailBodyPnr(book.Pnr.ToString()), null);
                    await _emailService.SendEmailAsync(message);

                    var booksResponse = mapper.Map<CreateBookResponse>(bookResponse);
                    return booksResponse;
                }
                throw new ValidateExpection($"{request.VehicleId} Vehicle  did not validate !.");

            //}

            throw new UserNotFoundExpection($"id : {request.UserId} user did not found");
        }
    }
}
