using Authentication.Entities;
using MediatR;
using Shared.DTO.Authentication;

namespace Authentication.Queries.GetLogin;

public record GetLoginQuery(int AccountId) : IRequest<LoginDTO>;
