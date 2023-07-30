using Dapper;
using DapperTextTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TextTech.Models;

namespace DapperTextTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextTechController : ControllerBase
    {
        private readonly string _connectionString;

        public TextTechController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet("[action]")]
        public IActionResult GetTable2000To2009Data()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<ZeroToNine>("SELECT top 100 * FROM dbo.['2000_2009$']");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetTable2010To2019Data()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<ZeroToNine>("SELECT top 100 * FROM dbo.['2010_2019$']");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetTableTop2KData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Top2kModel>("SELECT top 100 * FROM dbo.top2k_2000_2019$");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetTop10ArtistData()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FrequentArtists>("WITH filtered_tracks AS (\r\n    SELECT song, artist\r\n    FROM dbo.top2k_2000_2019$\r\n    WHERE song IN (\r\n        SELECT track\r\n        FROM dbo.['2000_2009$']\r\n        WHERE target = 1\r\n    )\r\n)\r\nSELECT top 10 artist, COUNT(*) AS frequency\r\nFROM filtered_tracks\r\nGROUP BY artist\r\nORDER BY frequency DESC;");
                return Ok(result);
            }
        }


        [HttpGet("[action]")]
        public IActionResult GetMostFrequentGenre()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FrequentGenre>("WITH filtered_tracks AS (\r\n    SELECT song, genre\r\n    FROM dbo.top2k_2000_2019$\r\n    WHERE song IN (\r\n        SELECT track\r\n        FROM dbo.['2000_2009$']\r\n        WHERE target = 1\r\n    )\r\n)\r\nSELECT top 10 genre, COUNT(*) AS frequency\r\nFROM filtered_tracks\r\nGROUP BY genre\r\nORDER BY frequency DESC;");
                return Ok(result);
            } 
        }

        [HttpGet("[action]")]
        public IActionResult GetTop10FrequentArtistsWithFilteredTracks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FrequentArtists>("WITH filtered_tracks AS (\r\n    SELECT song, artist\r\n    FROM dbo.top2k_2000_2019$\r\n    WHERE song IN (\r\n        SELECT track\r\n        FROM dbo.['2000_2009$']\r\n        WHERE target = 1\r\n    )\r\n)\r\nSELECT top 10 artist, COUNT(*) AS frequency\r\nFROM filtered_tracks\r\nGROUP BY artist\r\nORDER BY frequency DESC;");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetTop10MostFrequentCombinations()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FrequentCombinations>("WITH filtered_tracks AS (\r\n    SELECT t2k.*\r\n    FROM dbo.top2k_2000_2019$ AS t2k\r\n    WHERE t2k.song IN (\r\n        SELECT t1.track\r\n        FROM dbo.['2000_2009$'] AS t1\r\n        WHERE t1.target = 1\r\n        UNION\r\n        SELECT t1.track\r\n        FROM dbo.['2010_2019$'] AS t1\r\n        WHERE t1.target = 1\r\n    )\r\n)\r\nSELECT top 10 \"energy\", \"danceability\", \"loudness\", \"speechiness\", \"acousticness\", \"instrumentalness\",\r\n       \"liveness\", \"valence\", \"tempo\", \"duration_ms\", \"key\"\r\nFROM filtered_tracks\r\nGROUP BY \"energy\", \"danceability\", \"loudness\", \"speechiness\", \"acousticness\", \"instrumentalness\",\r\n         \"liveness\", \"valence\", \"tempo\", \"duration_ms\", \"key\"\r\nORDER BY COUNT(*) DESC;");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAverageDanceability()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Danceability>("SELECT AVG(t.danceability) AS AverageDanceability\r\nFROM dbo.top2k_2000_2019$ t\r\nWHERE t.song IN (\r\n    SELECT track FROM dbo.['2000_2009$'] WHERE \"target\"=1\r\n);");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAverageSpeechiness()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Speechiness>("SELECT AVG(t.speechiness) AS AverageSpeechiness\r\nFROM dbo.top2k_2000_2019$ t\r\nWHERE t.song IN (\r\n    SELECT track FROM dbo.['2000_2009$'] WHERE \"target\"=1\r\n);");
                return Ok(result);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetAverageDuration()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Duration>("SELECT AVG(t.duration_ms) AS AverageDuration\r\nFROM dbo.top2k_2000_2019$ t\r\nWHERE t.song IN (\r\n    SELECT track FROM dbo.['2000_2009$'] WHERE \"target\"=1\r\n    UNION\r\n    SELECT track FROM dbo.['2010_2019$'] WHERE \"target\"=1\r\n);");
                return Ok(result);
            }
        }


        [HttpGet("[action]")]
        public IActionResult GetAverageValence()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Valence>("SELECT AVG(t.valence) AS AverageValence\r\nFROM dbo.top2k_2000_2019$ t\r\nWHERE t.song IN (\r\n    SELECT track FROM dbo.['2000_2009$'] WHERE \"target\"=1\r\n);");
                return Ok(result);
            }
        }

    }
}