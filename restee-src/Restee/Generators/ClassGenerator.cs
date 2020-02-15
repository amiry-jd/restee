using System;
using System.Reflection;
using System.Reflection.Emit;

using Restee.Meta;

namespace Restee.Generators {

    public class ModuleGenerator {

        public ModuleBuilder Generate() {
            var assembleName    = new AssemblyName("<>ResteeGeneratedAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assembleName, AssemblyBuilderAccess.Run);
            var moduleBuilder   = assemblyBuilder.DefineDynamicModule("<>ResteeGeneratedModule");
            return moduleBuilder;
        }

    }

    public class ClassGenerator {

        private object Generate(ModuleBuilder moduleBuilder,ResourceMeta resourceMeta) {
            var typeBuilder = moduleBuilder.DefineType(resourceMeta.ImplementationClassName,
                                                       TypeAttributes.Class | TypeAttributes.Public
                                                                            | TypeAttributes.Sealed, null,
                                                       resourceMeta.ResourceType);

            DefineConstructor(resourceMeta, typeBuilder);
        }

        private void DefineConstructor(ResourceMeta resourceMeta, TypeBuilder typeBuilder) {
            var ctorSignature = new Type[0];
           var ctor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Any, ctorSignature);
           var il = ctor.GetILGenerator();
        }

    }

}