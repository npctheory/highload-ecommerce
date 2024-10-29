using Authentication.Entities;
using Authentication.Interfaces.Repositories;
using Dapper;
using MySql.Data.MySqlClient;

namespace Authentication.Implementations.Repositories;

public class CharacterRepositoryMySql : ICharacterRepository
{
    private readonly string _connectionString;

    public CharacterRepositoryMySql(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<CharEntity>> GetCharactersByAccountIdAsync(uint accountId)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.OpenAsync();

        const string sql = @"
            SELECT 
                char_id AS CharId,
                account_id AS AccountId, 
                char_num AS CharNum,
                name AS Name,
                class AS Class,
                base_level AS BaseLevel,
                job_level AS JobLevel,
                base_exp AS BaseExp,
                job_exp AS JobExp,
                zeny AS Zeny,
                str AS Str,
                agi AS Agi,
                vit AS Vit,
                dex AS Dex,
                luk AS Luk,
                max_hp AS MaxHp,
                hp AS Hp,
                max_sp AS MaxSp,
                sp AS Sp,
                last_map AS LastMap,
                last_x AS LastX,
                last_y AS LastY,
                sex AS Sex,
                online AS Online
            FROM `char` 
            WHERE account_id = @AccountId 
            ORDER BY char_num ASC";

        var characters = await connection.QueryAsync<CharEntity>(sql, new { AccountId = accountId });
        return characters;
    }
}