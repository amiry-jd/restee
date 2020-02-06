using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Interface|AttributeTargets.Method,AllowMultiple = true )]
    public class HeaderAttribute : Attribute {

        public string Name  { get; }
        public string Value { get; }

        public HeaderAttribute(string name, string value) {
            Name  = name;
            Value = value;
        }

    }

}