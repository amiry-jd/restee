using System.Net.Http;

namespace Restee.Attributes {

    public class GetAttribute : HttpMethodAttribute {

        public GetAttribute():base(HttpMethod.Get) { }

        public GetAttribute(string path) : base(path, HttpMethod.Get) { }

    }


}