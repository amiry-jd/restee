using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restee.What.Specifications.Impls
{
    public class GetWithHeaderParameters : IGetWithHeaderParameters
    {
        private readonly IDeserializer _deserializer;

        public GetWithHeaderParameters(IDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        public async Task<ResponseModel> AnnotatedHeader()
        {
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some";
            var headerKey = "X-Name";
            var headerValue = "Hasan";

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Add(headerKey,headerValue);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> SimpleHeader(string name)
        {
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some";
            var headerKey = "name";
            var headerValue = name;

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Add(headerKey,headerValue);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> AnnotatedHeaderParam(string name)
        {
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some";
            var headerKey = "X-Name";

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Add(headerKey,name);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> AnnotatedAndHeaderParam(string famil)
        {
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some";
            var attributeHeaderKey = "X-Name";
            var attributeHeaderValue = "Hasan";
            var inputHeaderParamKey = "X-Famil";
            

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Add(attributeHeaderKey,attributeHeaderValue);
            request.Headers.Add(inputHeaderParamKey,famil);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> MultipleValueParam(string name)
        {
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some";
            var attributeHeaderKey = "X-Name";
            var attributeHeaderValue = "Hasan";
            var headerValues = new string[] {attributeHeaderValue, name};


            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            request.Headers.Add(attributeHeaderKey,headerValues);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }
    }
}