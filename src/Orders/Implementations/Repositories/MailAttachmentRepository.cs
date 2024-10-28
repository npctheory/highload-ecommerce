using MySql.Data.MySqlClient;
using Orders.Entities;
using Orders.Interfaces.Repositories;
using Dapper;

namespace Orders.Implementations.Repositories;

public class MailAttachmentRepositoryMySql : IMailAttachmentRepository
{
    private readonly string _connectionString;

    public MailAttachmentRepositoryMySql(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<MailAttachmentEntity>> GetByMailIdAsync(long mailId)
    {
        using var connection = new MySqlConnection(_connectionString);
        var attachments = await connection.QueryAsync<MailAttachmentEntity>(
            "SELECT * FROM mail_attachments WHERE id = @MailId",
            new { MailId = mailId });
        
        return attachments.ToList();
    }

    public async Task CreateAsync(long mailId, MailAttachmentEntity attachment)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.ExecuteAsync(@"
            INSERT INTO mail_attachments (
                id, `index`, nameid, amount, refine, attribute, identify,
                card0, card1, card2, card3,
                option_id0, option_val0, option_parm0,
                option_id1, option_val1, option_parm1,
                option_id2, option_val2, option_parm2,
                option_id3, option_val3, option_parm3,
                option_id4, option_val4, option_parm4,
                unique_id, bound, enchantgrade)
            VALUES (
                @Id, @Index, @NameId, @Amount, @Refine, @Attribute, @Identify,
                @Card0, @Card1, @Card2, @Card3,
                @OptionId0, @OptionVal0, @OptionParm0,
                @OptionId1, @OptionVal1, @OptionParm1,
                @OptionId2, @OptionVal2, @OptionParm2,
                @OptionId3, @OptionVal3, @OptionParm3,
                @OptionId4, @OptionVal4, @OptionParm4,
                @UniqueId, @Bound, @EnchantGrade)",
            new { Id = mailId, attachment });
    }

    public async Task DeleteByMailIdAsync(long mailId)
    {
        using var connection = new MySqlConnection(_connectionString);
        await connection.ExecuteAsync(
            "DELETE FROM mail_attachments WHERE id = @MailId",
            new { MailId = mailId });
    }
}