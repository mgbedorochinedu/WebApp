using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Chinedu"}

        };
        public async Task<ServiceResponse<Character>> AddCharacters(Character newCharacter)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            characters.Add(newCharacter);
            //serviceResponse.Data = characters;
            serviceResponse.Message = "Added Successfully";
            return serviceResponse;
        }
        //public async Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter)
        //{
        //    ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
        //    characters.Add(newCharacter);
        //    serviceResponse.Data = characters;
        //    return serviceResponse;
        //}


        public async Task<ServiceResponse<List<Character>>> GetAllCharacter()
        {
            ServiceResponse<List<Character>> serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            serviceResponse.Message = "Successfully fetched all characters";
            return serviceResponse;

        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
             serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);
             return serviceResponse;

        }

  
    }
}
