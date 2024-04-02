namespace dotnet_ef_simple_rpg_web_api.Dtos.Weapon;

public class GetWeaponWithIdResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
}