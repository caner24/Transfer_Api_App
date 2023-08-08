using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Business.Abstract;
using Transfer.DataAccess.Concrete;
using Transfer.Entity;
using Transfer.WebApi.CQRS.Queries.Request;
using Transfer.WebApi.CQRS.Queries.Response;
using Transfer.WebApi.Models;

namespace Transfer.WebApi.CQRS.Handlers.QueryHandler
{
    public class GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehicleQueryRequest, List<GetAllVehicleQueryResponse>>
    {
        private readonly IMapper _mapper;
        public GetAllVehiclesQueryHandler( IMapper mapper)
        {
            _mapper = mapper;
        }
        TransferContext context = new TransferContext();
        public async Task<List<GetAllVehicleQueryResponse>> Handle(GetAllVehicleQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Log.Information($"{nameof(GetAllVehicleQueryRequest)}  İstek geldi . . . ");

                return await context.Vehicle.AsNoTracking().Include(x => x.PickUpPoint).Include(x => x.DropOffPoint).Select(product => new GetAllVehicleQueryResponse
                {
                    Description = product.Description,
                    Date = product.Date,
                    TotalPrice = product.TotalPrice,
                    ExtraServices = product.ExtraServices,
                    GenericData = product.GenericData,
                    ImageUrl = product.ImageUrl,
                    Id = product.Id,
                    MaxBaggage = product.MaxBaggage,
                    MaxPassenger = product.MaxPassenger,
                    PickupPoint = _mapper.Map<PickUpPointViewModel>(product.PickUpPoint),
                    DropOffPoint = _mapper.Map<DropOffPointViewModel>(product.DropOffPoint),
                    ProviderId = product.ProviderId,
                    ReturnDate = product.ReturnDate,
                    TransferType = product.TransferType,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Information($"{nameof(GetAllVehicleQueryRequest)}  İstek gelirken bir hata meydana geldi . . . {ex.Message} ");
                throw;
            }
            finally
            {
                Log.Information($"{nameof(GetAllVehicleQueryResponse)}  İstek sonlandı . . . ");
                           
            }

        }


    }
}
