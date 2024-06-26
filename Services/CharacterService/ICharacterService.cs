﻿using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.CharacterService;

public interface ICharacterService
{
    Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();

    Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);

    Task<Character> GetRawCharacterById(int id);

    Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter
    (AddCharacterRequestDto newCharacter);

    Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter
    (UpdateCharacterRequestDto updatedCharacter);

    Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id);
    Task<ServiceResponse<GetCharacterResponseDto>> AddCharacterSkill
    (AddCharacterSkillRequestDto newCharacterSkill);

    Task<ServiceResponse<GetCharacterResponseDto>> AddCharacterWeapon
    (AddCharacterWeaponRequestDto newCharacterWeapon);
    int GetUserId();
    string GetUserRole();
}
