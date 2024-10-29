using MediatR;

namespace Shared.DTO.Orders.SendMailWithAttachment;

public class SendMailWithAttachmentCommand : IRequest<bool>
{
    public string DestName { get; set; } = string.Empty;
    public uint DestId { get; set; }
    public uint Zeny { get; set; }
    public long AttachmentNameId { get; set; }
    public uint AttachmentAmount { get; set; }
}
