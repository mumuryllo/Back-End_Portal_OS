using PortalOS.Contracts.Request;
using PortalOS.Contracts.Response;

namespace PortalOS.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto dto);
    }
}
