
using MusicComplexModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace MusicComplexRepositories;

public static class DataSeeder
{
    public static async Task SeedAsync(MusicDbContext context)
    {
        if (await context.Artists.AnyAsync()) return; // already seeded

        var users = new List<User>
        {
            new User { Username = "andriy", Profile = new UserProfile { FullName = "Андрій Коваль", Age = 22 } },
            new User { Username = "olena", Profile = new UserProfile { FullName = "Олена Шевченко", Age = 25 } },
            new User { Username = "maksym", Profile = new UserProfile { FullName = "Максим Петренко", Age = 28 } },
            new User { Username = "daria", Profile = new UserProfile { FullName = "Дарія Ткаченко", Age = 24 } },
            new User { Username = "oleksii", Profile = new UserProfile { FullName = "Олексій Іваненко", Age = 30 } },
        };

        await context.Users.AddRangeAsync(users);

        var artists = new List<Artist>
        {
            new Artist { Name = "Океан Ельзи" },
            new Artist { Name = "Тіна Кароль" },
            new Artist { Name = "Друга Ріка" },
            new Artist { Name = "Антитіла" },
            new Artist { Name = "KAZKA" }
        };
        await context.Artists.AddRangeAsync(artists);
        await context.SaveChangesAsync();

        var albums = new List<Album>
        {
            new Album { Title = "Янанебібув", ArtistId = artists[0].Id },
            new Album { Title = "Красиво", ArtistId = artists[1].Id },
            new Album { Title = "Денніч", ArtistId = artists[2].Id }
        };
        await context.Albums.AddRangeAsync(albums);
        await context.SaveChangesAsync();

        var songs = new List<Song>
        {
            new Song { Title = "Без бою", AlbumId = albums[0].Id, ArtistName = artists[0].Name },
            new Song { Title = "Красиво", AlbumId = albums[1].Id, ArtistName = artists[1].Name },
            new Song { Title = "Так мало тут тебе", AlbumId = albums[2].Id, ArtistName = artists[2].Name }
        };
        await context.Songs.AddRangeAsync(songs);
        await context.SaveChangesAsync();

        var playlists = new List<Playlist>
        {
            new Playlist { Title = "Ранковий настрій", UserId = users[0].Id },
            new Playlist { Title = "Тренування", UserId = users[1].Id }
        };
        await context.Playlists.AddRangeAsync(playlists);
        await context.SaveChangesAsync();

        var playlistSongs = new List<PlaylistSong>
        {
            new PlaylistSong { PlaylistId = playlists[0].Id, SongId = songs[0].Id },
            new PlaylistSong { PlaylistId = playlists[1].Id, SongId = songs[1].Id }
        };
        await context.PlaylistSongs.AddRangeAsync(playlistSongs);
        await context.SaveChangesAsync();
    }
}
