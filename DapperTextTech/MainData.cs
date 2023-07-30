using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

public class MyController : ControllerBase
{
    private readonly string _connectionString;

    public MyController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("MyConnection");
    }

    [HttpGet]
    public IActionResult Get()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var result = connection.Query("SELECT * FROM dbo.['2000_2009$']");
            return Ok(result);
        }
    }
}