using Domain.Exceptions;
using Shared.ErrorModels;

namespace OrderManagementSystem.API.CustomMiddlewares
{
    public class CustomExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _nextMiddleware;
        private readonly ILogger<CustomExceptionHandlingMiddleware> _logger;

        public CustomExceptionHandlingMiddleware(RequestDelegate nextMiddleware, ILogger<CustomExceptionHandlingMiddleware> logger)
        {
            _nextMiddleware = nextMiddleware;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _nextMiddleware.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Something went wrong");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var response = new ErrorToReturn()
            {
                ErrorMessage = ex.Message,
            };

            response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                BadRequestException badRequestException => GetBadRequestErrors(badRequestException, response),
                ArgumentNullException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            httpContext.Response.StatusCode = response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(response);
        }

        private int GetBadRequestErrors(BadRequestException badRequestException, ErrorToReturn response)
        {
            response.Errors = badRequestException.Errors;
            return StatusCodes.Status400BadRequest;
        }
    }
}
