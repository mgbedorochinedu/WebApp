using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Data;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_web_api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(IMapper mapper, DataContext db, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        //Get claims user by Username
        private string GetUsername() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        //Get claims user by Id
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(CreateCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Users = await _db.Users.FirstOrDefaultAsync(u => u.Id.Equals(GetUserId()));
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
            serviceResponse.Data = (_db.Characters.Where(c => c.Users.Id.Equals(GetUserId())).Select(c =>  _mapper.Map<GetCharacterDto>(c))).ToList();
            serviceResponse.Message = "Added Successfully";
            return serviceResponse;
        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _db.Characters.Where(x => x.Users.Username == GetUsername()).ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Message = "Successfully fetched all characters";
            return serviceResponse;

        }


        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character dbCharacter = await _db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.Users.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            serviceResponse.Message = "Successfully fetch single character";
            return serviceResponse;

        }


        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _db.Characters.Include(u => u.Users).
                    FirstOrDefaultAsync(c => c.Id == updateCharacter.Id && c.Users.Id.Equals(GetUserId()));


                if (character.Users.Id.Equals(GetUserId()))
                {
                    character.Name = updateCharacter.Name;
                    character.Class = updateCharacter.Class;
                    character.Defense = updateCharacter.Defense;
                    character.HitPoints = updateCharacter.HitPoints;
                    character.Intelligence = updateCharacter.Intelligence;
                    character.Strength = updateCharacter.Strength;

                    _db.Characters.Update(character);
                    await _db.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
                    serviceResponse.Message = "Character updated successfully";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                    return serviceResponse;
                }
              

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
                Character character = await _db.Characters.FirstOrDefaultAsync(c => c.Id == id && c.Users.Id.Equals(GetUserId()));

                if (character != null)
                {
                    _db.Characters.Remove(character);
                    await _db.SaveChangesAsync();
                    serviceResponse.Data = _db.Characters.Where(u => u.Users.Id == GetUserId()).Select(x => _mapper.Map<GetCharacterDto>(x)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                }

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
