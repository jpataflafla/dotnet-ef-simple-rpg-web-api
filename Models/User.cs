namespace dotnet_ef_simple_rpg_web_api.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public byte[] Password { get; set; } = new byte[0];
    public byte[] PasswordSalt { get; set; } = new byte[0];
    public List<Character>? Characters { get; set; }
}
