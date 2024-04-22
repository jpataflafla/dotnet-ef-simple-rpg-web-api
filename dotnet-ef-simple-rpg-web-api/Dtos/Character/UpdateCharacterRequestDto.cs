using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Dtos.Character;

public class UpdateCharacterRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "Adventurer";
    public RpgClass Class { get; set; } = RpgClass.Fighter;
    public int HitPoints { get; set; } = 100;
    public int Intelligence { get; set; } = 10;
    public int Defense { get; set; } = 10;
    public int Strength { get; set; } = 10;
}
