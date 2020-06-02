using HotelManagement.Common.Exceptions;
using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace HotelManagementAPI.Exceptions
{
    public class ExxceptionCustomMessage : IExceptionTypeRule
    {
        public bool IsMatch(Exception exception)
        {
            var customException = exception as ApiMessageException;
            return customException != null;
        }

        public void SetExceptionResult(ApiError error, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
            context.Result = new JsonResult(error);
        }
    }
}
