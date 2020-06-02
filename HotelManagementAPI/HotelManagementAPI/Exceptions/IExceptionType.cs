using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelManagementAPI.Exceptions
{
    public interface IExceptionType
    {
        void SetExceptionResult(ApiError error, ExceptionContext context);
    }
}
