using System.Threading.Tasks;

namespace Restee.What.Specifications {

    public interface IGetWithQueryParameters {

        [Get("api/v1/some/{id}/{name}")]
        Task<ResponseModel> GetSimple(int                 id, string                       name);
        
        [Get("api/v1/some/{id}/{_name}")]
        Task<ResponseModel> GetAnnotated([QueryParam] int id, [QueryParam("_name")] string hasan);
        
        [Get("api/v1/some/{id}/{_name}")]
        Task<ResponseModel> GetMixed(int                  id, [QueryParam]int age, [QueryParam("_name")] string name);

    }

}