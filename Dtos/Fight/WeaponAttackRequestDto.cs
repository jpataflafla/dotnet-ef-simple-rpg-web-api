namespace dotnet_ef_simple_rpg_web_api.Dtos.Fight;

public class WeaponAttackRequestDto
{
    public int AttackerId { get; set; }
    public int AttackerWeaponId { get; set; }
    public int OpponentId { get; set; }
}