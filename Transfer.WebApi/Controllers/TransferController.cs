using Microsoft.AspNetCore.Mvc;
using MediatR;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Business.Abstract;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;
using Transfer.Application.Transfer.ActionFilters;

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
        public async Task<IActionResult> GetOneWay([FromQuery] GetOneWayRequest requestModel)
        {
            List<GetOneWayResponse> allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }

        [HttpGet("SearchRoundWay")]
        public async Task<IActionResult> GetRoundWay([FromQuery] GetRoundWayRequest requestModel)
        {
            List<GetRoundWayResponse> allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }

        [HttpGet($"/{nameof(GetUser)}")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserRequest requestModel)
        {
            GetUserResponse allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }

        [HttpPost($"/{nameof(CreateUser)}")]
        [ValidationFilter]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto requestModel)
        {
            CreateUserResponse createdUser = await _mediator.Send(requestModel);
            return Ok(createdUser);
        }

        [HttpPost($"/{nameof(CreateBooks)}")]
        [ValidationFilter]
        public async Task<IActionResult> CreateBooks([FromBody] CreateBookRequestDto requestModel)
        {
            CreateBookResponse allUsers = await _mediator.Send(requestModel);
            return Ok(allUsers);
        }
  

    }
}
