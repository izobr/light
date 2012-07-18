﻿using System;
using System.Collections.Generic;
using System.Linq;
using AshMind.Extensions;
using Light.Ast.Expressions;
using Light.Ast.References.Methods;
using Light.Ast.References.Types;
using Mono.Cecil.Cil;

namespace Light.Compilation.Cil.Compilers {
    public class BinaryExpressionCompiler : CilCompilerBase<BinaryExpression> {
        private IDictionary<Tuple<Type, string>, OpCode> BuiltOpCodes = new Dictionary<Tuple<Type, string>, OpCode> {
            { Tuple.Create(typeof(int), "+"), OpCodes.Add }
        };

        public override void Compile(ILProcessor processor, BinaryExpression binary, CilCompilationContext context) {
            context.Compile(binary.Left);
            context.Compile(binary.Right);

            var builtIn = binary.Operator as AstBuiltInOperator;
            if (builtIn != null) {
                EmitBuiltInOperator(processor, binary);
                return;
            }

            processor.Emit(OpCodes.Call, context.ConvertReference(binary.Operator));
        }

        private void EmitBuiltInOperator(ILProcessor processor, BinaryExpression binary) {
            var type = ((AstReflectedType)binary.Operator.DeclaringType).ActualType;
            var key = Tuple.Create(type, binary.Operator.Name);

            OpCode code;
            var found = BuiltOpCodes.TryGetValue(key, out code);
            if (!found)
                throw new NotImplementedException("BinaryExpressionCompiler: could not find OpCode for " + key);

            processor.Emit(code);
        }
    }
}