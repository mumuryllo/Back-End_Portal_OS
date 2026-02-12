using PortalOS.Contracts.Request;
using PortalOS.Contracts.Response;

namespace PortalOS.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateAsync(CreateUserDto dto);
    }
}
