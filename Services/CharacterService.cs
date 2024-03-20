using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> s_characters = new List<Character>{
        new Character(),
        new Character{Id = 1, Name="John"},
    };

    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
        this._mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        var character = _mapper.Map<Character>(newCharacter);
        character.Id = s_characters.Max(c => c.Id) + 1;
        s_characters.Add(character);
        serviceResponse.Data = s_characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();

        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        serviceResponse.Data = s_characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
        var character = s_characters.SingleOrDefault(c => c.Id == id);
        serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);

        return serviceResponse;
    }
}
