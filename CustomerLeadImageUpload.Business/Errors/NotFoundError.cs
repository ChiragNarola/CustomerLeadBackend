using System.Net;

namespace CustomerLeadImageUpload.Business.Errors
{
    public class NotFoundError : Exception, IErrorWithHttpStatus
    {
        public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        public NotFoundError(string message) : base(message)
        {
        }
    }
}
