using Authentication.Entities;
using AutoMapper;
using Shared.DTO.Authentication;

namespace Authentication.Configuration;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<LoginEntity, LoginDTO>();
    }
}