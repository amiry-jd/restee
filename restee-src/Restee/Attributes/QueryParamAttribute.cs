using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class QueryParamAttribute : ParamAttribute {

        public QueryParamAttribute() : base(ParameterKind.Query) { }

        public QueryParamAttribute(string name) : base(name, ParameterKind.Query) { }

    }

}