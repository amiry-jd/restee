using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class ParamAttribute : Attribute {

        protected ParamAttribute(ParamType paramType) {
            ParamType = paramType;
        }

        protected ParamAttribute(string name, ParamType paramType) {
            Name      = name;
            ParamType = paramType;
        }

        public string Name { get; }

        public ParamType ParamType { get; }

    }

}