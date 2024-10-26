namespace Shared.DTO.Authentication;

public record LoginDTO
{
    public int AccountId { get; init; }
    public string UserId { get; init; }
    public char Sex { get; init; }
    public string Email { get; init; }
    public byte GroupId { get; init; }
    public uint State { get; init; }
    public uint UnbanTime { get; init; }
    public uint ExpirationTime { get; init; }
    public uint LoginCount { get; init; }
    public DateTime? LastLogin { get; init; }
    public string LastIp { get; init; }
    public DateTime? Birthdate { get; init; }
    public byte CharacterSlots { get; init; }
    public string Pincode { get; init; }
    public uint PincodeChange { get; init; }
    public uint VipTime { get; init; }
    public byte OldGroup { get; init; }
    public string WebAuthToken { get; init; }
    public byte WebAuthTokenEnabled { get; init; }
}