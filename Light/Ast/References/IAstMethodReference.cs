﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Light.Ast.References {
    public interface IAstMethodReference : IAstMemberReference {
        IAstTypeReference ReturnType { get; }
        string Name { get; }
    }
}
