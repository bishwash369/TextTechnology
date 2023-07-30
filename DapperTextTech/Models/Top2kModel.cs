namespace TextTech.Models
{
    public class Top2kModel
    {
        public string? Artist { get; set; }
        public string? Song { get; set; }
        public string? Duration_ms { get; set; }
        public string? Explicit { get; set; }
        public string?  Year { get; set; }
        public string? Popularity { get; set; }
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
        public string? Genre { get; set; }

    }


    public class FrequentCombinations
    {
        public string? Duration_ms { get; set; }
        public string? Danceability { get; set; }
        public string? Energy { get; set; }
        public string? Key { get; set; }
        public string? Loudness { get; set; }
        public string? Speechiness { get; set; }
        public string? Acousticness { get; set; }
        public string? Instrumentalness { get; set; }
        public string? Valence { get; set; }
        public string? Tempo { get; set; }

    }
}
