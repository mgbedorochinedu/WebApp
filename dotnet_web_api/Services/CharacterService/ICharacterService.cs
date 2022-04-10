using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_web_api.Models;

namespace dotnet_web_api.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacter();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        //Task<ServiceResponse<List<Character>>> AddCharacters(Character newCharacter);
        Task<ServiceResponse<Character>> AddCharacters(Character newCharacter);
    }
}
