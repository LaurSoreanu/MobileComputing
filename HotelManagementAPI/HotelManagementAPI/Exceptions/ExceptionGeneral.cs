using HotelManagement.Common;
using HotelManagement.Common.Exceptions;
using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace HotelManagementAPI.Exceptions
{
    public class ExceptionGeneral : IExceptionTypeRule
    {
        public bool IsMatch(Exception exception)
        {
            var locationException = exception as ApiMessageException;
            return locationException == null;
        }

        public void SetExceptionResult(ApiError error, ExceptionContext context)
        {
            error.Message = Constants.General.ERROR_INTERNAL_SERVER;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(error);
        }
    }
}
