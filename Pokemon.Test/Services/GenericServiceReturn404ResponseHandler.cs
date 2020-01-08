﻿using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokemon.Test.Services
{
    public class GenericServiceReturn404ResponseHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
            return Task.FromResult(response);
        }
    }
}
