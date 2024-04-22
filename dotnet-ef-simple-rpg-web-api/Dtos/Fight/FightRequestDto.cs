namespace dotnet_ef_simple_rpg_web_api.Dtos.Fight;

public class FightRequestDto
{
    /// <summary>
    /// Characters involved in a fight/ death match
    /// </summary>
    public List<int> CharacterIds { get; set; } = new List<int>();

}