namespace Authentication.Entities;

public class CharEntity
{
    public uint CharId { get; set; }
    public uint AccountId { get; set; }
    public byte CharNum { get; set; }
    public string Name { get; set; } = string.Empty;
    public ushort Class { get; set; }
    public ushort BaseLevel { get; set; }
    public ushort JobLevel { get; set; }
    public ulong BaseExp { get; set; }
    public ulong JobExp { get; set; }
    public uint Zeny { get; set; }
    public ushort Str { get; set; }
    public ushort Agi { get; set; }
    public ushort Vit { get; set; }
    public ushort Dex { get; set; }
    public ushort Luk { get; set; }
    public ushort MaxHp { get; set; }
    public ushort Hp { get; set; }
    public ushort MaxSp { get; set; }
    public ushort Sp { get; set; }
    public string LastMap { get; set; } = string.Empty;
    public ushort LastX { get; set; }
    public ushort LastY { get; set; }
    public string Sex { get; set; } = "M";
    public byte Online { get; set; }
}