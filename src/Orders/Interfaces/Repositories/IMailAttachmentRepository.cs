using Orders.Entities;

namespace Orders.Interfaces.Repositories;

public interface IMailAttachmentRepository
{
    Task CreateAsync(MailAttachmentEntity attachment);
}