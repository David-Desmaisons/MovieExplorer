using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MovieExplorerApi.Site.Infra
{
    public static class ExceptionHandler
    {
        public static async Task Handle(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (exception == null)
            {
                return;
            }
            var model = new ProblemDetails
            {
                Detail = exception.Message
            };
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, model);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
