using System;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Authentication;

public class JwtTokenDTO
{
    public string token { get; set; }
}