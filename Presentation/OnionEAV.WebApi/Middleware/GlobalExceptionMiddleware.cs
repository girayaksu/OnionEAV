using OnionEAV.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace OnionEAV.WebApi.Middleware
{

    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Bir hata oluştu: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            var statusCode = HttpStatusCode.InternalServerError;
            var message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.";
            var errors = new List<string>();

            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;

                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = validationException.Message;
                    errors = validationException.Errors;
                    break;

                case BusinessException businessException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = businessException.Message;
                    break;
            }

            var response = new
            {
                StatusCode = (int)statusCode,
                Message = message,
                Errors = errors.Count > 0 ? errors : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}


