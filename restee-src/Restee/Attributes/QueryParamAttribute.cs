using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter,AllowMultiple = false , Inherited = false )]
    public class QueryParamAttribute : Attribute {

        public string Name { get; }

        public QueryParamAttribute() {

        }

        public QueryParamAttribute(string name) {
            Name = name;
        }

    }

}