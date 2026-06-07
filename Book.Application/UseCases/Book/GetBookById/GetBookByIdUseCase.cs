using Book.Application.Data;
using Book.Application.Entities;

namespace Book.Application.UseCases.Book.GetBookById;

public class GetBookByIdUseCase
{
    public BookModel Execute(Guid id)
    {
        var book = BookRepository.GetBookById(id);

        return book;
    }
}
