namespace dotnet_ef_simple_rpg_web_api.Dtos.Skill;

public class GetSkillWithIdResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Complexity { get; set; }
}