namespace HotelManagementAPI.Logging
{
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public ApiError(string message)
        {
            this.Message = message;
            IsError = true;
        }
    }
}
