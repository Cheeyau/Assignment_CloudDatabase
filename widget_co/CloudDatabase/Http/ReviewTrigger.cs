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
    internal class ReviewTrigger
    {
        private readonly ILogger _logger;
        private readonly IReviewService _reviewService;
        public ReviewTrigger(ILogger logger, IReviewService reviewService, DataBaseContext dataBaseContext)
        {
            _logger = logger;
            _reviewService = reviewService;
        }
        [FunctionName("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "review/")] HttpRequestData req)
        {
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_reviewService.GetAllAsync);
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("GetReviewById")]
        public async Task<IActionResult> GetById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "/review/{id}")] HttpRequestData req, string id)
        {
            ReviewDTO reviewDTO = new();
            reviewDTO.ReviewId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_reviewService.GetByIdAsync(reviewDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("AddReview")]
        public async Task<IActionResult> AddReview([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "/review/{reviewId}")] HttpRequestData req)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            ReviewDTO reviewDTO = JsonConvert.DeserializeObject<ReviewDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_reviewService.CreateAsync(reviewDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("DeleteReview")]
        public async Task<IActionResult> DeleteReview([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/review/{reviewId}")] HttpRequestData req, string id)
        {
            ReviewDTO reviewDTO = new();
            reviewDTO.ReviewId = id;
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_reviewService.DeleteAsync(reviewDTO));
                response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                response.WriteString(ex.Message);
            }
            return (IActionResult)response;
        }

        [FunctionName("UpdateReview")]
        public async Task<IActionResult> UpdateReview([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "/review/{reviewId}")] HttpRequestData req, string id)
        {
            string request = await new StreamReader(req.Body).ReadToEndAsync();
            ReviewDTO reviewDTO = JsonConvert.DeserializeObject<ReviewDTO>(request);
            HttpResponseData response = req.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                await response.WriteAsJsonAsync(_reviewService.UpdateAsync(reviewDTO, id));
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
