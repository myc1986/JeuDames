using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public interface IRepresentationCaseMorpion : IRepresentation
    {
        bool EstCocherX();
        void DefinirToutesLesFutursCoche(bool seraCocheX);

        void AnnulerCoche(System.Drawing.Image image);
    }
}
