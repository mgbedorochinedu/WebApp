using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Models;
using dotnet_web_api.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("get-character-by-id/{id}")]
        public async Task<IActionResult> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));

        }
        [HttpGet("get-all-character")]
        public async Task<IActionResult> GetAllCharacter()
        {
            return Ok(await _characterService.GetAllCharacter());
        }
        [HttpPost("add-character")]
        public async Task<IActionResult> AddCharacter(CreateCharacterDto newCharacter)
        {
             return Ok(await _characterService.AddCharacters(newCharacter));

        }

        [HttpPut("update-character")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("delete-character/{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

    }
}
