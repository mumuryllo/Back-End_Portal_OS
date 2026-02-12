using AutoMapper;
using PortalOS.Contracts.Request;
using PortalOS.Contracts.Response;
using PortalOS.Domain.Entities;
using PortalOS.Exceptions;
using PortalOS.Interfaces;
using PortalOS.Interfaces.Services;

namespace PortalOS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
        {
            var existingUser = await _uow.Users.GetByEmailAsync(dto.Email);

            if (existingUser is not null)
                throw new ConflictException("Já existe um usuário cadastrado com este email.");

            var user = _mapper.Map<User>(dto);

            user.Id = Guid.NewGuid();
            user.Active = true;
            user.CreatedAt = DateTime.UtcNow;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _uow.Users.AddAsync(user);
            await _uow.CommitAsync();

            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
