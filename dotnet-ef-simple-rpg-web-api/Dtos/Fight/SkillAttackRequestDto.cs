namespace dotnet_ef_simple_rpg_web_api.Dtos.Fight;

public class SkillAttackRequestDto
{
    public int AttackerId { get; set; }
    public int AttackerSkillId { get; set; }
    public int OpponentId { get; set; }
}