using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public abstract class Case : ICase
    {
        protected IElement _value;
        protected string _id;
        protected Coordonnee _maCoordonnee;
        protected IRepresentationCaseMorpion _maRepresentation;

        public abstract bool EstCoche();

        public IRepresentation GetRepresentation()
        {
            return _maRepresentation;
        }

        public virtual string GetId()
        {
            return string.Format("X{0}Y{1}", _maCoordonnee.X, _maCoordonnee.Y);
        }


        public virtual void RecevoirElement(IElement unPion)
        {
            _value = unPion;
        }
         
        public Coordonnee GetCoordonnee()
        {
            return _maCoordonnee;
        }

        public abstract object Clone();

        public IElement GetElement()
        {
            return _value;
        }


        public void AnnulerElement(Pion pion, System.Drawing.Image image)
        {
            _value = pion;
            _maRepresentation.AnnulerCoche(image);
        }
    }
}
