using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.CharacterSkill;
using dotnet_web_api.Models;
using dotnet_web_api.Services.CharacterSkillService;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_web_api.Controllers
{
    [Authorize]
    [Route("api/character-skill")]
    [ApiController]
    public class CharacterSkillController : ControllerBase
    {
        private readonly ICharacterSkillService _characterSkillService;


        public CharacterSkillController(ICharacterSkillService characterSkillService)
        {
            _characterSkillService = characterSkillService;
        }

        [HttpPost("add-character-skill")]
        public async Task<IActionResult> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> response = await _characterSkillService.AddCharacterSkill(newCharacterSkill);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

    }
}
