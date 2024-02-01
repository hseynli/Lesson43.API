using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public record CreateGameDto([Required][StringLength(50)]string Name, [Required][StringLength(20)]string Genre, [Range(1, 100)]decimal Price, DateTime ReleaseDate, [Url]string ImageUri);
}
