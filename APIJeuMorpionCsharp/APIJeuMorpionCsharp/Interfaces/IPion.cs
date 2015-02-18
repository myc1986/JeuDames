using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJeuMorpionCsharp.Interfaces
{
    interface IPion : ICloneable
    {
        abstract string Valeur();
        abstract object Clone();
    }
}
