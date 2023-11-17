﻿namespace HR_Management_WebAPI.Infrastructure.Swagger
{
    public class SwaggerLanguageHeader : IOperationFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public SwaggerLanguageHeader(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                Description = "Supported languages",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Enum = (_serviceProvider
                            .GetService(typeof(IOptions<RequestLocalizationOptions>)) as IOptions<RequestLocalizationOptions>)?
                        .Value?
                        .SupportedCultures?.Select(c => new OpenApiString(c.TwoLetterISOLanguageName)).ToList<IOpenApiAny>(),
                }
            });
        }
    }
}