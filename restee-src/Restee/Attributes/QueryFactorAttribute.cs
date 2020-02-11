using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class QueryFactorAttribute : FactorAttribute {

        public QueryFactorAttribute() : base(FactorKind.Query) { }

        public QueryFactorAttribute(string name) : base(name, FactorKind.Query) { }

    }

}