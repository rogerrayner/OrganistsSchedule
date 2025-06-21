using Microsoft.AspNetCore.Http;
using OrganistsSchedule.Domain.Exceptions;
using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var response = new ResponseError(
                ex.Message,
                ex.ErrorCode,
                ex.Details,
                ex.StackTraceInfo ?? ex.StackTrace
            );
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            var response = new ResponseError(
                ex.Message,
                null,
                null,
                ex.StackTrace
            );
            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ResponseError(
                "Erro interno do servidor",
                null,
                ex.Message,
                ex.StackTrace
            );
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}