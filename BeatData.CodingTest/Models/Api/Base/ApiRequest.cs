namespace BeatData.CodingTest.Models.Api.Base;

public class ApiRequest<T>
{
    public T? Data { get; set; }

    public ApiRequest(T? data)
    {
        this.Data = data;
    }
}