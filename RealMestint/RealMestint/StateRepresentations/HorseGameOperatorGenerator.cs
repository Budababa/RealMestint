using RealMestint.Interface;
using RealMestint.StateRepresentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.StateRepresentations
{
    public class HorseGameOperatorGenerator : OperatorGenerator
    {
        public List<Operator> Operators { get; }

        public HorseGameOperatorGenerator()
        {
            Operators = new List<Operator>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Operators.Add(new HorseGameOperator(j, i, HorseGameState.PLAYER1));
                    Operators.Add(new HorseGameOperator(j, i, HorseGameState.PLAYER2));
                }
            }
        }
    }
}
