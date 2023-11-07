using BeatData.CodingTest;
using BeatData.CodingTest.Controllers;
using BeatData.CodingTest.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BeatData.CodingTest.UnitTest

{
    [TestClass]
    public class GetTasksByUserTest
    {
        private ITaskService TaskService;
        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor httpContextAccessor;
        private ILogger<TaskService> logger;

        [TestMethod]
        public void CountValues()
        {
            TaskService = new TaskService(httpContextAccessor, webHostEnvironment, logger);
            var tasks = this.TaskService.GetTasksByUser(100, 15, 3);
            if(tasks.Result?.Count != 5) {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void NullCheckUser()
        {
            TaskService = new TaskService(httpContextAccessor, webHostEnvironment, logger);
            var tasks = this.TaskService.GetTasksByUser(100, 15, -5);
            if (tasks.Result?.Count == 0)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CheckTitle()
        {
            TaskService = new TaskService(httpContextAccessor, webHostEnvironment, logger);
            var tasks = this.TaskService.GetTasksByUser(1, 14, 3);
            if (tasks.Result?.SingleOrDefault().Title != "voluptatum omnis minima qui occaecati provident nulla voluptatem ratione")
            {
                Assert.Fail();
            }
        }
    }
}