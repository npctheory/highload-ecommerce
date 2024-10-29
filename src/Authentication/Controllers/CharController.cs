using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Authentication.ListCharactersByAccountId;

namespace Authentication.Controllers;

[ApiController]
public class CharController : ControllerBase
{
    private readonly IMediator _mediator;

    public CharController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("characters/{accountId}")]
    public async Task<ActionResult<ListCharactersByAccountIdResponse>> GetCharactersByAccountId(int accountId)
    {
        var query = new ListCharactersByAccountIdQuery { AccountId = accountId };
        var response = await _mediator.Send(query);
        return Ok(response);
    }
}