using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Francony_Morel
{
    internal class Courant : Account
    {
        private double decouvert;
        public Courant(Owner owner, double sold) : base(owner, sold)
        {

        }
    }
    
}
