using System.Threading.Tasks;

namespace Restee.What.Specifications {

    [RestEra("https://api.domain.com")]
    public interface IGetParameterlessSimple {

        Task<ResponseModel> Get();

    }

}