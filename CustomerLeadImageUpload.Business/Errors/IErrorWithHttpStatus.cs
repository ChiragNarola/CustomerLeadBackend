using System.Net;

namespace CustomerLeadImageUpload.Business.Errors
{
    public interface IErrorWithHttpStatus
    {
        HttpStatusCode StatusCode { get; }
    }
}
