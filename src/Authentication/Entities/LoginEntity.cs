namespace Authentication.Entities;
public class LoginEntity
{
    public int AccountId { get; set; }
    public string UserId { get; set; }
    public string UserPass { get; set; }
    public char Sex { get; set; }
    public string Email { get; set; }
    public byte GroupId { get; set; }
    public uint State { get; set; }
    public uint UnbanTime { get; set; }
    public uint ExpirationTime { get; set; }
    public uint LoginCount { get; set; }
    public DateTime? LastLogin { get; set; }
    public string LastIp { get; set; }
    public DateTime? Birthdate { get; set; }
    public byte CharacterSlots { get; set; }
    public string Pincode { get; set; }
    public uint PincodeChange { get; set; }
    public uint VipTime { get; set; }
    public byte OldGroup { get; set; }
    public string WebAuthToken { get; set; }
    public byte WebAuthTokenEnabled { get; set; }
}