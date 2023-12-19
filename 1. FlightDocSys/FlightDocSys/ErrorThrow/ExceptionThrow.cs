namespace FlightDocSys.ErrorThrow
{
    public class ExceptionThrow: Exception
    {
        public int StatusCode { get; set; }
        public string Value { get; set; }

        public ExceptionThrow(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.Value = message;
        }
    }
}
