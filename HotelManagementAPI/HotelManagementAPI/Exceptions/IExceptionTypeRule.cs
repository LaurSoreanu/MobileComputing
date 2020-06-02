using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace HotelManagementAPI.Exceptions
{
    public interface IExceptionTypeRule
    {
        bool IsMatch(Exception exception);
        void SetExceptionResult(ApiError error, ExceptionContext context);
    }
}
