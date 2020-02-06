using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Interface )]
    public class RestEraAttribute : Attribute {

        public string BaseUrl { get; }

        public RestEraAttribute() {

        }

        public RestEraAttribute(string baseUrl) {
            BaseUrl = baseUrl;
        }

    }

}