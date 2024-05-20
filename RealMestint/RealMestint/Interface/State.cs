using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealMestint.Interface
{
    public abstract class State : ICloneable
    {
        public char CurrentPlayer { get; set; }
        public abstract Status GetStatus();
        public abstract object Clone();
    }
}
