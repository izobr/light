﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Light.Ast.Statements {
    public class ContinueStatement : IAstElement {
        #region IAstElement Members

        IEnumerable<IAstElement> IAstElement.Children() {
            yield break;
        }

        #endregion
    }
}
