using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class HeaderFactorAttribute : FactorAttribute {

        public HeaderFactorAttribute() : base(FactorKind.Header) { }

        public HeaderFactorAttribute(string name) : base(name, FactorKind.Header) { }

    }

}