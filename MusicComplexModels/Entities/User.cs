
namespace MusicComplexModels.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public UserProfile? Profile { get; set; }
    public List<Playlist> Playlists { get; set; } = new();
}
