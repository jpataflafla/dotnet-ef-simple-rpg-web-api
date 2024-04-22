namespace dotnet_ef_simple_rpg_web_api.Models;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public static ServiceResponse<T> Fail(string message) => new ServiceResponse<T> { Success = false, Message = message };
}
