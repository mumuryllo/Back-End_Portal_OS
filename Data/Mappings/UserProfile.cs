using AutoMapper;
using PortalOS.Contracts.Request;
using PortalOS.Contracts.Response;
using PortalOS.Domain.Entities;

namespace PortalOS.Data.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<CreateUserDto, User>()
           .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
