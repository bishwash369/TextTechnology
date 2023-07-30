namespace DapperTextTech.Models
{

    public class ZeroToNine
    {
        public string? Track { get; set; }
        public string? Artist { get; set; }
        public string? Uri { get; set; }
        public string? Danceability { get; set; }
        public string? Energy { get; set; }
        public string? Key { get; set; }
        public string? Loudness { get; set; }
        public string? Mode { get; set; }
        public string? Speechiness { get; set; }
        public string? Acousticness { get; set; }
        public string? Instrumentalness { get; set; }
        public string? Liveliness { get; set; }
        public string? Valence { get; set; }
        public string? Tempo { get; set; }
        public string? Duration_ms { get; set; }
        public string? Time_signature { get; set; }
        public string? Chorus_hit { get; set; }
        public string? Sections { get; set; }
        public string? Target { get; set; }

    }

    public class FrequentArtists
    {
        public string? Artist { get; set; }
        public string? Frequency { get; set; }
    }

    public class FrequentGenre
    {
        public string? Genre { get; set; }
        public string? Frequency { get; set; }
    }

    public class Danceability
    {
        public string? AverageDanceability { get; set; }
    }

    public class Speechiness
    {
        public string? AverageSpeechiness { get; set; }
    }

    public class Duration
    {
        public string? AverageDuration { get; set; }
    }

    public class Valence
    {
        public string? AverageValence { get; set; }
    }
}
