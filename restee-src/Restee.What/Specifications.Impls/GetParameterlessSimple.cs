using System;
using System.Net.Http;
using System.Threading.Tasks;

using Restee.Meta;

namespace Restee.What.Specifications.Impls {

    public class GetParameterlessSimple : IGetParameterlessSimple {

        private readonly IRequestHandler _requestHandler;
        private readonly IRouteProvider _routeProvider;
        private readonly IObjectFactory _objectFactory;

        public GetParameterlessSimple(
            IRequestHandler requestHandler,
            IRouteProvider routeProvider,
            IObjectFactory objectFactory) {
            _requestHandler = requestHandler;
            _routeProvider = routeProvider;
            _objectFactory = objectFactory;
        }


        public Task<ResponseModel> Get() {
            
            OperationMeta meta = null; // this will get value through code-generation 
            
            var httpMethod = meta.HttpMethod;
            var deserializer = _objectFactory.Get<IDeserializer>(meta.DeserializerType);
            var uri = _routeProvider.GetUri(meta);
            var request = new HttpRequestMessage(httpMethod, uri);
            var result = _requestHandler.HandleAsync<ResponseModel>(request, deserializer);
            return result; 
        }

    }

}