using Orders.Entities;

namespace Orders.Interfaces.Repositories;

public interface IMailAttachmentRepository
{
    Task<List<MailAttachmentEntity>> GetByMailIdAsync(long mailId);
    Task CreateAsync(long mailId, MailAttachmentEntity attachment);
    Task DeleteByMailIdAsync(long mailId);
}