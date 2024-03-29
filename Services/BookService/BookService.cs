using System.Security.Claims;
using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Book;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Services.BookService;

public class BookService : IBookService
{
    private readonly DataContext _dataContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public BookService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        _dataContext = dataContext;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> AddBook(AddBookDto newBook)
    {
        var response = new ServiceResponse<GetCharacterResponseDto>();
        try
        {
            var character = await _dataContext.Characters
            .SingleOrDefaultAsync(character =>
                character.Id == newBook.CharacterId && character.User!.Id == GetUserId());

            if (character is null)
            {
                throw new Exception($"Character not found.");
            }

            var book = new Book()
            {
                Name = newBook.Name,
                Wisdom = newBook.Wisdom,
                Character = character
            };

            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
            response.Data = _mapper.Map<GetCharacterResponseDto>(character);

        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    private int GetUserId()
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
        {
            throw new InvalidOperationException("User ID claim is missing or invalid.");
        }

        return userId;
    }
}