﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AshMind.Extensions;

namespace Light.Ast.Statements {
    public class IfOrUnlessStatement : IStatement {
        public IfOrUnlessKind Kind { get; private set; }
        public IAstElement Condition { get; private set; }
        public ReadOnlyCollection<IAstElement> Body { get; private set; }

        public IfOrUnlessStatement(IfOrUnlessKind kind, IAstElement condition, params IAstElement[] body) {
            Argument.RequireNotNull("condition", condition);
            Argument.RequireNotNullNotEmptyAndNotContainsNull("body", body);

            Kind = kind;
            Condition = condition;
            Body = body.AsReadOnly();
        }

        #region IAstElement Members

        IEnumerable<IAstElement> IAstElement.Children() {
            yield return this.Condition;
            foreach (var element in this.Body) {
                yield return element;
            }
        }

        #endregion
    }
}
