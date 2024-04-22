using System.Text.Json.Serialization;

namespace dotnet_ef_simple_rpg_web_api.Models;

/// <summary>
/// Enumeration representing different RPG character classes.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RpgClass
{
    /// <summary>
    /// A skilled and stealthy character, adept at ambushes and precision strikes.
    /// </summary>
    Rogue = 1,

    /// <summary>
    /// A stalwart warrior specializing in close-range combat, possessing high endurance and strength.
    /// </summary>
    Fighter = 2,

    /// <summary>
    /// A skilled marksman and tracker, proficient in ranged combat and wilderness survival.
    /// </summary>
    Ranger = 3,

    /// <summary>
    /// A wielder of arcane powers, capable of casting spells and manipulating magical energies.
    /// </summary>
    Magician = 4,

    /// <summary>
    /// A devout follower of divine powers, capable of healing and invoking blessings in battle.
    /// </summary>
    Cleric = 5,
}