using Authentication.Entities;

namespace Authentication.Interfaces.Repositories;

public interface ICharEntityRepository
{
    Task<CharEntity> GetByIdAsync(uint charId);
    Task<IEnumerable<CharEntity>> GetByAccountIdAsync(uint accountId);
    Task<uint> CreateAsync(CharEntity character);
    Task UpdateAsync(CharEntity character);
    Task DeleteAsync(uint charId);
}