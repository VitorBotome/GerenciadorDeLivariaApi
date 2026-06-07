using Book.Application.Data;
using Book.Application.Entities;
using Book.Application.Validators.BookValidator;
using Book.Communication.Enums;
using Book.Communication.Requests;
using Book.Communication.Responses;

namespace Book.Application.UseCases.Book.RegisterBook;

public class CreateBookUseCase
{
    public ReponseRegisterBookJson Execute(RequestRegisterBookJson request)
    {

        if(request.Title == request.Author)
        {
            throw new ArgumentException("Titulo não pode ser igual ao autor.");
        }
        BookValidator.ValidateGenre(request.Genre);

        var book = new BookModel
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Author = request.Author = "Desconhecido",
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };
        BookRepository.Add(book);

        return new ReponseRegisterBookJson
        {
            Title = request.Title,
            Author = request.Author = "Desconhecido",
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock,
            CreatedAt = DateTime.UtcNow
        };
    }
}
