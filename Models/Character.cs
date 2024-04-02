namespace dotnet_ef_simple_rpg_web_api.Models;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; } = "Adventurer";

    public RpgClass Class { get; set; } = RpgClass.Fighter;

    /// <summary>
    /// HP – how much damage a character can take before being incapacitated.
    /// </summary>
    public int HitPoints { get; set; } = 100;

    /// <summary>
    /// Intelligence affects the ability to avoid unfavorable situations 
    /// and the effectiveness of inflicting ailments related to the character's status.
    /// </summary>
    public int Intelligence { get; set; } = 10;

    /// <summary>
    /// Defense is a character's ability to resist attacks.
    /// </summary>
    public int Defense { get; set; } = 10;

    /// <summary>
    /// Strength (St) affects the damage output of attacks.
    /// </summary>
    public int Strength { get; set; } = 10;

    /// <summary>
    /// User who owns this character
    /// </summary>
    public User? User { get; set; }

    public Book? Book { get; set; }
    public List<Skill>? Skills { get; set; }
    public List<Weapon>? Weapons { get; set; }
}