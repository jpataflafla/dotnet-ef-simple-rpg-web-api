using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.User;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public UserService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetUserInfoResponseDto>>> GetAllUsers()
    {
        var response = new ServiceResponse<List<GetUserInfoResponseDto>>();
        try
        {
            var users = await _dataContext.Users
                .Select(user => _mapper.Map<GetUserInfoResponseDto>(user)).ToListAsync();

            if (users is null || users.Count == 0)
            {
                throw new Exception("No users found.");
            }

            response.Data = users;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }

        return response;
    }

}