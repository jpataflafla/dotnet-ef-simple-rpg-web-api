using dotnet_ef_simple_rpg_web_api.Dtos.Skill;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.SkillService;

public interface ISkillService
{
    Task<ServiceResponse<List<GetSkillWithIdDto>>> GetAllSkills();

    //Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto newSkill);
}
