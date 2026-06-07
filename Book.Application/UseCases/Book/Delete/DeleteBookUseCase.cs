using Book.Application.Data;

namespace Book.Application.UseCases.Book.Delete;

public class DeleteBookUseCase
{
    public void Execute(Guid id)
    {
        var book = BookRepository.GetBookById(id);

        if(book == null)
        {
            throw new ArgumentException("Livro nao encontrado");
        }

        BookRepository.DeleteBook(book);
    }
}
