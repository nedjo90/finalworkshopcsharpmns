using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace backend.Exceptions;

public static class ExceptionMiddleware
{
       public static void UseExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                IExceptionHandlerFeature? contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    if (contextFeature.Error is MultipleException)
                    {
                        MultipleException exception = (MultipleException)contextFeature.Error;
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            BadRequestMultipleException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        MultipleErrorDetails details = new MultipleErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message 
                        };
                        if (exception.DictionaryOfErrors != null)
                            details.DictionaryOfErrors = exception.DictionaryOfErrors; 
                        if (exception.ListOfErrors != null)
                            details.ListOfErrors = exception.ListOfErrors;
                        await context.Response.WriteAsync(
                        details.ToString()
                            );
                    }
                    else
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        await context.Response.WriteAsync(
                            new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message
                            }.ToString());    
                    }
                    
                }
            });
        });
    }
}