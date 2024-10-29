using MediatR;
using Orders.Entities;
using Orders.Interfaces.Repositories;
using Shared.DTO.Orders.SendMailWithAttachment;

namespace Orders.Commands.SendMailWithAttachment;

public class SendMailWithAttachmentCommandHandler : IRequestHandler<SendMailWithAttachmentCommand, bool>
{
    private readonly IMailRepository _mailRepository;
    private readonly IMailAttachmentRepository _mailAttachmentRepository;

    public SendMailWithAttachmentCommandHandler(
        IMailRepository mailRepository,
        IMailAttachmentRepository mailAttachmentRepository)
    {
        _mailRepository = mailRepository;
        _mailAttachmentRepository = mailAttachmentRepository;
    }

    public async Task<bool> Handle(SendMailWithAttachmentCommand request, CancellationToken cancellationToken)
    {
        var mailEntity = new MailEntity
        {
            SendName = "Otus",
            SendId = 150000,
            DestName = request.DestName,
            DestId = request.DestId,
            Title = "Highload Item Shop purchase",
            Message = "Highload architect course project work. Item shop is available now!",
            Time = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Status = 0,
            Zeny = request.Zeny,
            Type = 0
        };

        var mailId = await _mailRepository.CreateAsync(mailEntity);

        var attachment = new MailAttachmentEntity
        {
            Id = mailId,
            Index = 0,
            NameId = (uint)request.AttachmentNameId,
            Identify = 1,
            Amount = request.AttachmentAmount
        };

        await _mailAttachmentRepository.CreateAsync(attachment);

        return true;
    }
}
