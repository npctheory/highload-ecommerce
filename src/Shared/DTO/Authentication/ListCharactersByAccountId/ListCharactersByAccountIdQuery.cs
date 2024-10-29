using MediatR;

namespace Shared.DTO.Authentication.ListCharactersByAccountId;

public class ListCharactersByAccountIdQuery : IRequest<ListCharactersByAccountIdResponse>
{
    public int AccountId { get; set; }
}