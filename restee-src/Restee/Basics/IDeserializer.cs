using System.Net.Http;
using System.Threading.Tasks;

namespace Restee {

    public interface IDeserializer {

        Task<T> DeserializeAsync<T>(HttpResponseMessage response);

    }

}