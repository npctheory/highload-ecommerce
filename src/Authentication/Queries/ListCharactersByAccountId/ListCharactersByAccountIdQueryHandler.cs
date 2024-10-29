using MediatR;
using Shared.DTO.Authentication.ListCharactersByAccountId;
using Authentication.Interfaces.Repositories;
using AutoMapper;

namespace Authentication.Queries.ListCharactersByAccountId;

public class ListCharactersByAccountIdQueryHandler : IRequestHandler<ListCharactersByAccountIdQuery, ListCharactersByAccountIdResponse>
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IMapper _mapper;

    public ListCharactersByAccountIdQueryHandler(ICharacterRepository characterRepository, IMapper mapper)
    {
        _characterRepository = characterRepository;
        _mapper = mapper;
    }

    public async Task<ListCharactersByAccountIdResponse> Handle(ListCharactersByAccountIdQuery request, CancellationToken cancellationToken)
    {
        var characters = await _characterRepository.GetCharactersByAccountIdAsync((uint)request.AccountId);
        
        return new ListCharactersByAccountIdResponse
        {
            Characters = _mapper.Map<List<CharacterDTO>>(characters)
        };
    }
}