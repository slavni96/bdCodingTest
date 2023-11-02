namespace BeatData.CodingTest.Services;

public class BaseService
{
    private readonly IHttpContextAccessor HttpContextAccessor;

    private readonly IWebHostEnvironment WebHostEnvironment;

    public BaseService(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
    {
        this.HttpContextAccessor = httpContextAccessor;
        this.WebHostEnvironment = webHostEnvironment;
    }

    protected string GetContentRoot()
    {
        return this.WebHostEnvironment.ContentRootPath;
    }
}