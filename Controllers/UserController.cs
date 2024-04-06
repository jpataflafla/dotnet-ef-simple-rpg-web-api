using dotnet_ef_simple_rpg_web_api.Dtos.User;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("AllUsers")]
    public async Task<ActionResult<ServiceResponse<List<GetUserInfoResponseDto>>>> GetAllUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }
}