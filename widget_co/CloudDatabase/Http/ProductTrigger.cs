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
    public class ProductTrigger
    {
        private readonly ILogger _logger;
        private readonly IProductService _productService;
        public ProductTrigger(ILogger logger, IProductService productService, DataBaseContext dataBaseContext)
        {
            _logger = logger;
            _productService = productService;
        }
        [FunctionName("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product/")] HttpRequestData req)
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_productService.GetAllAsync);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("GetProductById")]
        public async Task<IActionResult> GetById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/product/{id}")] HttpRequestData req, string id)
        {
            ProductDTO productDTO = new();
            productDTO.ProductId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_productService.GetByIdAsync(productDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("AddProduct")]
        public async Task<IActionResult> AddProduct([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/product/{productId}")] HttpRequestData req)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_productService.CreateAsync(productDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/product/{productId}")] HttpRequestData req, string id)
        {
            ProductDTO productDTO = new();
            productDTO.ProductId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_productService.DeleteAsync(productDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/product/{productId}")] HttpRequestData req, string id)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            ProductDTO productDTO = JsonConvert.DeserializeObject<ProductDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_productService.UpdateAsync(productDTO, id));
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
