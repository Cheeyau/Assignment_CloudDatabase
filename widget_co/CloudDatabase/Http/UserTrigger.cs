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
    public class UserTrigger
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public UserTrigger(ILogger logger, IUserService userService, DataBaseContext dataBaseContext)
        {
            _logger = logger;
            _userService = userService;
        }
        [FunctionName("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user/")] HttpRequestData req)
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_userService.GetAllAsync);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> GetById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/user/{id}")] HttpRequestData req, string id)
        {
            UserDTO userDTO = new();
            userDTO.UserId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_userService.GetByIdAsync(userDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("AddUser")]
        public async Task<IActionResult> AddUser([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/user/{userId}")] HttpRequestData req)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            UserDTO userDTO = JsonConvert.DeserializeObject<UserDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_userService.CreateAsync(userDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/user/{userId}")] HttpRequestData req, string id)
        {
            UserDTO userDTO = new();
            userDTO.UserId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_userService.DeleteAsync(userDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/user/{userId}")] HttpRequestData req, string id)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            UserDTO userDTO = JsonConvert.DeserializeObject<UserDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_userService.UpdateAsync(userDTO, id));
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
