using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Weapon;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Services.WeaponService;

public class WeaponService : IWeaponService
{
    private readonly DataContext _dataContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public WeaponService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _dataContext = dataContext;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetWeaponDto>>> GetAllWeapons()
    {
        var response = new ServiceResponse<List<GetWeaponDto>>();
        try
        {
            var weapons = await _dataContext.Weapons
                .Select(weapon => _mapper.Map<GetWeaponDto>(weapon)).ToListAsync();

            if (weapons is null)
            {
                throw new Exception("No weapons found");
            }
            response.Data = weapons;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
