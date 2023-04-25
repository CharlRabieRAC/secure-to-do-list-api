using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using secure_to_do_list_api.Models;
using secure_to_do_list_api.Queries;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace secure_to_do_list_api.API
{
    public static class ToDoFunction
    {
        [FunctionName("ToDoList")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status408RequestTimeout)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[OpenApiOperation("GetPaymentAccounts", Summary = "Gets the member's payment accounts", Visibility = OpenApiVisibilityType.Important)]
        //[OpenApiResponseWithBody(HttpStatusCode.OK, MediaTypeNames.Application.Json, typeof(PaymentAccountsResponse), Summary = "Payment Accounts")
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            List<ToDoItem> responseMessage = null;
            switch (req.Method)
            {
                case "GET":
                    responseMessage = new GetToDoList().Handle("");
                    break;

                case "POST":
                    log.LogInformation("C# HTTP trigger function processed a request.");

                    var item = JsonConvert.DeserializeObject<ToDoItem>(await req.ReadAsStringAsync());

                    responseMessage = new GetToDoList().Handle("");
                    responseMessage.Add(item);

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