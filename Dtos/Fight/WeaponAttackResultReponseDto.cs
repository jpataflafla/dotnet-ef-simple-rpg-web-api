namespace dotnet_ef_simple_rpg_web_api.Dtos.Fight;
public class WeaponAttackResultResponseDto
{
    public string AttackerName { get; set; } = string.Empty;
    public string OpponentName { get; set; } = string.Empty;
    public int AttackerHP { get; set; }
    public int OpponentHP { get; set; }
    public int Damage { get; set; }


}