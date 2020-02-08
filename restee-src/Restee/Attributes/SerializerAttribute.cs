using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Method)]
    public class SerializerAttribute : Attribute {

        public Type SerializerType { get; }

        public SerializerAttribute(Type serializerType) {
            SerializerType = serializerType;
        }

    }

}