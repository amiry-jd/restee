using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class HeaderParamAttribute : Attribute {

        public string Name { get; }

        public HeaderParamAttribute() {

        }

        public HeaderParamAttribute(string name) {
            Name = name;
        }

    }

}