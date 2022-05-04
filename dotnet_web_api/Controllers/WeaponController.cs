using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Dtos.Weapon;
using dotnet_web_api.Services.WeaponService;
using Microsoft.AspNetCore.Authorization;

namespace dotnet_web_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost("add-weapon")]
        public async Task<IActionResult> AddWeapon(AddWeaponDto newWeapon)
        {
            var result = await _weaponService.AddWeapon(newWeapon);

            return Ok(result);
        }
    }
}
