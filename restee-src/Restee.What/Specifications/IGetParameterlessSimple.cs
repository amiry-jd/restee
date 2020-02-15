using System.Threading.Tasks;

namespace Restee.What.Specifications {

    [Restee("https://api.domain.com")]
    public interface IGetParameterlessSimple {

        Task<ResponseModel> Get();

    }

}