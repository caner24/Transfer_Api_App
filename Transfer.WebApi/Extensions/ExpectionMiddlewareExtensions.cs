using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using Transfer.Entity.ErrorModel;
using Transfer.Entity.Expections;

namespace Transfer.WebApi.Extensions
{
    public static class ExpectionMiddlewareExtensions
    {
        public static void ConfigureExpectionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundExpection => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                        Log.Error($"Something went wrong {contextFeature.Error}");

                        await context.Response.WriteAsync(new Errors { ErrorCode = context.Response.StatusCode, ErrorMessage = contextFeature.Error.Message }.ToString());
                    }
                });
            });
        }

    }
}
