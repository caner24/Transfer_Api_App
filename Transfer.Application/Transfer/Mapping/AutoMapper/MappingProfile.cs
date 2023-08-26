using AutoMapper;
using Transfer.Application.Campaign.Queries.Response;
using Transfer.Application.Campaign.Queries.Response.DataTransferObjects;
using Transfer.Application.Transfer.Commands.Request.DataTransferObjects;
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
            CreateMap<CreateUserRequestDto, User>();
            CreateMap<CreateBookRequestDto, TransferServiceBookValidateRequest>();
            CreateMap<CreateBookRequestDto, TransferServiceCreateBookRequest>();

            CreateMap<CreateBookRequest, TransferServiceCreateBookRequest>();
            CreateMap<TransferServiceBookResponse, CreateBookResponse>();

            CreateMap<GetOneWayRequest, TransferServiceSearchOneWayRequest>();
            CreateMap<TransferServiceSearchOneWayResponse, GetOneWayResponse>();

            CreateMap<TransferServiceBookResponse, GetBookResponse>();

            CreateMap<GetRoundWayRequest, TransferServiceSerachRoundWayRequest>();
            CreateMap<TransferServiceSearchRoundWayResponse, GetRoundWayResponse>();

            CreateMap<TransferServiceBookValidateResponse, CreateValidateResponse>();


            CreateMap<TransferServiceBookResponse, Books>()
      .ForMember(x => x.VehicleIds, y => y.MapFrom(x => x.Transfers.Vehicle.Id));
        }
    }
}
