using System.Collections.Generic;
using System.Reflection;

namespace Light.Ast.References.Methods {
    public class AstReflectedConstructor : AstElementBase, IAstConstructorReference {
        public ConstructorInfo Constructor { get; private set; }

        public AstReflectedConstructor(ConstructorInfo constructor) {
            this.Constructor = constructor;
        }

        protected override IEnumerable<IAstElement> VisitOrTransformChildren(AstElementTransform transform) {
            return No.Elements;
        }

        #region IAstReference Members

        object IAstReference.Target {
            get { return this.Constructor; }
        }

        #endregion
    }
}