using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Transfer.DataAccess.Concrete;
using MediatR;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Business.Abstract;

namespace Transfer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : Controller
    {

        IMediator _mediator;
        IUserService _userService;
        IBookService _bookService;
        public TransferController(IUserService userService, IBookService bookService, IMediator mediator)
        {
            _userService = userService;
            _bookService = bookService;
            _mediator = mediator;
        }

        [HttpGet("GetBookDetail")]
        public async Task<IActionResult> GetBookDetail([FromQuery] GetBookRequest requestModel)
        {
            GetBookResponse bookDetail = await _mediator.Send(requestModel);
            return Ok(bookDetail);
        }

        [HttpGet("SearchOneWay")]
        public async Task<IActionResult> SearchOneWay([FromQuery] GetOneWayRequest requestModel)
        {
            List<GetOneWayResponse> allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }


        [HttpGet($"/{nameof(GetUser)}")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserRequest requestModel)
        {
            GetUserResponse allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }

        [HttpPost($"/{nameof(CreateUser)}")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest requestModel)
        {
            CreateUserResponse createdUser = await _mediator.Send(requestModel);
            return Ok(createdUser);
        }

        [HttpPost($"/{nameof(CreateBooks)}")]
        public async Task<IActionResult> CreateBooks([FromBody] CreateBookTransferRequest requestModel)
        {
            CreateBookTransferResponse allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }

    }
}
