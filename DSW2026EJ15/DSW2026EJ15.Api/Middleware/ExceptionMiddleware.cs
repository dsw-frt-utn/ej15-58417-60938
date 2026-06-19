using System.Net;
using DSW2026EJ15.Domain.Exceptions;

namespace DSW2026EJ15.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)  //se le agregga este metodo para que pueda ser invocado
    { //logica que queremos que se aplique 
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e); 
        }
    }

    public async Task HandleExceptionAsync(HttpContext context,Exception e)
    {
        HttpStatusCode status = HttpStatusCode.InternalServerError;
        string mensagge = "Error inesperado";
        if (e is ValidationException )
        {
            context.Response.StatusCode= StatusCodes.Status400BadRequest; //devuelve codigo de error 400
            context.Response.WriteAsync(e.Message); //le agrega un mensaje

        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError; //devuelve codigo de error 500
            context.Response.WriteAsync(e.Message); //le agrega un mensaje
        }
        
    }
}