using System.Text.Json.Serialization;

namespace BeatData.CodingTest.Models.Api.Commons;

public class Task
{
    [JsonPropertyName("id")]
    public int? ID { get; set; }

    [JsonPropertyName("userId")]
    public int? UserID { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("completed")]
    public bool? Completed { get; set; }

    public User? User { get; set; }

    public Task()
    {

    }
}