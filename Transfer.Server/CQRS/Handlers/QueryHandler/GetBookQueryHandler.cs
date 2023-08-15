using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.Client;
using Transfer.Client.Response;
using Transfer.Client.ResponseAlt;
using Transfer.Core.CrosCuttingConcerns.Caching;
using Transfer.Entity.Expections;
using Transfer.Server.CQRS.Queries.Request;
using Transfer.Server.CQRS.Queries.Response;

namespace Transfer.Server.CQRS.Handlers.QueryHandler
{
    public class GetBookQueryHandler : IRequestHandler<GetBookRequest, Root>
    {
        private readonly TransferClient _transferClient;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ICacheManager _cacheManager;
        public GetBookQueryHandler(IBookService bookService, ICacheManager cacheManager, TransferClient transferClient, IUserService userService)
        {
            _bookService = bookService;
            _cacheManager = cacheManager;
            _transferClient = transferClient;
            _userService = userService;
        }

        public async Task<Root> Handle(GetBookRequest request, CancellationToken cancellationToken)
        {
            if (_cacheManager.IsAdd("GetBookResponse"))
            {
                return _cacheManager.Get<Root>("GetBookResponse");
            }
            var pnr = await _bookService.Table.Select(x => new { x.Pnr, x.UserId }).FirstOrDefaultAsync(x => x.Pnr == request.Pnr);
            if (pnr != null)
            {
                var user = await _userService.GetAsync(x => x.Id == pnr.UserId);
                var response = await _transferClient.GetBook(pnr.Pnr, user.LastName);
                _cacheManager.Add("GetBookResponse", response, 5);
                return _cacheManager.Get<Root>("GetBookResponse");
            }
            throw new PnrNotFoundExpection($"Your searched pnr number (${request.Pnr}) didn't found.");

        }
    }
}


