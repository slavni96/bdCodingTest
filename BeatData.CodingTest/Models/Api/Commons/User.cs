using System.Text.Json.Serialization;

namespace BeatData.CodingTest.Models.Api.Commons;

public class User
{
    [JsonPropertyName("id")]
    public int? ID { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    public User()
    {

    }
}