using AutoMapper;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Campaign.Queries.Response.DataTransferObjects;
using Transfer.Client.Request;
using Transfer.Client.Response;
using Transfer.Client.ResponseAlt;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;
using Transfer.Server.CQRS.Commands.Response;
using Transfer.Server.CQRS.Queries.Request;

namespace Transfer.Server.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserRequest, User>();

            CreateMap<CreateBookRequest, TransferServiceCreateBookRequest>();
            CreateMap<TransferServiceBookResponse, CreateBookResponse>();

            CreateMap<GetOneWayRequest, TransferServiceSearchOneWayRequest>();
            CreateMap<TransferServiceSearchOneWayResponse, GetOneWayResponse>();

            CreateMap<GetRoundWayRequest, TransferServiceSerachRoundWayRequest>();
            CreateMap<TransferServiceSearchRoundWayResponse, GetRoundWayResponse>();

            CreateMap<CreateValidateRequest, TransferServiceBookValidateRequest>();
            CreateMap<TransferServiceBookValidateResponse, CreateValidateResponse>();


            CreateMap<TransferServiceBookResponse, Books>()
      .ForMember(x => x.VehicleIds, y => y.MapFrom(x => x.Transfers.Vehicle.Id));
        }
    }
}
