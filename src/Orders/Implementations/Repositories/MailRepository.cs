using MySql.Data.MySqlClient;
using Orders.Entities;
using Orders.Interfaces.Repositories;
using Dapper;

namespace Orders.Implementations.Repositories;

public class MailRepositoryMySql : IMailRepository
{
    private readonly string _connectionString;

    public MailRepositoryMySql(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<long> CreateAsync(MailEntity mail)
    {
        using var connection = new MySqlConnection(_connectionString);
        var id = await connection.ExecuteScalarAsync<long>(@"
            INSERT INTO mail (send_name, send_id, dest_name, dest_id, title, message, time, status, zeny, type)
            VALUES (@SendName, @SendId, @DestName, @DestId, @Title, @Message, @Time, @Status, @Zeny, @Type);
            SELECT LAST_INSERT_ID();",
            mail);

        return id;
    }
}