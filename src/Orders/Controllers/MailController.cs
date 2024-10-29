using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.Commands.SendMail;
using Shared.DTO.Orders.SendMailWithAttachment;

namespace Orders.Controllers;

public class MailController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("mail/send")]
    public async Task<ActionResult<long>> SendMail([FromBody] SendMailCommand command)
    {
        var mailId = await _mediator.Send(command);
        return Ok(mailId);
    }

    [AllowAnonymous]
    [HttpPost("mail/send-with-attachment")]
    public async Task<ActionResult<bool>> SendMailWithAttachment([FromBody] SendMailWithAttachmentCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}