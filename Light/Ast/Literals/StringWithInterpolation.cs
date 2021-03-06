﻿using System;
using System.Collections.Generic;
using System.Linq;
using Light.Ast.References;
using Light.Ast.References.Types;

namespace Light.Ast.Literals {
    public class StringWithInterpolation : AstElementBase, IAstExpression {
        private static readonly IAstTypeReference StringType = new AstReflectedType(typeof(string));

        public string Text { get; private set; }

        public StringWithInterpolation(string text) {
            Text = text;
        }

        public IAstTypeReference ExpressionType {
            get { return StringType; }
        }

        protected override IEnumerable<IAstElement> VisitOrTransformChildren(AstElementTransform transform) {
            return No.Elements;
        }
    }
}
