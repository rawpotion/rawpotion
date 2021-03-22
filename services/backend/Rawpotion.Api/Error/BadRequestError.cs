using System.Net;

namespace Rawpotion.Api.Error
{
    public class BadRequestError : ApiError
    {
        public BadRequestError() : base(400, HttpStatusCode.NotFound.ToString())
        {
        }
        
        public BadRequestError(object value) : base(400, HttpStatusCode.NotFound.ToString(), value)
        {
        }
    
        public BadRequestError(string message) : base(400, HttpStatusCode.NotFound.ToString(), new {Message = message})
        {
        }
    }
}