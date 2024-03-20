using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.CharacterService;

public interface ICharacterService
{
    List<Character> GetAllCharacters();

    Character GetCharacterById(int id);

    List<Character> AddCharacter(Character newCharacter);
}
