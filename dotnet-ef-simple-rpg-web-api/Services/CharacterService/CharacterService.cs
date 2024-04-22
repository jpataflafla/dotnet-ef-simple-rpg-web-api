using System.Security.Claims;
using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_ef_simple_rpg_web_api.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly IMapper _mapper;
    private readonly DataContext _dataContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CharacterService(IMapper mapper, DataContext dataContext, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _dataContext = dataContext;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        try
        {
            var character = _mapper.Map<Character>(newCharacter);

            // assign a character to the currently logged in user
            character.User = await _dataContext.Users.SingleOrDefaultAsync(user => user.Id == GetUserId());

            _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Characters
                .Where(character => character.User!.Id == GetUserId())
                .Select(character => _mapper.Map<GetCharacterResponseDto>(character)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

        try
        {
            var character = await _dataContext.Characters
                .SingleOrDefaultAsync(character =>
                    character.Id == id && character.User!.Id == GetUserId());
            if (character is null)
            {
                throw new Exception($"Character with Id:{id} was not found, so it cannot be deleted.");
            }

            _dataContext.Characters.Remove(character);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = await _dataContext.Characters
                .Where(character => character.User!.Id == GetUserId())
                .Select(character => _mapper.Map<GetCharacterResponseDto>(character)).ToListAsync();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        try
        {
            IQueryable<Character> query = _dataContext.Characters
                .Include(character => character.Book)
                .Include(character => character.Weapons)
                .Include(character => character.Skills)
                .Include(character => character.User);

            if (!IsUserAdmin())
            {
                // For non-admin users, filter characters by user ID
                query = query.Where(character => character.User!.Id == GetUserId());
            }
            var dbCharacters = await query.ToListAsync();
            serviceResponse.Data = dbCharacters
                .Select(character => _mapper.Map<GetCharacterResponseDto>(character)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

        try
        {
            var dbCharacter = await GetRawCharacterById(id);
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(dbCharacter);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<Character> GetRawCharacterById(int id)
    {
        var dbCharacter = await _dataContext.Characters
            .Include(character => character.Book)
            .Include(character => character.Weapons)
            .Include(character => character.Skills)
            .SingleOrDefaultAsync(character =>
                character.Id == id && character.User!.Id == GetUserId());
        if (dbCharacter is null)
        {
            throw new Exception($"Character with Id:{id} was not found.");
        }

        return dbCharacter;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

        try
        {
            var character = await _dataContext.Characters
                .SingleOrDefaultAsync(character =>
                character.Id == updatedCharacter.Id && character.User!.Id == GetUserId());
            if (character is null)
            {
                throw new Exception($"Character with Id:{updatedCharacter.Id} not found.");
            }

            character.Name = updatedCharacter.Name;
            character.Class = updatedCharacter.Class;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Defense = updatedCharacter.Defense;
            character.Strength = updatedCharacter.Strength;

            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    public async Task<ServiceResponse<GetCharacterResponseDto>> AddCharacterSkill
    (AddCharacterSkillRequestDto newCharacterSkill)
    {
        var response = new ServiceResponse<GetCharacterResponseDto>();
        try
        {
            var character = await _dataContext.Characters
                .Include(character => character.Book)
                .Include(character => character.Weapons)
                .Include(character => character.Skills)
                .SingleOrDefaultAsync(character =>
                    character.Id == newCharacterSkill.CharacterId && character.User!.Id == GetUserId());

            if (character is null)
            {
                throw new Exception($"Character not found.");
            }

            var skill = await _dataContext.Skills
                .SingleOrDefaultAsync(skill => skill.Id == newCharacterSkill.SkillId);

            if (skill is null)
            {
                throw new Exception($"Skill not found.");
            }

            character.Skills!.Add(skill);
            await _dataContext.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterResponseDto>(character);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> AddCharacterWeapon
    (AddCharacterWeaponRequestDto newCharacterWeapon)
    {
        var response = new ServiceResponse<GetCharacterResponseDto>();
        try
        {
            var character = await _dataContext.Characters
                .Include(character => character.Book)
                .Include(character => character.Skills)
                .Include(character => character.Weapons)
                .SingleOrDefaultAsync(character =>
                    character.Id == newCharacterWeapon.CharacterId && character.User!.Id == GetUserId());

            if (character is null)
            {
                throw new Exception($"Character not found.");
            }

            var weapon = await _dataContext.Weapons
                .SingleOrDefaultAsync(skill => skill.Id == newCharacterWeapon.WeaponId);

            if (weapon is null)
            {
                throw new Exception($"Weapon not found.");
            }

            character.Weapons!.Add(weapon);
            await _dataContext.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterResponseDto>(character);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }


    public int GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new InvalidOperationException("User ID claim is missing or invalid.");
        }

        return userId;
    }

    public string GetUserRole()
    {
        var userRole = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role);

        if (string.IsNullOrEmpty(userRole))
        {
            throw new InvalidOperationException("User Role claim is missing or invalid.");
        }

        return userRole;
    }

    public bool IsUserAdmin() => GetUserRole() == "Admin";
}
