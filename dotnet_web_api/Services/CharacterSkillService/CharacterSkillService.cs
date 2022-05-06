using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Data;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.CharacterSkill;
using dotnet_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Services.CharacterSkillService
{
    public class CharacterSkillService : ICharacterSkillService
    {
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CharacterSkillService(DataContext db, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        //Get claims user by Username
        private string GetUsername() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        //Get claims user by Id
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character dbCharacter = await _db.Characters.Include(w => w.Weapon)
                    .Include(cs => cs.CharacterSkills)
                    .ThenInclude(s => s.Skill)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterSkill.CharacterId && c.Users.Id == GetUserId());

                if (dbCharacter == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found";

                    return serviceResponse;
                }

                Skill skill = await _db.Skills.FirstOrDefaultAsync(s => s.Id == newCharacterSkill.SkillId);

                if (skill == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Skill not found.";

                    return serviceResponse;
                }
                //First Approach
                // CharacterSkill characterSkill = _mapper.Map<CharacterSkill>(newCharacterSkill);

                //Second Approach
                //CharacterSkill characterSkill = new CharacterSkill
                //{
                //    CharacterId = newCharacterSkill.CharacterId,
                //    SkillId = newCharacterSkill.SkillId
                //};

                //Third Approach
                CharacterSkill characterSkill = new CharacterSkill
                {
                    Character = dbCharacter,
                    Skill = skill
                };

                await _db.CharacterSkills.AddAsync(characterSkill);
                await _db.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
