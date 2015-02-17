using APIJeuMorpionCsharp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Interfaces
{
    public interface ICase : ICloneable
    {
        bool EstCoche();
        string GetId();
        void RecevoirElement(IElement unPion);
        Coordonnee GetCoordonnee();
        IElement GetElement();
        IRepresentation GetRepresentation();

        void AnnulerElement(Pion pion, System.Drawing.Image image);
    }
}
