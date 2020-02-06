using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restee.What.Specifications {

    public interface IGetParameterSamples {

        Task<ResponseModel> GetWithoutParameter();

        Task<ResponseModel> GetWithOneSimpleParam(int id);

        Task<ResponseModel> GetWithOneParamWithQueryAttribute([QueryParam] int id);

        Task<ResponseModel> GetWithOneParamWithNamedQueryAttribute([QueryParam("")] int id);

        Task<ResponseModel> GetWithParamsWithQueryAttribute([QueryParam] int id, [QueryParam] string name);

        Task<ResponseModel> GetWithParamsWithNamedQueryAttribute([QueryParam("")] int id, [QueryParam("")] string name);

        Task<ResponseModel> GetWithParamsWithNamedAndUnnamedQueryAttribute(int id, [QueryParam("")] string name);

        Task<ResponseModel> GetWithOneParamWithHeaderAttribute([HeaderParam] int id);

        Task<ResponseModel> GetWithOneParamWithNamedHeaderAttribute([HeaderParam("")] int id);

        Task<ResponseModel> GetWithParamsWithHeaderAttribute([HeaderParam] int id, [HeaderParam] string name);

        Task<ResponseModel> GetWithParamsWithNamedHeaderAttribute([HeaderParam("")] int id, [HeaderParam("")] string name);

        Task<ResponseModel> GetWithParamsWithNamedAndUnnamedHeaderAttribute(int id, [HeaderParam("")] string name);

        Task<ResponseModel> GetWithDictionaryAsHeader([HeaderParam] IDictionary<string, object> headers);

        Task<ResponseModel> GetWithKeyValuesAsHeader([HeaderParam] IEnumerable<KeyValuePair<string, object>> headers);

        Task<ResponseModel> GetWithDictionaryAsHeaderAndAttrHeader([HeaderParam] IDictionary<string, object> headers, [HeaderParam("")] string name);

        Task<ResponseModel> GetWithKeyValuesAsHeaderAndAttrHeader([HeaderParam] IEnumerable<KeyValuePair<string, object>> headers, [HeaderParam("")] string name);

        Task<ResponseModel> GetWithDictionaryAsParams([HeaderParam] IDictionary<string, object> parameters);

        Task<ResponseModel> GetWithKeyValuesAsParams([HeaderParam] IEnumerable<KeyValuePair<string, object>> parameters);
        
        Task<ResponseModel> GetWithDictionaryAsParamsAndAttrParam([HeaderParam] IDictionary<string, object> parameters, [HeaderParam("")] string name);

        Task<ResponseModel> GetWithKeyValuesAsParamsAndAttrParam([HeaderParam] IEnumerable<KeyValuePair<string, object>> parameters, [HeaderParam("")] string name);

    }

}