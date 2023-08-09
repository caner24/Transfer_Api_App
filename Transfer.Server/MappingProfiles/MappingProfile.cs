
using AutoMapper;
using Transfer.Entity;
using Transfer.Server.CQRS.Commands.Request;

namespace Transfer.Server.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Books, CreateBookRequest>();
            CreateMap<CreateUserRequest, User>();
        }
    }
}
