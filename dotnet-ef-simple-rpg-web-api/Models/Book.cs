namespace dotnet_ef_simple_rpg_web_api.Models;

/// <summary>
/// The idea is that one character can have only one book at a time. 
/// In other words, it is a one-to-one relationship
/// </summary>
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Wisdom { get; set; }
    public Character? Character { get; set; }
    public int CharacterId { get; set; }
}