﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Light.Ast {
    public interface IAstElement {
        IEnumerable<IAstElement> Children();
    }
}
