using System;
using System.Net;

namespace Pokemon.API.Services
{
    public class ApiCallFailedException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public ApiCallFailedException(HttpStatusCode statusCode)
            : base($"{(int)statusCode} - {statusCode}")
        {
            HttpStatusCode = statusCode;
        }
    }
}
