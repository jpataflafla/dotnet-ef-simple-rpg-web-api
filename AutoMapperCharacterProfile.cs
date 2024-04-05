using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Dtos.Book;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Dtos.Skill;
using dotnet_ef_simple_rpg_web_api.Dtos.Weapon;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Character, GetCharacterResponseDto>();
        CreateMap<AddCharacterRequestDto, Character>();
        CreateMap<Book, GetBookResponseDto>();
        CreateMap<Skill, GetSkillResponseDto>();
        CreateMap<Skill, GetSkillWithIdResponseDto>();
        CreateMap<Weapon, GetWeaponResponseDto>();
        CreateMap<Weapon, GetWeaponWithIdResponseDto>();
        CreateMap<Character, GetHighScoreResponseDto>();
    }
}
