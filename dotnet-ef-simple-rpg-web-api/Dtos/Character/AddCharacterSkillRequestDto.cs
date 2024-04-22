namespace dotnet_ef_simple_rpg_web_api.Dtos.Character;

public class AddCharacterSkillRequestDto
{
    public int CharacterId { get; set; }
    public int SkillId { get; set; }
}