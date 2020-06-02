using HotelManagementAPI.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementAPI.Exceptions
{
    public class ExceptionType : IExceptionType
    {
        private readonly List<IExceptionTypeRule> _exceptionTypeRules;

        public ExceptionType()
        {
            _exceptionTypeRules = new List<IExceptionTypeRule>
            {
               new ExceptionGeneral(),
               new ExxceptionCustomMessage()
            };
        }
        public void SetExceptionResult(ApiError error, ExceptionContext context)
        {
            if (_exceptionTypeRules.Any())
            {
                var exceptionType = _exceptionTypeRules.FirstOrDefault(c => c.IsMatch(context.Exception));
                exceptionType?.SetExceptionResult(error, context);
            }
        }
    }
}
