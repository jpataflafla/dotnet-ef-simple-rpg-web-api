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
            var dbCharacters = await _dataContext.Characters
                .Where(character => character.User!.Id == GetUserId()).ToListAsync();
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
            var dbCharacter = await _dataContext.Characters
                .SingleOrDefaultAsync(character =>
                    character.Id == id && character.User!.Id == GetUserId());
            if (dbCharacter is null)
            {
                throw new Exception($"Character with Id:{id} was not found.");
            }

            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(dbCharacter);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
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

    private int GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new InvalidOperationException("User ID claim is missing or invalid.");
        }

        return userId;
    }
}
