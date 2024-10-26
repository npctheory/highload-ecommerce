namespace Authentication.Interfaces.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(string account_id);
}