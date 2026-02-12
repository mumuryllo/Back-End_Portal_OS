using PortalOS.Exceptions;
using System.Net;
using System.Text.Json;

namespace PortalOS.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException ex)
            {
                await HandleException(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (UnauthorizedException ex)
            {
                await HandleException(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (ValidationExceptionCustom ex)
            {
                await HandleException(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (ConflictException ex)
            {
                await HandleException(context, HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleException(context, HttpStatusCode.InternalServerError,
                    ex.Message);
            }
        }

        private static async Task HandleException(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                error = message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
