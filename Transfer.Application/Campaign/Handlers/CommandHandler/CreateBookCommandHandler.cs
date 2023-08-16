
using MediatR;
using Transfer.Application.Campaign.Email.Abstract;
using Transfer.Business.Abstract;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.MailService;
using Transfer.Core.Models;
using Transfer.Entity;
using Transfer.Entity.Expections;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.CommandHandler
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly TransferClient _transferClient;

        public CreateBookCommandHandler(IEmailService emailService, TransferClient transferClient, IUserService userService, IBookService bookService)

        {
            _emailService = emailService;
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

                //var mockTransferClient = new Mock<bookRequest>();

                //var expectedBookResponse = new BookResponse(); 
                //mockTransferClient.Setup(client => client.CreateBook(It.IsAny<BookRequest>()))
                //                  .ReturnsAsync(expectedBookResponse);

                //// Now use the mock object in your testing code
                //var bookRequest = new BookRequest(); // Replace with your book request object

                //var bookResponse = await mockTransferClient.Object.CreateBook(bookRequest);

                var bookResponse = await _transferClient.CreateBook(bookRequest);
                var book = mapper.Map<Books>(bookResponse);
                book.UserId = user.Id;
                await _bookService.CreateAsync(book);


                var message = new Message(new string[] { user.Email }, "Satın alımınız için teşekkürler :)", MailBody.MailBodyPnr(book.Pnr.ToString()), null);
                await _emailService.SendEmailAsync(message);

                var booksResponse = mapper.Map<CreateBookResponse>(bookResponse);
                return booksResponse;
            }

            throw new UserNotFoundExpection($"id : {request.UserId} user did not found");
        }
    }
}
