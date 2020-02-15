using System;

namespace Restee {

    [AttributeUsage(AttributeTargets.Interface )]
    public class ResteeAttribute : Attribute {

        public string BaseUrl { get; }

        public ResteeAttribute() {

        }

        public ResteeAttribute(string baseUrl) {
            BaseUrl = baseUrl;
        }

    }

}