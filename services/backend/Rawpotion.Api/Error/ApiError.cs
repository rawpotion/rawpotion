using System.Text.Json.Serialization;

namespace Rawpotion.Api.Error
{
    public class ApiError
    {
        public int StatusCode { get; }
        public string StatusDescription { get; }
        public object? Value { get; }

        public ApiError(int statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public ApiError(int statusCode, string statusDescription, object value) : this(statusCode, statusDescription)
        {
            Value = value;
        }
    }
}