using System;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MauiApp1.Components
{
    public record Track(string Name = "", bool IsFavorite = false)
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Ќазвание отсутствует";
        public string Description { get; set; } = "ќписание отсутствует";
        public string Image { get; set; } = "/images/MainTrackPhoto.svg";
        public bool Like { get; set; } = false;
        public bool Round { get; set; } = false;
    }

    public sealed class Playlist : List<Track>
    {
        public static readonly Playlist Empty = new();
    }

    public static class PlaylistFactory
    {
        private const string TrackData = "trackdata.json";

        public static Playlist CreatePlaylistFromFile()
        {
            var fullPathToFile = Path.Combine(FileSystem.Current.AppDataDirectory, TrackData);
            string json = "";

            if (File.Exists(fullPathToFile))
            {
                json = File.ReadAllText(fullPathToFile);
                return JsonSerializer.Deserialize<Playlist>(json) ?? Playlist.Empty;
            }

            var tracks = new Playlist
            {
                new Track
                {
                    Id = 1,
                    Title = "Anything Goes",
                    Description = "Updated Aug 31 Х Emma Chamberlain",
                    Image = "/images/cardlogo.svg",
                    Like = false
                },
                new Track
                {
                    Id = 2,
                    Title = "Ask Me Another",
                    Description = "Updated Aug 18 Х NPR Studios",
                    Image = "/images/cardlogo2.svg",
                    Like = false
                },
                new Track
                {
                    Id = 3,
                    Title = "Baking a Mystery",
                    Description = "Updated Aug 21Х Stephanie Soo",
                    Image = "/images/cardlogo3.svg",
                    Like = true
                },
                new Track
                {
                    Id = 4,
                    Title = "Extra Dynamic",
                    Description = "Updated Aug 10 Х ur mom ashley",
                    Image = "/images/cardlogo4.svg",
                    Like = false
                },
                new Track
                {
                    Id = 5,
                    Title = "Teenager Therapy",
                    Description = "Updated Aug 21Х iHeart Studios",
                    Image = "/images/cardlogo5.svg",
                    Like = false
                }
            };

            json = JsonConvert.SerializeObject(tracks, Formatting.Indented);

            File.WriteAllText(fullPathToFile, json);

            return JsonSerializer.Deserialize<Playlist>(File.ReadAllText(fullPathToFile)) ?? Playlist.Empty;
        }
    }
}
