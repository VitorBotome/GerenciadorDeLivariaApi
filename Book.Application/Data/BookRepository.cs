using Book.Application.Entities;

namespace Book.Application.Data;

public class BookRepository
{
    private static List<BookModel> _books = new();

    public static void Add(BookModel book)
    {
        _books.Add(book);
    }
    public static List<BookModel> GetAllBook()
    {
        return _books;
    }

    public static BookModel? GetBookById(Guid id)
    {
        return _books.Find(book => book.Id == id);
    }

    public static void UpdateBook()
    {

    }

    public static void DeleteBook(BookModel book)
    {
        _books.Remove(book);
    }
}
