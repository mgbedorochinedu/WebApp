﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Dtos.Weapon;
using dotnet_web_api.Models;

namespace dotnet_web_api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>().ReverseMap();
            CreateMap<CreateCharacterDto, Character>().ReverseMap();
            CreateMap<UpdateCharacterDto, Character>().ReverseMap();
            CreateMap<Weapon, GetWeaponDto>().ReverseMap();
            CreateMap<AddWeaponDto, Weapon>().ReverseMap();


        }
    }
}
