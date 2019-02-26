using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using TakeRecipeEasily.Core.Exceptions;

namespace TakeRecipeEasily.Infrastructure.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (ServiceException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, TakeRecipeEasilyException ex)
        {
            var result = ToErrorsResult(ex);
            var resultJson = SerializeErrorsResult(result);

            context.Response.StatusCode = (int)GetReturnStatusCode(ex.ErrorType);
            await context.Response.WriteAsync(resultJson);
        }

        private static string SerializeErrorsResult(IErrorsResult info)
            => JsonConvert.SerializeObject(info, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

        private static IErrorsResult ToErrorsResult(TakeRecipeEasilyException ex)
            => new ErrorsResult
            {
                Errors = new[] { ex.ErrorCode }
            };

        private static HttpStatusCode GetReturnStatusCode(ErrorType type)
        {
            switch (type)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;

                case ErrorType.Forbidden:
                    return HttpStatusCode.Forbidden;

                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;

                case ErrorType.Error:
                    return HttpStatusCode.InternalServerError;

                case ErrorType.Conflict:
                    return HttpStatusCode.Conflict;

                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
