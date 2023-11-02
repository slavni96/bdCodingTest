using BeatData.CodingTest.Models.Api.Base;
using BeatData.CodingTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeatData.CodingTest.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : BaseController
{
    private readonly ILogger<TaskController> Logger;

    private ITaskService TaskService;

    public TaskController(ILogger<TaskController> logger, ITaskService taskService)
    {
        this.Logger = logger;
        this.TaskService = taskService;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(ApiResponse<List<Models.Api.Commons.Task>?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTasks(
        [FromQuery(Name = "limit")] int? limit,
        [FromQuery(Name = "offset")] int? offset
    )
    {
        try
        {
            var data = await this.TaskService.GetTasks(limit, offset);

            return Ok(new ApiResponse<List<Models.Api.Commons.Task>?>(status: ApiStatus.API_STATUS_SUCCESS, message: null, data: data));
        }
        catch (Exception exception)
        {
            return InternalServerError(new ApiResponse<List<Models.Api.Commons.Task>?>(status: ApiStatus.API_STATUS_ERROR, message: exception.Message, data: null));
        }
    }

    [HttpGet("user")]
    [ProducesResponseType(typeof(ApiResponse<List<Models.Api.Commons.Task>?>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTasksByUser(
        [FromQuery(Name = "limit")] int? limit,
        [FromQuery(Name = "offset")] int? userId,
        [FromQuery(Name = "userId")] int userId
    )
    {
        try
        {
            var data = await this.TaskService.GetTasksByUser(limit, offset, userId);

            return Ok(new ApiResponse<List<Models.Api.Commons.Task>?>(status: ApiStatus.API_STATUS_SUCCESS, message: null, data: data));
        }
        catch (Exception exception)
        {
            return InternalServerError(new ApiResponse<List<Models.Api.Commons.Task>?>(status: ApiStatus.API_STATUS_ERROR, message: exception.Message, data: null));
        }
    }
}
