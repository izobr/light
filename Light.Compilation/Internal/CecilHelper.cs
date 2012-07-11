﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace Light.Compilation.Internal {
    public static class CecilHelper {
        public static MethodDefinition CreateConstructor(ModuleDefinition module) {
            return new MethodDefinition(
                ".ctor",
                MethodAttributes.SpecialName | MethodAttributes.RTSpecialName | MethodAttributes.HideBySig,
                GetVoidType(module)
            );
        }

        public static TypeReference GetVoidType(ModuleDefinition module) {
            return module.Import(typeof(void));
        }
    }
}