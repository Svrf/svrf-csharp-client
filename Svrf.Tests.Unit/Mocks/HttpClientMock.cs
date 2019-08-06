using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using Svrf.Models.Http;

namespace Svrf.Tests.Unit.Mocks
{
    internal static class HttpClientMock
    {
        internal static MockHttpMessageHandler MockHttpMessageHandler = new MockHttpMessageHandler();
        private const string BaseRequestUrl = "https://api.svrf.com/*";
        internal static object Headers;
        internal static Uri ActualRequestUrl;
        
        private static MockedRequest CreateMockedAddressRequest()
        {
           return MockHttpMessageHandler.When(BaseRequestUrl);
        }

        internal static MockedRequest GetMockRequest_WithSuccess()
        {
            return CreateMockedAddressRequest().Respond(req =>
            {
                ActualRequestUrl = req.RequestUri;
                Headers = req.Headers;

                if (req.Method == HttpMethod.Get)
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(ResponseMocks.SingleMediaResponse)),
                    };
                }

                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(ResponseMocks.AuthResponse)),
                };
            });
        }

        internal static MockedRequest GetMockRequest_WithException(HttpStatusCode httpStatusCode)
        {
            return CreateMockedAddressRequest().Respond(req =>
                new HttpResponseMessage
                {
                    StatusCode = httpStatusCode,
                    Content = new StringContent(GetErrorMessage()),
                }
            );
        }

        private static string GetErrorMessage()
        {
            var error = new ErrorResponse
            {
                Message = "Some Error",
            };

            return JsonConvert.SerializeObject(error);
        }
    }
}
