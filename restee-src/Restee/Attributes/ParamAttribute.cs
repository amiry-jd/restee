using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class ParamAttribute : Attribute {

        protected ParamAttribute(ParameterKind parameterKind) {
            ParameterKind = parameterKind;
        }

        protected ParamAttribute(string name, ParameterKind parameterKind) {
            Name      = name;
            ParameterKind = parameterKind;
        }

        public string Name { get; }

        public ParameterKind ParameterKind { get; }

    }

}