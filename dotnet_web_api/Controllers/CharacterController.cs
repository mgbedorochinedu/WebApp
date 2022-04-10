using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Models;
using dotnet_web_api.Services.CharacterService;

namespace dotnet_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCharacter()
        {
           return Ok(await _characterService.GetAllCharacter());

        }
        [HttpPost]
        public async Task<IActionResult> AddCharacter(Character newCharacter)
        {
             return Ok(await _characterService.AddCharacters(newCharacter));
       

        }

    }
}
