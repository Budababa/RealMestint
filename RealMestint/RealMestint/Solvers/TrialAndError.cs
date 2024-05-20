using RealMestint.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.Interface
{
    public class TrialAndError : Solver
    {
        public TrialAndError(OperatorGenerator operatorGenerator) : base(operatorGenerator)
        {

        }
        private Random r = new();
        private Operator SelectOperator(State state)
        {
            List<int> indexes = new List<int>();
            while (indexes.Count < Operators.Count)
            {
                int index = r.Next(0, Operators.Count);
                while (indexes.Contains(index))
                {
                    index = r.Next(0, Operators.Count);
                }
                indexes.Add(index);
            }

            foreach (int index in indexes)
            {
                if (Operators[index].IsApplicable(state))
                {
                    return Operators[index];
                }
            }

            return null;
        }
        public override State NextMove(State state)
        {
            Operator op = SelectOperator(state);
            if (op != null)
            {
                return op.Apply(state);
            }
            return null;
        }
    }
}
