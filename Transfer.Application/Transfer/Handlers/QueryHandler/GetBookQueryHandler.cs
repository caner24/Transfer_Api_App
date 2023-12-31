﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using PostSharp.Patterns.Caching;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Campaign.Queries.Response.DataTransferObjects;
using Transfer.Business.Abstract;
using Transfer.Client;
using Transfer.Client.Request;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Entity.Expections;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.Mapping.AutoMapper;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{

    [CacheConfiguration(ProfileName = "GetBookResponse")]
    public class GetBookQueryHandler : IRequestHandler<GetBookRequest, GetBookResponse>
    {
        private readonly TransferClient _transferClient;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        public GetBookQueryHandler(IBookService bookService, TransferClient transferClient, IUserService userService)
        {
            _bookService = bookService;
            _transferClient = transferClient;
            _userService = userService;
        }
        [Cache]
        public async Task<GetBookResponse> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            var mapper = MapperConfig.ConfigureMappings();

            var pnr = await _bookService.Table.Select(x => new { x.Pnr, x.UserId }).FirstOrDefaultAsync(x => x.Pnr == request.Pnr);
            if (pnr != null)
            {
                var user = await _userService.GetAsync(x => x.Id == pnr.UserId);
                if (user.LastName == request.LastName)
                {
                    TransferSerivceGetBookRequest transferSerivceGetBookRequest = new TransferSerivceGetBookRequest()
                    {
                        LastName = request.LastName,
                        Pnr = request.Pnr,
                    };
                    var response = await _transferClient.GetBook(transferSerivceGetBookRequest);
                    var returnedResponse = mapper.Map<GetBookResponse>(response);
                    return returnedResponse;
                }
                throw new PnrNotFoundExpection($"Your searched pnr number (${request.Pnr}) didn't found.");
            }
            throw new PnrNotFoundExpection($"Your searched pnr number (${request.Pnr}) didn't found.");
        }
    }
}


