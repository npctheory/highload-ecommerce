namespace Authentication.Implementations.Repositories;

using Authentication.Entities;
using Authentication.Interfaces.Repositories;
using MySql.Data.MySqlClient;
using Dapper;

public class LoginEntityRepositoryMySql : ILoginEntityRepository
{
    private readonly string _connectionString;

    public LoginEntityRepositoryMySql(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<LoginEntity> GetByIdAsync(int accountId)
    {
        using var connection = new MySqlConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<LoginEntity>(
            @"SELECT 
                account_id AS AccountId,
                userid AS UserId,
                user_pass AS UserPass,
                sex AS Sex,
                email AS Email,
                group_id AS GroupId,
                state AS State,
                unban_time AS UnbanTime,
                expiration_time AS ExpirationTime,
                logincount AS LoginCount,
                lastlogin AS LastLogin,
                last_ip AS LastIp,
                birthdate AS Birthdate,
                character_slots AS CharacterSlots,
                pincode AS Pincode,
                pincode_change AS PincodeChange,
                vip_time AS VipTime,
                old_group AS OldGroup,
                web_auth_token AS WebAuthToken,
                web_auth_token_enabled AS WebAuthTokenEnabled
            FROM login 
            WHERE account_id = @AccountId",
            new { AccountId = accountId });
    }

    public async Task<LoginEntity> GetByUserIdAsync(string userId)
    {
        using var connection = new MySqlConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<LoginEntity>(
            "SELECT * FROM login WHERE userid = @UserId",
            new { UserId = userId });
    }

    public async Task<int> CreateAsync(LoginEntity login)
    {
        using var connection = new MySqlConnection(_connectionString);
        return await connection.ExecuteScalarAsync<int>(@"
            INSERT INTO login (userid, user_pass, sex, email, group_id, state, unban_time, expiration_time, logincount, last_ip, birthdate, character_slots, pincode, pincode_change, vip_time, old_group, web_auth_token, web_auth_token_enabled)
            VALUES (@UserId, @UserPass, @Sex, @Email, @GroupId, @State, @UnbanTime, @ExpirationTime, @LoginCount, @LastIp, @Birthdate, @CharacterSlots, @Pincode, @PincodeChange, @VipTime, @OldGroup, @WebAuthToken, @WebAuthTokenEnabled);
            SELECT LAST_INSERT_ID();",
            login);
    }

    public async Task UpdateAsync(LoginEntity login)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.ExecuteAsync(@"
            UPDATE login SET
                userid = @UserId,
                user_pass = @UserPass,
                sex = @Sex,
                email = @Email,
                group_id = @GroupId,
                state = @State,
                unban_time = @UnbanTime,
                expiration_time = @ExpirationTime,
                logincount = @LoginCount,
                lastlogin = @LastLogin,
                last_ip = @LastIp,
                birthdate = @Birthdate,
                character_slots = @CharacterSlots,
                pincode = @Pincode,
                pincode_change = @PincodeChange,
                vip_time = @VipTime,
                old_group = @OldGroup,
                web_auth_token = @WebAuthToken,
                web_auth_token_enabled = @WebAuthTokenEnabled
            WHERE account_id = @AccountId",
            login);
    }

    public async Task DeleteAsync(int accountId)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.ExecuteAsync(
            "DELETE FROM login WHERE account_id = @AccountId",
            new { AccountId = accountId });
    }
}