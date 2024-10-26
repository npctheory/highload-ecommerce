using Authentication.Entities;
using Authentication.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared.DTO.Authentication;

namespace Authentication.Queries.GetLogin;

public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, LoginDTO>
{
    private readonly ILoginEntityRepository _loginRepository;
    private readonly IMapper _mapper;

    public GetLoginQueryHandler(ILoginEntityRepository loginRepository, IMapper mapper)
    {
        _loginRepository = loginRepository;
        _mapper = mapper;
    }

    public async Task<LoginDTO> Handle(GetLoginQuery request, CancellationToken cancellationToken)
    {
        var loginEntity = await _loginRepository.GetByIdAsync(request.AccountId);
        LoginDTO loginDTO = _mapper.Map<LoginDTO>(loginEntity);
        return loginDTO;
    }
}
