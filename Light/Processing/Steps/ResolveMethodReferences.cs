﻿using System;
using System.Collections.Generic;
using System.Linq;
using Light.Ast.Expressions;
using Light.Ast.Incomplete;

namespace Light.Processing.Steps {
    public class ResolveMethodReferences : ProcessingStepBase<CallExpression> {
        public override void ProcessAfterChildren(CallExpression call, ProcessingContext context) {
            if (!(call.Method is AstUnknownMethod))
                return;

            if (call.Method.DeclaringType == null)
                throw new NotImplementedException("ResolveMethodReferences: DeclaringType not set on " + call.Method + ".");

            call.Method = call.Method.DeclaringType.ResolveMethod(call.Method.Name, call.Arguments);
        }
    }
}