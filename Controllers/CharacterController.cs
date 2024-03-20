using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        this._characterService = characterService;
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Character>> GetAllCharacters()
    {
        return Ok(_characterService.GetAllCharacters());
    }

    [HttpGet("{id}")]
    public ActionResult<Character> GetSingleCharacter(int id)
    {
        return Ok(_characterService.GetCharacterById(id));
    }

    [HttpPost]
    public ActionResult<List<Character>> AddCharacter(Character newCharacter)
    {
        return Ok(_characterService.AddCharacter(newCharacter));
    }
}
