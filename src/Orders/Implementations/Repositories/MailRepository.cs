using MySql.Data.MySqlClient;
using Orders.Entities;
using Orders.Interfaces.Repositories;
using Dapper;

namespace Orders.Implementations.Repositories;

public class MailRepositoryMySql : IMailRepository
{
    private readonly string _connectionString;
    private readonly IMailAttachmentRepository _attachmentRepository;

    public MailRepositoryMySql(string connectionString, IMailAttachmentRepository attachmentRepository)
    {
        _connectionString = connectionString;
        _attachmentRepository = attachmentRepository;
    }

    public async Task<MailEntity?> GetByIdAsync(long id)
    {
        using var connection = new MySqlConnection(_connectionString);
        var mail = await connection.QuerySingleOrDefaultAsync<MailEntity>(
            "SELECT * FROM mail WHERE id = @Id",
            new { Id = id });

        if (mail != null)
        {
            mail.Attachments = await _attachmentRepository.GetByMailIdAsync(id);
        }

        return mail;
    }

    public async Task<List<MailEntity>> GetByDestIdAsync(uint destId)
    {
        using var connection = new MySqlConnection(_connectionString);
        var mails = await connection.QueryAsync<MailEntity>(
            "SELECT * FROM mail WHERE dest_id = @DestId",
            new { DestId = destId });

        var mailList = mails.ToList();
        foreach (var mail in mailList)
        {
            mail.Attachments = await _attachmentRepository.GetByMailIdAsync(mail.Id);
        }

        return mailList;
    }

    public async Task<List<MailEntity>> GetBySendIdAsync(uint sendId)
    {
        using var connection = new MySqlConnection(_connectionString);
        var mails = await connection.QueryAsync<MailEntity>(
            "SELECT * FROM mail WHERE send_id = @SendId",
            new { SendId = sendId });

        var mailList = mails.ToList();
        foreach (var mail in mailList)
        {
            mail.Attachments = await _attachmentRepository.GetByMailIdAsync(mail.Id);
        }

        return mailList;
    }

    public async Task<long> CreateAsync(MailEntity mail)
    {
        using var connection = new MySqlConnection(_connectionString);
        var id = await connection.ExecuteScalarAsync<long>(@"
            INSERT INTO mail (send_name, send_id, dest_name, dest_id, title, message, time, status, zeny, type)
            VALUES (@SendName, @SendId, @DestName, @DestId, @Title, @Message, @Time, @Status, @Zeny, @Type);
            SELECT LAST_INSERT_ID();",
            mail);

        foreach (var attachment in mail.Attachments)
        {
            await _attachmentRepository.CreateAsync(id, attachment);
        }

        return id;
    }

    public async Task UpdateStatusAsync(long id, short status)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.ExecuteAsync(
            "UPDATE mail SET status = @Status WHERE id = @Id",
            new { Id = id, Status = status });
    }

    public async Task DeleteAsync(long id)
    {
        using var connection = new MySqlConnection(_connectionString);
        await _attachmentRepository.DeleteByMailIdAsync(id);
        await connection.ExecuteAsync(
            "DELETE FROM mail WHERE id = @Id",
            new { Id = id });
    }
}