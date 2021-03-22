using System.Net;

namespace Rawpotion.Api.Error
{
    public class InternalServerError : ApiError
    {
        public InternalServerError() : base(500, HttpStatusCode.InternalServerError.ToString())
        {
        }

        public InternalServerError(object value) : base(500, HttpStatusCode.InternalServerError.ToString(), value)
        {
        }
    }
}