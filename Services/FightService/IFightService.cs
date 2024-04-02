using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.FightService;

public interface IFightService
{
    Task<ServiceResponse<AttackResultResponseDto>> WeaponAttack
(WeaponAttackRequestDto weaponAttackRequestDto);
}