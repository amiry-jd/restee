using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Restee.What.Specifications.Impls {

    public class GetParameterlessSimple : IGetParameterlessSimple {

        private readonly IDeserializer _deserializer;

        public GetParameterlessSimple(IDeserializer deserializer) {
            _deserializer = deserializer;
        }


        public async Task<ResponseModel> Get() {
            var httpMethod = HttpMethod.Get;
            var url = "someUrl";
            var uri = new Uri(url);
            var request = new HttpRequestMessage(httpMethod, uri);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var result = _deserializer.DeserializeAsync(response);
            return result;
        }

    }

}