using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.Weapon;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto neWeaponDto);
    }
}
