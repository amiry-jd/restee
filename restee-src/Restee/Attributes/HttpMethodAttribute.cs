using System;
using System.Net.Http;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class HttpMethodAttribute : Attribute {

        public string Path { get; }
        
        public HttpMethod HttpMethod { get; }

        protected HttpMethodAttribute(HttpMethod httpMethod) {
            HttpMethod = httpMethod;
        }

        protected HttpMethodAttribute(string path, HttpMethod httpMethod) {
            Path       = path;
            HttpMethod = httpMethod;
        }

    }

}