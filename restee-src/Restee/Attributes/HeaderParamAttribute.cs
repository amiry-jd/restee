using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class HeaderParamAttribute : ParamAttribute {

        public HeaderParamAttribute() : base(ParameterKind.Header) { }

        public HeaderParamAttribute(string name) : base(name, ParameterKind.Header) { }

    }

}