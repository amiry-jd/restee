using System;

namespace Restee.Attributes {

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public abstract class FactorAttribute : Attribute {

        protected FactorAttribute(FactorKind factorKind) {
            FactorKind = factorKind;
        }

        protected FactorAttribute(string name, FactorKind factorKind) {
            Name      = name;
            FactorKind = factorKind;
        }

        public string Name { get; }

        public FactorKind FactorKind { get; }

    }

}