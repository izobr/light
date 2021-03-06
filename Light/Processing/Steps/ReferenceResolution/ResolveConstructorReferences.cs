﻿using System;
using System.Collections.Generic;
using System.Linq;
using Light.Ast;
using Light.Ast.Expressions;

namespace Light.Processing.Steps.ReferenceResolution {
    public class ResolveConstructorReferences : ProcessingStepBase<AstNewExpression> {
        public ResolveConstructorReferences() : base(ProcessingStage.ReferenceResolution) {
        }

        public override IAstElement ProcessAfterChildren(AstNewExpression @new, ProcessingContext context) {
            if (@new.Constructor != null)
                return @new;

            @new.Constructor = @new.Type.ResolveConstructor(@new.Arguments);
            @new.Constructor.SourceSpan = @new.Type.SourceSpan;

            return @new;
        }
    }
}
