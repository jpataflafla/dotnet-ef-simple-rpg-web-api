using dotnet_ef_simple_rpg_web_api.Dtos.Skill;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.SkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class SkillController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [AllowAnonymous]
    [HttpGet("AllAvailable")]
    public async Task<ActionResult<ServiceResponse<GetSkillDto>>> GetAllSkills()
    {
        return Ok(await _skillService.GetAllSkills());
    }
}