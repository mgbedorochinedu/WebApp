using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_web_api.Dtos.Character;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Chinedu"}

        };
        public async Task<ServiceResponse<GetCharacterDto>> AddCharacters(CreateCharacterDto newCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters);
            //serviceResponse.Data = characters;
            serviceResponse.Message = "Added Successfully";
            return serviceResponse;
        }


        //public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacters(Character newCharacter)
        //{
        //    ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        //    characters.Add(newCharacter);
        //    serviceResponse.Data = characters;
        //    return serviceResponse;
        //}


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            serviceResponse.Message = "Successfully fetched all characters";
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;

        }


        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defense = updateCharacter.Defense;
                character.HitPoints = updateCharacter.HitPoints;
                character.Intelligence = updateCharacter.Intelligence;
                character.Strength = updateCharacter.Strength;

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found";
            }

           

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = characters.FirstOrDefault(c => c.Id == id);

                characters.Remove(character);

                serviceResponse.Data = (characters.Select(x => _mapper.Map<GetCharacterDto>(x))).ToList();
            }
            catch (Exception e) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Character not found";
            }



            return serviceResponse;

        }
    }
}
