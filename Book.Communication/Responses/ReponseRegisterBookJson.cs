using Book.Communication.Enums;

namespace Book.Communication.Responses;

public class ReponseRegisterBookJson
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = "Desconhecido";
    public BookGenreEnum Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
