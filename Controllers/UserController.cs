using Microsoft.AspNetCore.Mvc;
using PortalOS.Contracts.Request;
using PortalOS.Contracts.Response;
using PortalOS.Interfaces.Services;

namespace PortalOS.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Cria um novo usuário no sistema.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var createdUser = await _userService.CreateAsync(dto);

            return Created("", createdUser);
        }
    }
}
