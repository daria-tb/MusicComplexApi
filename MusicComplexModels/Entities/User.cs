namespace MusicComplexModels.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;

    public string? GoogleId { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }

    public UserProfile? Profile { get; set; }
    public List<Playlist> Playlists { get; set; } = new();
}