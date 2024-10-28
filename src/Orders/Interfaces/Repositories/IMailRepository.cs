using Orders.Entities;

namespace Orders.Interfaces.Repositories;

public interface IMailRepository
{
    Task<MailEntity?> GetByIdAsync(long id);
    Task<List<MailEntity>> GetByDestIdAsync(uint destId);
    Task<List<MailEntity>> GetBySendIdAsync(uint sendId);
    Task<long> CreateAsync(MailEntity mail);
    Task UpdateStatusAsync(long id, short status);
    Task DeleteAsync(long id);
}