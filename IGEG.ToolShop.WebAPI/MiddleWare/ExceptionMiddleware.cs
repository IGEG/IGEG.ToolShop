using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.WebAPI.MiddleWare.Models;
using System.Net;


namespace IGEG.ToolShop.WebAPI.MiddleWare
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomProblemDetails problem =new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetails()
                    {
                        Type = nameof(BadRequestException),
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Errors = badRequestException.ValidationErrorsList
                    };
                    break;
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetails()
                    {
                        Type = nameof(NotFoundException),
                        Title = NotFound.Message,
                        Status = (int)statusCode,
                        Detail = NotFound.InnerException?.Message,
                    };
                    break;
                default:
                    problem = new CustomProblemDetails()
                    {
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.StackTrace,
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
