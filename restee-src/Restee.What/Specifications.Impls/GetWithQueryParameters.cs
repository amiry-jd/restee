using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restee.What.Specifications.Impls {

    public class GetWithQueryParameters:IGetWithQueryParameters {

        private readonly IDeserializer _deserializer;

        public GetWithQueryParameters(IDeserializer deserializer) {
            _deserializer = deserializer;
        }


        public async Task<ResponseModel> GetSimple(int id, string name) {
            var baseUrl = "http://api.domain.com";
            var path = "api/v1/some/{id}/{name}";

            path = path.Replace("{id}", id.ToString())
                       .Replace("{name}", name);

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> GetAnnotated(int id, string name)
        {
            var queryParamName = "_name";
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some/{{id}}/{{{queryParamName}}}";
            

            path = path.Replace("{id}", id.ToString())
                .Replace($"{{{queryParamName}}}", name);

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

        public async Task<ResponseModel> GetMixed(int id, int age, string name) {
            var queryParamName = "_name";
            var baseUrl = "http://api.domain.com";
            var path = $"api/v1/some/{{id}}/{{{queryParamName}}}?/age={{age}}";
            

            path = path.Replace("{id}", id.ToString())
                .Replace($"{{{queryParamName}}}", name)
                .Replace("{age}",age.ToString());

            var uri = new Uri(new Uri(baseUrl), path);

            var httpMethod = HttpMethod.Get;
            var request    = new HttpRequestMessage(httpMethod, uri);
            var client     = new HttpClient();
            var response   = await client.SendAsync(request);
            var result     = _deserializer.DeserializeAsync(response);

            return result;
        }

    }

}