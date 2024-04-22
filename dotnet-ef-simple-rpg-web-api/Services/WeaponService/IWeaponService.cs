using dotnet_ef_simple_rpg_web_api.Dtos.Weapon;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.WeaponService;

public interface IWeaponService
{
    Task<ServiceResponse<List<GetWeaponWithIdResponseDto>>> GetAllWeapons();

    //Task<ServiceResponse<List<GetWeaponWithIdResponseDto>>> AddWeapon(AddWeaponDto newWeapon);
}
