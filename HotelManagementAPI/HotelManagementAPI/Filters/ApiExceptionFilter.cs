using HotelManagementAPI.Exceptions;
using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace HotelManagementAPI.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IExceptionType _exceptionType;

        public ApiExceptionFilter(IExceptionType exceptionType)
        {
            _exceptionType = exceptionType;
        }

        public override void OnException(ExceptionContext context)
        {
            var msg = context.Exception.GetBaseException().Message;
            string stack = context.Exception.StackTrace;
            var apiError = new ApiError(msg);
            apiError.Detail = stack;
            Log.Logger.Error(context.Exception, apiError.Message);
            _exceptionType.SetExceptionResult(apiError, context);
            base.OnException(context);
        }
    }
}
