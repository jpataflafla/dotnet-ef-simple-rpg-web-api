namespace dotnet_ef_simple_rpg_web_api.Models;

/// <summary>
/// A character can have multiple skills,
/// so this is just many to many relationship.
/// </summary>
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// This property represents the difficulty or complexity of the skill. 
    /// This property allows players to quickly assess the relative complexity of different skills 
    /// and make informed decisions about which skills to prioritize or invest in. 
    /// Additionally, it adds another dimension to character progression, 
    /// as players may choose to focus on mastering simpler skills before 
    /// tackling more challenging ones.
    /// </summary>
    public int Complexity { get; set; }
    public List<Character>? Characters { get; set; }
}