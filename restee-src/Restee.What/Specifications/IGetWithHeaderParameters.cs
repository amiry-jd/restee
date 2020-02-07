using System.Threading.Tasks;
using Restee.Attributes;

namespace Restee.What.Specifications
{
    public interface IGetWithHeaderParameters
    {
        [Header("X-Name", "Hasan")]
        Task<ResponseModel> AnnotatedHeader();

        Task<ResponseModel> SimpleHeader([HeaderParam]string name);

        Task<ResponseModel> AnnotatedHeaderParam([HeaderParam("X-Name")]string name);

        [Header("X-Name", "Hasan")]
        Task<ResponseModel> AnnotatedAndHeaderParam([HeaderParam("X-Famil")] string famil);

        [Header("X-Name", "Hasan")]
        Task<ResponseModel> MultipleValueParam([HeaderParam("X-Name")]string name);
    }
}