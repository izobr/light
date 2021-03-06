﻿using System;
using System.Collections.Generic;
using System.Linq;
using Light.Ast.References;

namespace Light.Ast.Incomplete {
    public class AstImplicitType : AstElementBase, IAstTypeReference {
        public static AstImplicitType Instance { get; private set; }

        static AstImplicitType() {
            Instance = new AstImplicitType();
        }

        private AstImplicitType() {
        }

        protected override IEnumerable<IAstElement> VisitOrTransformChildren(AstElementTransform transform) {
            return No.Elements;
        }

        #region IAstTypeReference Members

        IAstMethodReference IAstTypeReference.ResolveMethod(string name, IEnumerable<IAstExpression> arguments) {
            throw new NotImplementedException("Implicit type can not resolve methods.");
        }
        
        IAstConstructorReference IAstTypeReference.ResolveConstructor(IEnumerable<IAstExpression> arguments) {
            throw new NotImplementedException("Implicit type can not resolve constructors.");
        }

        IAstMemberReference IAstTypeReference.ResolveMember(string name) {
            throw new NotImplementedException("Implicit type can not resolve members.");
        }

        #endregion

        #region IAstTypeReference Members

        string IAstTypeReference.Name {
            get { return ""; }
        }

        #endregion

        #region IAstReference Members

        object IAstReference.Target {
            get { return null; }
        }

        #endregion

        public override string ToString() {
            return "{ImplicitType}";
        }
    }
}
