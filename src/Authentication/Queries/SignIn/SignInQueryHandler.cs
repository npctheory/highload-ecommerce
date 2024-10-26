using System;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;
using Authentication.Interfaces.Repositories;
using Shared.DTO.Authentication;
using Authentication.Entities;
using Authentication.Interfaces.Services;

namespace Core.Application.Users.Queries.Login
{
    public class SignInQueryHandler : IRequestHandler<SignInQuery, JwtTokenDTO>
    {
        private readonly ILoginEntityRepository _loginRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;

        public SignInQueryHandler(
            ILoginEntityRepository loginRepository,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper)
        {
            _loginRepository = loginRepository ?? throw new ArgumentNullException(nameof(loginRepository));
            _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<JwtTokenDTO> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            LoginEntity login = await _loginRepository.GetByIdAsync(request.AccountId);

            if (login == null || !VerifyPassword(request.Password, login.UserPass))
            {
                throw new UnauthorizedAccessException("Invalid user ID or password.");
            }

            JwtTokenDTO token = new JwtTokenDTO
            {
                token = _jwtTokenGenerator.GenerateToken(login.AccountId.ToString()),
            };

            return token;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            return inputPassword == storedPassword;
        }
    }
}