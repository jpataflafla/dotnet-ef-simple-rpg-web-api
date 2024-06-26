using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[Authorize(Roles = "Player,Admin")]
[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        this._characterService = characterService;
    }

    //[AllowAnonymous]
    [HttpGet("GetAll")]
    public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> GetAllCharacters()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetSingleCharacter(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(AddCharacterRequestDto newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<Character>>> UpdateCharacter(UpdateCharacterRequestDto updateCharacter)
    {
        var response = await _characterService.UpdateCharacter(updateCharacter);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ServiceResponse<Character>>>> DeleteCharacter(int id)
    {
        var response = await _characterService.DeleteCharacter(id);
        if (response.Data is null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpPost("Skill")]
    public async Task<ActionResult<ServiceResponse<AddCharacterRequestDto>>> AddCharacterSkill(
        AddCharacterSkillRequestDto newCharacterSkill)
    {
        return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ServiceResponse<AddCharacterRequestDto>>> AddCharacterWeapon(
        AddCharacterWeaponRequestDto newCharacterWeapon)
    {
        return Ok(await _characterService.AddCharacterWeapon(newCharacterWeapon));
    }
}
