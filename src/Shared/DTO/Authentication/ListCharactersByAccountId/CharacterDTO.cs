namespace Shared.DTO.Authentication.ListCharactersByAccountId;

public class CharacterDTO
{
    public int CharId { get; set; }
    public int AccountId { get; set; }
    public byte CharNum { get; set; }
    public string Name { get; set; } = string.Empty;
}
