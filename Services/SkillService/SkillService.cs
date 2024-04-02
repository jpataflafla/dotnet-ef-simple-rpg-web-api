using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Skill;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Services.SkillService;

public class SkillService : ISkillService
{
    private readonly DataContext _dataContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public SkillService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _dataContext = dataContext;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetSkillWithIdDto>>> GetAllSkills()
    {
        var response = new ServiceResponse<List<GetSkillWithIdDto>>();
        try
        {
            var skills = await _dataContext.Skills
                .Select(skill => _mapper.Map<GetSkillWithIdDto>(skill)).ToListAsync();

            if (skills is null)
            {
                throw new Exception("No skills found");
            }
            response.Data = skills;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }
}
