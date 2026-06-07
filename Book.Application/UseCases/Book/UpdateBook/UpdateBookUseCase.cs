using Book.Application.Data;
using Book.Communication.Requests;

namespace Book.Application.UseCases.Book.UpdateBook;

public class UpdateBookUseCase
{
    public void Execute(Guid id, RequestUpdateBookJson request)
    {
        var book = BookRepository.GetBookById(id);

        if (book == null)
        {
            throw new ArgumentException("Livro não encontrado.");
        }

        book.Title = request.Title;
        book.Author = request.Author = "Desconhecido";
        book.Genre = request.Genre;
        book.Price = request.Price;
        book.Stock = request.Stock;
        book.UpdatedAt = DateTime.UtcNow;

        BookRepository.UpdateBook();
    }
}
