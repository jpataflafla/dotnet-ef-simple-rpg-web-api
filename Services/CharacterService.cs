using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> characters = new List<Character>{
        new Character(),
        new Character{Id = 1, Name="John"},
    };

    public List<Character> AddCharacter(Character newCharacter)
    {

        return characters;
    }
    public List<Character> GetAllCharacters()
    {
        return characters;
    }

    public Character GetCharacterById(int id)
    {
        var character = characters.SingleOrDefault(c => c.Id == id);
        if (character is not null)
        {
            return character;
        }
        throw new Exception($"Character with Id:{id} not found.");
    }
}
