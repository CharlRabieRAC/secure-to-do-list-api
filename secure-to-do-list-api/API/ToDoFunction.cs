using LiteDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using secure_to_do_list_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace secure_to_do_list_api.API
{
    public static class ToDoFunction
    {
        [FunctionName("GetToDoList")]
        public static async Task<IActionResult> GetToDoList(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            using var db = new LiteDatabase(@"MyData.db");
            log.LogInformation("C# HTTP trigger function processed a request.");
            var todoData = db.GetCollection<ToDoItem>("ToDoItems");

            var item = JsonConvert.DeserializeObject<ToDoItem>(await req.ReadAsStringAsync());
            IEnumerable<ToDoItem> responseMessage = null;
            responseMessage = todoData.FindAll().ToList();

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("AddToDoItem")]
        public static async Task<IActionResult> AddToDoItem(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            using var db = new LiteDatabase(@"MyData.db");
            log.LogInformation("C# HTTP trigger function processed a request.");
            var todoData = db.GetCollection<ToDoItem>("ToDoItems");

            var item = JsonConvert.DeserializeObject<ToDoItem>(await req.ReadAsStringAsync());
            IEnumerable<ToDoItem> responseMessage = null;
            log.LogInformation("C# HTTP trigger function processed a request.");

            todoData.EnsureIndex(x => x.Id, true);

            todoData.Insert(item);

            responseMessage = todoData.FindAll().ToList();

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("DeleteTodoItem")]
        public static Task<IActionResult> DeleteTodo(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "DeleteTodoItem/{id}")] HttpRequest req, ILogger log, string id)
        {
            using var db = new LiteDatabase(@"MyData.db");
            IEnumerable<ToDoItem> responseMessage = null;
            log.LogInformation("C# HTTP trigger function processed a request.");
            var todoData = db.GetCollection<ToDoItem>("ToDoItems");
            todoData.DeleteMany(r => r.Id == id);
            responseMessage = todoData.FindAll().ToList();

            return Task.FromResult<IActionResult>(new OkObjectResult(responseMessage));
        }
    }
}