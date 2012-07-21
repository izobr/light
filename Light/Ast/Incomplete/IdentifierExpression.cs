﻿using System;
using System.Collections.Generic;
using System.Linq;
using Light.Ast.References;

namespace Light.Ast.Incomplete {
    public class IdentifierExpression : AstElementBase, IAstExpression, IAstAssignable, IAstReference {
        public string Name { get; private set; }

        public IdentifierExpression(string name) {
            Argument.RequireNotNullAndNotEmpty("name", name);
            this.Name = name;
        }

        public override string ToString() {
            return this.Name;
        }

        IAstTypeReference IAstExpression.ExpressionType {
            get { return AstUnknownType.WithNoName; }
        }

        protected override IEnumerable<IAstElement> VisitOrTransformChildren(AstElementTransform transform) {
            return No.Elements;
        }

        #region IAstReference Members

        object IAstReference.Target {
            get { return null; }
        }

        #endregion
    }
}
