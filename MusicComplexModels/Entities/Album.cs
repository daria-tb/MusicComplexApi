
namespace MusicComplexModels.Entities;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; }
    public List<Song> Songs { get; set; } = new();
}
