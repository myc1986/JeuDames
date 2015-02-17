using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public class Pion : IElement
    {
        protected string _valeur;

        public Pion(string val)
        {
            _valeur = val;
        }

        public string Valeur()
        {
            return _valeur;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
