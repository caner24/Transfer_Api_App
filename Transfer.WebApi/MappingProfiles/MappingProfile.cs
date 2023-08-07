using AutoMapper;
using Transfer.Entity;
using Transfer.WebApi.CQRS.Queries.Response;
using Transfer.WebApi.Models;

namespace Transfer.WebApi.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PickUpPoint, PickUpPointViewModel>();
            CreateMap<DropOffPoint, DropOffPointViewModel>(); 
        }
    }
}
