using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
    public class DeserializerAttribute : Attribute {

        public Type DeserializerType { get; }

        public DeserializerAttribute(Type deserializerType) {
            DeserializerType = deserializerType;
        }

    }

}