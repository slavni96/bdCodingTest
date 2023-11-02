using Microsoft.AspNetCore.Mvc;

namespace BeatData.CodingTest.Controllers;

public class BaseController : ControllerBase
{
    protected ObjectResult InternalServerError(dynamic? data = null)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, data);
    }
}