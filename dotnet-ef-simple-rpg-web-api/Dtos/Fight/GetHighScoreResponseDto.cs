namespace dotnet_ef_simple_rpg_web_api.Dtos.Fight;

public class GetHighScoreResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Fights { get; set; }
    public int Victories { get; set; }
    public int Defeats { get; set; }
}