using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.User;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterRequestDto request)
    {
        // To add/set additional elements such as user email etc.
        // add the necessary elements to UserRegisterDto
        // and then provide them here, adding them to the User object.
        var response = await _authRepository.Register(
            new User { Username = request.Username },
            request.Password);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ServiceResponse<int>>> Login(UserRegisterRequestDto request)
    {
        var response = await _authRepository.Login(
            request.Username,
            request.Password);

        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }
}