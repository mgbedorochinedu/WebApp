using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Fight;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackerResultDto>> WeaponAttack(WeaponAttackDto request);

        Task<ServiceResponse<AttackerResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponse<FightResultLogDto>> Fight(FightRequestDto request);
        Task<ServiceResponse<List<HighScoreDto>>> GetHighScore();
    }
}
