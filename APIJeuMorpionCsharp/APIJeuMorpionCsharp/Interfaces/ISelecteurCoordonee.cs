using APIJeuMorpionCsharp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIJeuMorpionCsharp.Interfaces
{
    public interface ISelecteurCoordonee : ICloneable
    {
        new object Clone();
        Coordonnee SelectionnerCoordonnee();
    }
}
