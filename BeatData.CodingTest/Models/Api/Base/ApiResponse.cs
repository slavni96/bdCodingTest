namespace BeatData.CodingTest.Models.Api.Base;

public class ApiResponse<T>
{
    public string Status { get; set; }

    public string? Message { get; set; }

    public T? Data { get; set; }

    public ApiResponse(string status, string? message, T? data)
    {
        this.Status = status;
        this.Message = message;
        this.Data = data;
    }
}