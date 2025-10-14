
namespace MusicComplexModels.Entities;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int AlbumId { get; set; }
    public Album? Album { get; set; }
    public string ArtistName { get; set; } = null!;
}
