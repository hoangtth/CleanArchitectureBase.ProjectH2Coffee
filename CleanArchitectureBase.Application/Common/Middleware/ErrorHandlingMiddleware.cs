using CleanArchitectureBase.Application.Common.Exceptions;
using CleanArchitectureBase.Domain.Helpers;
using CleanArchitectureBase.Domain.ValueObject;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureBase.Application.Common.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private ILogger<ErrorHandlingMiddleware> _log;

        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = 500;
            var message = "Đã xảy ra lỗi trong quá trình xử lý";
            var code = ECode.InternalServerError;
            switch (ex)
            {
                case UnauthorizedAccessException _:
                    statusCode = (int)HttpStatusCode.Unauthorized;
                    code = ECode.Unauthorized;
                    message = ex.Message;
                    break;
                case HttpStatusException exception:
                    statusCode = exception.StatusCode;
                    message = exception.Message;
                    code = exception.Code;
                    break;
                case FluentValidation.ValidationException _:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    code = ECode.BadRequest;
                    message = ex.Message;
                    break;
            }

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = statusCode;
            _log.LogError(ex, ex.Message);
            var err = JsonConvert.SerializeObject(new ErrorModel()
            {
                ErrorCode = code,
                Message = message
            });
            return context.Response.WriteAsync(err);
        }
    }
}
