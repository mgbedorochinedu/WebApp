﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Data;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;

        public CharacterService(IMapper mapper, DataContext db)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(CreateCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
            //serviceResponse.Data = (_db.Characters.Select(c =>  _mapper.Map<GetCharacterDto>(c))).ToList();
            serviceResponse.Message = "Added Successfully";
            return serviceResponse;
        }



        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter(int userId)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _db.Characters.Where(x => x.Users.Id == userId).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Message = "Successfully fetched all characters";
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character dbCharacter = await _db.Characters.FirstOrDefaultAsync(x => x.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            serviceResponse.Message = "Successfully fetch single character";
            return serviceResponse;

        }


        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _db.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);

                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defense = updateCharacter.Defense;
                character.HitPoints = updateCharacter.HitPoints;
                character.Intelligence = updateCharacter.Intelligence;
                character.Strength = updateCharacter.Strength;

                _db.Characters.Update(character);
                await _db.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

           

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await _db.Characters.FirstOrDefaultAsync(c => c.Id == id);

                _db.Characters.Remove(character);
                await _db.SaveChangesAsync();

                serviceResponse.Data = _db.Characters.Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
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
