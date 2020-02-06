using System.Threading.Tasks;

namespace Restee.What.Specifications {

    public interface IGetMethodSamples {

        Task<ResponseModel> GetWithoutAttribute();

        [Get]
        Task<ResponseModel> GetWithoutPath();

        [Get("some/path")]
        Task<ResponseModel> GetWithPath();

        [Header("","")]
        Task<ResponseModel> GetWithHeaderWithoutValue();

        [Header("", "")]
        Task<ResponseModel> GetWithHeaderWithValue();

        [Header("", "")]
        [Header("", "")]
        Task<ResponseModel> GetWithMultipleHeadersWithValues();

        [Deserializer(typeof(object))]
        Task<ResponseModel> GetWithDefaultDeserializer();

        [Deserializer(typeof(object))]
        Task<ResponseModel> GetWithCustomDeserializer();
    }

}