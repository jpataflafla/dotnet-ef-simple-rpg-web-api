namespace dotnet_ef_simple_rpg_web_api.Models;

/// <summary>
/// A character can have multiple skills,
/// so this is just many to many relationship.
/// </summary>
public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Damage { get; set; }
    public List<Character>? Characters { get; set; }
}