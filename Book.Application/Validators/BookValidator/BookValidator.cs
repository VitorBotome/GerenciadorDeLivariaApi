using Book.Communication.Enums;

namespace Book.Application.Validators.BookValidator;

public class BookValidator
{
    public static void ValidateGenre(BookGenreEnum genre)
    {
        if(!Enum.IsDefined(typeof(BookGenreEnum), genre))
        {
            throw new ArgumentException("Genero invalido.");
        }
    }
}
