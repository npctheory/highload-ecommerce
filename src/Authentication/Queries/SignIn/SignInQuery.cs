using MediatR;
using Shared.DTO.Authentication;

public record SignInQuery(int AccountId, string Password) : IRequest<JwtTokenDTO>;