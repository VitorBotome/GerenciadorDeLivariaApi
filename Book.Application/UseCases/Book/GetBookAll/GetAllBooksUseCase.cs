using Book.Application.Data;
using Book.Application.Entities;

namespace Book.Application.UseCases.Book.GetBookAll;

public class GetAllBooksUseCase
{
    public List<BookModel> Execute()
    {
        var books = BookRepository.GetAll();

        return books;
    }
}
