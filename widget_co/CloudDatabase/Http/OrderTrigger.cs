using DAL;
using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Repository.Interface;
using Service.Interface;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CloudDatabase.Http
{
    public class OrderTrigger
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        public OrderTrigger(ILogger logger, IOrderService orderService, DataBaseContext dataBaseContext)
        {
            _logger = logger;
            _orderService = orderService;
        }
        [FunctionName("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "order/")] HttpRequestData req) 
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.GetAllAsync);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
        
        [FunctionName("GetOrderById")]
        public async Task<IActionResult> GetById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/order/{id}")] HttpRequestData req, string id) 
        {
            OrderDTO orderDTO = new();
            orderDTO.OrderId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.GetByIdAsync(orderDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
        
        [FunctionName("AddOrder")]
        public async Task<IActionResult> AddOrder([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/order/{orderId}")] HttpRequestData req) 
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            OrderDTO orderDTO = JsonConvert.DeserializeObject<OrderDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.CreateAsync(orderDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
        
        [FunctionName("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/order/{orderId}")] HttpRequestData req, string id) 
        {
            OrderDTO orderDTO = new();
            orderDTO.OrderId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.DeleteAsync(orderDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
        
        [FunctionName("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/order/{orderId}")] HttpRequestData req, string id) 
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            OrderDTO orderDTO = JsonConvert.DeserializeObject<OrderDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.UpdateAsync(orderDTO, id));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
        
        [FunctionName("UpdateOrderShipping")]
        public async Task<IActionResult> UpdateOrderShipping([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/order/{orderId}")] HttpRequestData req, DateTime dateTime ,string id) 
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_orderService.UpdateShippingAsync(dateTime, id));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }
    }
}
