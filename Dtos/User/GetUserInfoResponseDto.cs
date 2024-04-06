namespace dotnet_ef_simple_rpg_web_api.Dtos.User;

public class GetUserInfoResponseDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}
