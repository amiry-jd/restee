using System.Threading.Tasks;
using Restee.Attributes;

namespace Restee.What.Specifications
{
    public interface IGetWithHeaderParameters
    {
        [Header("X-Name", "Hasan")]
        Task<ResponseModel> AnnotatedHeader();

        Task<ResponseModel> SimpleHeader([HeaderFactor]string name);

        Task<ResponseModel> AnnotatedHeaderParam([HeaderFactor("X-Name")]string name);

        [Header("X-Name", "Hasan")]
        Task<ResponseModel> AnnotatedAndHeaderParam([HeaderFactor("X-Famil")] string famil);

        [Header("X-Name", "Hasan")]
        Task<ResponseModel> MultipleValueParam([HeaderFactor("X-Name")]string name);
    }
}