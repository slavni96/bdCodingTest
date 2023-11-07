using System.Net.Http.Headers;
using System.Text.Json;
using BeatData.CodingTest.Models.Api.Commons;

namespace BeatData.CodingTest.Services;

public interface ITaskService
{
    Task<List<Models.Api.Commons.Task>?> GetTasks(int? limit, int? offset);

    Task<List<Models.Api.Commons.Task>?> GetTasksByUser(int? limit, int? offset, int userId);
}

public class TaskService : BaseService, ITaskService
{
    private readonly ILogger<TaskService> Logger;

    public TaskService(
        IHttpContextAccessor httpContextAccessor,
        IWebHostEnvironment webHostEnvironment,
        ILogger<TaskService> logger
    ) : base(httpContextAccessor, webHostEnvironment)
    {
        Logger = logger;
    }

    private HttpClient GetHttpClient(string @base = "https://jsonplaceholder.typicode.com")
    {
        var httpClient = new HttpClient { BaseAddress = new Uri(@base) };

        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return httpClient;
    }

    private async Task<List<User>?> GetUsersData()
    {
        try
        {
            var users = new List<User>();

            using (var httpClient = this.GetHttpClient())
            {
                var response = httpClient
                    .GetAsync("/users")
                    .Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    users = JsonSerializer.Deserialize<List<User>>(responseContent);
                }
            }

            return users;
        }
        catch (Exception exception)
        {
            Logger.LogError($"[TaskService][GetUsersData] Exception: {exception.Message}");

            throw;
        }
    }

    private async Task<List<Models.Api.Commons.Task>?> GetTasksData()
    {
        try
        {
            var tasks = new List<Models.Api.Commons.Task>();

            using (var httpClient = this.GetHttpClient())
            {
                var response = httpClient
                    .GetAsync("/todos")
                    .Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    tasks = JsonSerializer.Deserialize<List<Models.Api.Commons.Task>>(responseContent);
                }
            }

            return tasks;
        }
        catch (Exception exception)
        {
            Logger.LogError($"[TaskService][GetTasksData] Exception: {exception.Message}");

            throw;
        }
    }

    //TODO: Refactor this method
    //private List<Models.Api.Commons.Task>? GetTasksWithRelations(List<Models.Api.Commons.Task>? tasks, List<User>? users)
    //{
    //    foreach (var task in tasks)
    //    {
    //        var apiUsers = this.GetUsersData().Result;

    //        foreach (var user in apiUsers)
    //        {
    //            if (user.ID == task.UserID)
    //            {
    //                task.User = user;
    //            }
    //        }
    //    }

    //    return tasks;
    //}

    private List<Models.Api.Commons.Task>? GetTasksWithRelations(List<Models.Api.Commons.Task>? tasks, List<User>? users)
    {
        var apiUsers = this.GetUsersData().Result;
        var filteredTasks = tasks?.Select(x => { x.User = apiUsers?.SingleOrDefault(t => t.ID == x.UserID); return x; }).ToList();
        return filteredTasks;
    }

    public async Task<List<Models.Api.Commons.Task>?> GetFilteredTasks(int? limit, int? offset, int? userId = null)
    {
        var tasks = (await this.GetTasksData())?.AsQueryable();
        var users = await this.GetUsersData();

        if (userId != null && userId > 0)
        {
            tasks = tasks?.Where(x => x.UserID == userId.Value);
        }

        if (offset != null)
        {
            tasks = tasks?.Skip(offset.Value);
        }

        if (limit != null && limit > 0)
        {
            tasks = tasks?.Take(limit.Value);
        }

        return this.GetTasksWithRelations(tasks?.ToList(), users);
    }

    public async Task<List<Models.Api.Commons.Task>?> GetTasks(int? limit, int? offset)
    {
        return await this.GetFilteredTasks(limit, offset);
    }

    //Corretto il return Type del metodo
    public async Task<List<Models.Api.Commons.Task>?> GetTasksByUser(int? limit, int? offset, int userId)
    {
        return await this.GetFilteredTasks(limit, offset, userId);
    }
}