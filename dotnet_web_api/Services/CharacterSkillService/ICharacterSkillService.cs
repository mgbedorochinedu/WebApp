using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.CharacterSkill;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {

        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);

    }
}
