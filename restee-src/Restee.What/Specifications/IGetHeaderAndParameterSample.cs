using System.Threading.Tasks;

namespace Restee.What.Specifications {

    [RestEra("https://api.domain.com/api/v1")]
    [Header("X-H1","val1")]
    [Header("X-H2", "val2")]
    public interface IGetHeaderAndParameterSample {

        [Get("some/{id}/get/{_name}/list")]
        [Header("X-H2","val2-2")]
        Task<ResponseModel> Get(
            [HeaderParam("X-H2") ] string value3,
            
            );

    }

}