﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Light.Ast.References;

namespace Light.Ast {
    public interface IAstCallable : IAstElement {
        IAstTypeReference ReturnType { get; }
    }
}
