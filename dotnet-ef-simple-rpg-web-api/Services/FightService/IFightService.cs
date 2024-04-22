using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.FightService;

public interface IFightService
{
    Task<ServiceResponse<WeaponAttackResultResponseDto>> WeaponAttack
        (WeaponAttackRequestDto weaponAttackRequestDto);

    Task<ServiceResponse<SkillAttackResultResponseDto>> SkillAttack
        (SkillAttackRequestDto skillAttackRequestDto);

    Task<ServiceResponse<FightResultResponseDto>> AutomaticFight
        (FightRequestDto fightRequestDto);

    Task<ServiceResponse<List<GetHighScoreResponseDto>>> GetHighScore();
}