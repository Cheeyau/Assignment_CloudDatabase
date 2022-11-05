using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CloudDatabase.Http
{
    public class OrderTrigger
    {
        [FunctionName("GetAllOrders")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "order/{id}")] HttpRequest req, ILogger log)
        {
            
            try
            {
                
            }
            catch
            {
                return new NotFoundResult();
            }
        }
    }
}
