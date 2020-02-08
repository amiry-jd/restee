using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class QueryParamAttribute : ParamAttribute {

        public QueryParamAttribute() : base(ParamType.Query) { }

        public QueryParamAttribute(string name) : base(name, ParamType.Query) { }

    }

}