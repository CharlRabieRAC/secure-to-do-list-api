using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using secure_to_do_list_api.Models;
using secure_to_do_list_api.Queries;

namespace secure_to_do_list_api.API
{
    public static class ToDoFunction
    {
        [FunctionName("GetToDoList")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            ToDoList responseMessage = null;
            switch (req.Method)
            {
                case "GET":
                    responseMessage = new GetToDoList().Handle("");
                    break;
                case "POST":
                    throw new NotImplementedException();
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            return new OkObjectResult(responseMessage);
        }
    }
}
