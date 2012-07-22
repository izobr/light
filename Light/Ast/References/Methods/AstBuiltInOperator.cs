using System;
using System.Collections.Generic;

namespace Light.Ast.References.Methods {
    public class AstBuiltInOperator : AstElementBase, IAstMethodReference {
        public string Name { get; private set; }
        public IAstTypeReference OperandType { get; private set; }
        public IAstTypeReference ReturnType { get; private set; }

        public AstBuiltInOperator(string name, IAstTypeReference operandType, IAstTypeReference resultType) {
            Argument.RequireNotNullAndNotEmpty("name", name);
            Argument.RequireNotNull("operandType", operandType);
            Argument.RequireNotNull("resultType", resultType);

            this.Name = name;
            this.OperandType = operandType;
            this.ReturnType = resultType;
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