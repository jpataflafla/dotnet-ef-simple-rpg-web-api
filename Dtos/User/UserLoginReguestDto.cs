namespace dotnet_ef_simple_rpg_web_api.Dtos.User;

public class UserLoginRequestDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}