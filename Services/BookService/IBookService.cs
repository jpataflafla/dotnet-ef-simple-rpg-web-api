using dotnet_ef_simple_rpg_web_api.Dtos.Book;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Models;

namespace dotnet_ef_simple_rpg_web_api.Services.BookService;

public interface IBookService
{
    Task<ServiceResponse<GetCharacterResponseDto>> AddBook(AddBookDto newBook);


}