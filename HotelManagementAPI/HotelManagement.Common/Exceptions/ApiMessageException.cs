using System;

namespace HotelManagement.Common.Exceptions
{
    public class ApiMessageException : Exception
    {
        public Enums.ApiMessageError ApiMessageError { get; set; }
        public ApiMessageException(string message) : base(message)
        {

        }

        public ApiMessageException(string message, Enums.ApiMessageError locationError) : base(message)
        {
            ApiMessageError = locationError;
        }
    }
}
