using System.Text.Json;
using Authentication.Queries.GetLogin;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.Authentication;

namespace Authentication.Controllers;

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public LoginController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("login/{accountId}")]
        public async Task<IActionResult> GetLogin([FromRoute] int accountId)
        {
            LoginDTO login = await _mediator.Send(new GetLoginQuery(accountId));
            return Ok(login);
        }


        [AllowAnonymous]
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] JsonElement jsonElement)
        {
            string id = jsonElement.GetProperty("id").GetString();
            string password = jsonElement.GetProperty("password").GetString();

            JwtTokenDTO token = await _mediator.Send(new SignInQuery(int.Parse(id),password)); 
            return Ok(token);
        }

        /* 
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] JsonElement jsonElement)
        {
            string first_name = jsonElement.GetProperty("first_name").GetString();
            string second_name = jsonElement.GetProperty("second_name").GetString();
            string birthdate = jsonElement.GetProperty("birthdate").GetString();
            string biography = jsonElement.GetProperty("biography").GetString();
            string city = jsonElement.GetProperty("city").GetString();
            string password = jsonElement.GetProperty("password").GetString();

            LoginDTO login = await _mediator.Send(new RegisterCommand(first_name,second_name,birthdate,biography,city,password)); 
            return Ok(login);
        }
        */
    }