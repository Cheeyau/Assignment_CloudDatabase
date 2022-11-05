using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace CloudDatabase
{
    public class OpenApiConfig : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = "1.0.0",
            Title = "Widget & Co service app backend",
            Description = "The backend API for the application for the Widget & Co.",
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
    }
}
