using System;
using System.Net.Http;
using System.Threading.Tasks;

using Restee.Meta;

namespace Restee {

    public interface IObjectFactory {

        T Get<T>(Type typeKey);

    }
    
    public interface IRequestHandler{

        Task<TModel> HandleAsync<TModel>(HttpRequestMessage request, IDeserializer deserializer);

    }
    
    public interface IRouteProvider{

        Uri GetUri(OperationMeta meta);

    }

}