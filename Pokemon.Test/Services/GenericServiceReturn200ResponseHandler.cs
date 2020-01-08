using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokemon.Test.Services
{
    public class GenericServiceReturn200ResponseHandler<T> : HttpMessageHandler
    {
        private readonly T _responseContent;
        public GenericServiceReturn200ResponseHandler(T responseContent)
        {
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var contentString = JsonConvert.SerializeObject(_responseContent);
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(contentString, Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        }
    }
}
