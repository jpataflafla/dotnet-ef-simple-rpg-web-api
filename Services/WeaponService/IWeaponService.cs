using dotnet_ef_simple_rpg_web_api.Dtos.Weapon;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.WeaponService;

public interface IWeaponService
{
    Task<ServiceResponse<List<GetWeaponWithIdDto>>> GetAllWeapons();

    //Task<ServiceResponse<List<GetWeaponWithIdDto>>> AddWeapon(AddWeaponDto newWeapon);
}
