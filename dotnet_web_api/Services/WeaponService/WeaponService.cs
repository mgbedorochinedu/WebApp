using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.Weapon;
using dotnet_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeaponService(DataContext db, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        //Get claims user by Username
        private string GetUsername() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        //Get claims user by Id
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));



        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto neWeaponDto)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character dbCharacter = await _db.Characters.FirstOrDefaultAsync(c => c.Id == neWeaponDto.CharacterId && c.Users.Id == GetUserId());

                if (dbCharacter == null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";

                    return response;
                }
                //Weapon weapon = new Weapon()
                //{
                //    Name = neWeaponDto.Name,
                //    Damage = neWeaponDto.Damage,
                //    Character = dbCharacter
                //};

                Weapon weapon = _mapper.Map<Weapon>(neWeaponDto);

                await _db.Weapons.AddAsync(weapon);
                await _db.SaveChangesAsync();

                response.Data = _mapper.Map<GetCharacterDto>(dbCharacter);

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.InnerException.Message;
            }

            return response;

        }
    }
}
