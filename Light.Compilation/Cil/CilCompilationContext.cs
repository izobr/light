﻿using System;
using System.Collections.Generic;
using System.Linq;
using AshMind.Extensions;
using Light.Ast;
using Light.Ast.Definitions;
using Light.Ast.References;
using Light.Ast.Statements;
using Light.Compilation.Internal;
using Light.Compilation.References;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Light.Compilation.Cil {
    public class CilCompilationContext : IReferenceContext {
        private readonly IDictionary<AstVariableDefinition, VariableDefinition> locals = new Dictionary<AstVariableDefinition, VariableDefinition>();
        private readonly Action<IAstElement, CilCompilationContext> compile;
        private readonly IReferenceContext referenceContext;

        public MethodDefinition Method { get; private set; }
        public AstMethodDefinitionBase MethodAst { get; private set; }

        public CilCompilationContext(MethodDefinition method, AstMethodDefinitionBase methodAst, Action<IAstElement, CilCompilationContext> compile, IReferenceContext referenceContext) {
            this.compile = compile;
            this.referenceContext = referenceContext;
            this.Method = method;
            this.MethodAst = methodAst;
        }

        public void Compile(IAstElement element) {
            this.compile(element, this);
        }

        public VariableDefinition DefineVariable(string name, IAstTypeReference type) {
            var variableDefinition = new VariableDefinition(name, this.ConvertReference(type));

            this.Method.Body.InitLocals = true;
            this.Method.Body.Variables.Add(variableDefinition);

            return variableDefinition;
        }

        public void MapDefinition(AstVariableDefinition variableAst, VariableDefinition variable) {
            locals.Add(variableAst, variable);
        }

        public TypeReference ConvertReference(IAstTypeReference type, bool returnNullIfFailed = false) {
            return this.referenceContext.ConvertReference(type, returnNullIfFailed);
        }

        public MethodReference ConvertReference(IAstConstructorReference constructor, bool returnNullIfFailed = false) {
            return this.referenceContext.ConvertReference(constructor, returnNullIfFailed);
        }

        public MethodReference ConvertReference(IAstMethodReference method, bool returnNullIfFailed = false) {
            return this.referenceContext.ConvertReference(method, returnNullIfFailed);
        }

        public Either<FieldReference, PropertyReferenceContainer> ConvertReference(IAstPropertyReference property, bool returnNullIfFailed = false) {
            return this.referenceContext.ConvertReference(property, returnNullIfFailed);
        }

        public VariableDefinition ConvertReference(AstVariableReference variable, bool returnNullIfFailed = false) {
            var result = locals.GetValueOrDefault(variable.Variable);
            if (result == null && !returnNullIfFailed)
                throw new NotImplementedException("CilCompilationContext: can not resolve " + variable + ".");

            return result;
        }
    }
}
