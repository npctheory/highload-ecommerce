using MediatR;
using Orders.Interfaces.Repositories;
using Orders.Entities;

namespace Orders.Commands.SendMail;

public class SendMailCommandHandler : IRequestHandler<SendMailCommand, long>
{
    private readonly IMailRepository _mailRepository;

    public SendMailCommandHandler(IMailRepository mailRepository)
    {
        _mailRepository = mailRepository;
    }

    public async Task<long> Handle(SendMailCommand request, CancellationToken cancellationToken)
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

        return await _mailRepository.CreateAsync(mailEntity);
    }
}