using System.Net;

namespace Rawpotion.Api.Error
{
    public class NotFoundError : ApiError
    {
        public NotFoundError() : base(404, HttpStatusCode.NotFound.ToString())
        {
        }
    
        public NotFoundError(object value) : base(404, HttpStatusCode.NotFound.ToString(), value)
        {
        }

        public NotFoundError(string message) : base(404, HttpStatusCode.NotFound.ToString(), new {Message = message})
        {
        }
    }
}