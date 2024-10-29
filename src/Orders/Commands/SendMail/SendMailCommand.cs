using MediatR;

namespace Orders.Commands.SendMail;

public class SendMailCommand : IRequest<long>
{
    public string DestName { get; set; } = string.Empty;
    public uint DestId { get; set; }
    public uint Zeny { get; set; }
}