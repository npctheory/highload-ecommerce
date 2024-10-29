using Authentication.Entities;

namespace Authentication.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task<IEnumerable<CharEntity>> GetCharactersByAccountIdAsync(uint accountId);
}