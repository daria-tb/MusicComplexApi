
namespace MusicComplexModels.Entities;

public class Artist
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Album> Albums { get; set; } = new();
}
