using dotnet_ef_simple_rpg_web_api.Dtos.User;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.UserService;

public interface IUserService
{
    Task<ServiceResponse<List<GetUserInfoResponseDto>>> GetAllUsers();
}