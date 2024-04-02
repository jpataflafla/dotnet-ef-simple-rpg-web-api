namespace dotnet_ef_simple_rpg_web_api.Dtos.Book;

public class AddBookRequestDto
{
    public string Name { get; set; } = string.Empty;
    public int Wisdom { get; set; }
    public int CharacterId { get; set; }
}