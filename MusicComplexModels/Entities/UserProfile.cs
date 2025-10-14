
namespace MusicComplexModels.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
}
