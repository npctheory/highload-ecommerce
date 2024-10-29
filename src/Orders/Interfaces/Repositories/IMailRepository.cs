using Orders.Entities;

namespace Orders.Interfaces.Repositories;

public interface IMailRepository
{
    Task<long> CreateAsync(MailEntity mail);
}