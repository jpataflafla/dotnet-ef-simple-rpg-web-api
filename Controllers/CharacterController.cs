using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_ef_simple_rpg_web_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private static Character fighter = new Character();

    [HttpGet]
    public ActionResult<Character> Get()
    {
        return Ok(fighter);
    }
}