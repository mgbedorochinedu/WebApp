using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Data;
using dotnet_web_api.Dtos.Fight;
using dotnet_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Services.FightService
{
    public class FightService : IFightService
    {
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public FightService(DataContext db, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<ServiceResponse<AttackerResultDto>> WeaponAttack(WeaponAttackDto request)
        {
            ServiceResponse<AttackerResultDto> response = new ServiceResponse<AttackerResultDto>();
            try
            {
                Character attacker = await _db.Characters.Include(w => w.Weapon)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);

                Character opponent = await _db.Characters.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                var damage = DoWeaponAttack(attacker, opponent);
                if (opponent.HitPoints <= 0)
                    response.Message = $"{opponent.Name} has been defeated!";

                _db.Characters.Update(opponent);
                await _db.SaveChangesAsync();

                response.Data = new AttackerResultDto
                {
                    AttackerName = attacker.Name,
                    AttackerHitPoint = attacker.HitPoints,
                    OpponentName = opponent.Name,
                    OpponentHitPoint = opponent.HitPoints,
                    Damage = damage
                };


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }


            return response;
        }

        private static int DoWeaponAttack(Character attacker, Character opponent)
        {
            int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0)
                opponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<AttackerResultDto>> SkillAttack(SkillAttackDto request)
        {
            ServiceResponse<AttackerResultDto> response = new ServiceResponse<AttackerResultDto>();
            try
            {
                Character attacker = await _db.Characters.Include(cs => cs.CharacterSkills).ThenInclude(s => s.Skill)
                    .FirstOrDefaultAsync(c => c.Id == request.AttackerId);

                Character opponent = await _db.Characters.FirstOrDefaultAsync(c => c.Id == request.OpponentId);

                CharacterSkill characterSkill =
                    attacker.CharacterSkills.FirstOrDefault(cs => cs.Skill.Id == request.SkillId);

                if (characterSkill == null)
                {
                    response.Success = false;
                    response.Message = $"{attacker.Name} doesn't know that skill.";
                }

                var damage = DoSkillAttack(characterSkill, attacker, opponent);
                if (opponent.HitPoints <= 0)
                    response.Message = $"{opponent.Name} has been defeated!";

                _db.Characters.Update(opponent);
                await _db.SaveChangesAsync();

                response.Data = new AttackerResultDto
                {
                    AttackerName = attacker.Name,
                    AttackerHitPoint = attacker.HitPoints,
                    OpponentName = opponent.Name,
                    OpponentHitPoint = opponent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private static int DoSkillAttack(CharacterSkill characterSkill, Character attacker, Character opponent)
        {
            int damage = characterSkill.Skill.Damage + (new Random().Next(attacker.Intelligence));
            damage -= new Random().Next(opponent.Defense);
            if (damage > 0)
                opponent.HitPoints -= damage;
            return damage;
        }

        public async Task<ServiceResponse<FightResultLogDto>> Fight(FightRequestDto request)
        {
            ServiceResponse<FightResultLogDto> response = new ServiceResponse<FightResultLogDto>
            {
                Data = new FightResultLogDto()
            };
            try
            {
                List<Character> characters = await _db.Characters.Include(w => w.Weapon)
                    .Include(cs => cs.CharacterSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Where(c => request.CharacterIds.Contains(c.Id)).ToListAsync();


                bool defeated = false;
                while (!defeated)
                {
                    foreach (Character attacker in characters)
                    {
                        List<Character> opponents = characters.Where(c => c.Id != attacker.Id).ToList();
                        Character opponent = opponents[new Random().Next(opponents.Count)];

                        int damage = 0;
                        string attackUsed = string.Empty;

                        bool useWeapon = new Random().Next(2) == 0;
                        if (useWeapon)
                        {
                            attackUsed = attacker.Weapon.Name;
                            damage = DoWeaponAttack(attacker, opponent);

                        }
                        else
                        {
                            int randomSkill = new Random().Next(attacker.CharacterSkills.Count);
                            attackUsed = attacker.CharacterSkills[randomSkill].Skill.Name;
                            damage = DoSkillAttack(attacker.CharacterSkills[randomSkill], attacker, opponent);
                        }
                        response.Data.Log.Add($"{attacker.Name} attacks {opponent.Name} using {attackUsed} with {(damage >= 0 ? damage : 0)} damage.");

                        if (opponent.HitPoints <= 0)
                        {
                            defeated = true;
                            attacker.Victories++;
                            opponent.Defeats++;
                            response.Data.Log.Add($"{opponent.Name} has been defeated!");
                            response.Data.Log.Add($"{attacker.Name} wins with {attacker.HitPoints} HP left!");
                            break;
                        }
                    }
                }
                characters.ForEach(c =>
                {
                    c.Fights++;
                    c.HitPoints = 100;
                });
                _db.Characters.UpdateRange(characters);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<HighScoreDto>>> GetHighScore()
        {
           
            List<Character> characters = await _db.Characters.Where(c => c.Fights > 0)
                .OrderByDescending(c => c.Victories)
                .ThenBy(c => c.Defeats).ToListAsync();

            //ServiceResponse<List<HighScoreDto>> response = new ServiceResponse<List<HighScoreDto>>();         //May as well use commented out approach 
            // response.Data = characters.Select(c => _mapper.Map<HighScoreDto>(c)).ToList();

            var response = new ServiceResponse<List<HighScoreDto>>
            {
                Data = characters.Select(c => _mapper.Map<HighScoreDto>(c)).ToList()
            };

            return response;
        }
    }
}
