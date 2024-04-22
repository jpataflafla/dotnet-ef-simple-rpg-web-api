
using System.Runtime.CompilerServices;
using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.FightService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FightController : ControllerBase
{
    private readonly IFightService _fightService;

    public FightController(IFightService fightService)
    {
        _fightService = fightService;
    }

    [HttpPost("WeaponAttack")]
    public async Task<ActionResult<ServiceResponse<WeaponAttackResultResponseDto>>> WeaponAttack
        (WeaponAttackRequestDto weaponAttackRequestDto)
    {
        return Ok(await _fightService.WeaponAttack(weaponAttackRequestDto));
    }

    [HttpPost("SkillAttack")]
    public async Task<ActionResult<ServiceResponse<WeaponAttackResultResponseDto>>> SkillAttack
    (SkillAttackRequestDto skillAttackRequestDto)
    {
        return Ok(await _fightService.SkillAttack(skillAttackRequestDto));
    }

    [HttpPost("AutomaticFight")]
    public async Task<ActionResult<ServiceResponse<FightResultResponseDto>>> AutomaticFight
    (FightRequestDto fightRequestDto)
    {
        return Ok(await _fightService.AutomaticFight(fightRequestDto));
    }

    [AllowAnonymous]
    [HttpGet("HighScore")]
    public async Task<ActionResult<ServiceResponse<List<GetHighScoreResponseDto>>>> GetHighScore()
    {
        return Ok(await _fightService.GetHighScore());
    }
}