﻿using RealMestint.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.Interface
{
    public abstract class Solver
    {
        public List<Operator> Operators { get; }
        public Solver(OperatorGenerator operatorGenerator)
        {
            Operators = operatorGenerator.Operators;
        }

        public abstract State NextMove(State state);
    }
}
