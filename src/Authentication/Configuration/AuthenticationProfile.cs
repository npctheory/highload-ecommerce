using Authentication.Entities;
using AutoMapper;
using Shared.DTO.Authentication;
using Shared.DTO.Authentication.ListCharactersByAccountId;

namespace Authentication.Configuration;

public class AuthenticationProfile : Profile
{
    public AuthenticationProfile()
    {
        CreateMap<LoginEntity, LoginDTO>();
        CreateMap<CharEntity, CharacterDTO>();
    }
}