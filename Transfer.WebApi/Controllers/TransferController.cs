﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using Transfer.DataAccess.Concrate;
using MediatR;
using Transfer.WebApi.CQRS.Queries.Response;
using Transfer.WebApi.CQRS.Queries.Request;

namespace Transfer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : Controller
    {
        TransferContext context = new TransferContext();

        IMediator _mediator;
        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/")]
        public async Task<IActionResult> Get([FromQuery] GetAllVehicleQueryRequest requestModel)
        {
            List<GetAllVehicleQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }
    }
}
