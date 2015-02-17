using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIJeuMorpionCsharp.Globales;

namespace APIJeuMorpionCsharp.Classes
{
    public class CaseMorpion : Case
    {
        public CaseMorpion(Coordonnee laCoordonnee)
        {
            _maCoordonnee = laCoordonnee;
            _value = new Pion("");
            _id = MethodesGlobales.ConvertirCoordonneEnIdCase(laCoordonnee);
            _maRepresentation = new ControlCaseMorpion(MethodesGlobales.ConvertirCoordonneEnIdCase(laCoordonnee));
        }

        public CaseMorpion(Coordonnee laCoordonnee, IRepresentationCaseMorpion uneRepresentationCaseMorpion) : base()
        {
            _maCoordonnee = laCoordonnee;
            _value = new Pion("");
            _id = MethodesGlobales.ConvertirCoordonneEnIdCase(laCoordonnee);
            _maRepresentation = uneRepresentationCaseMorpion;
        }

        public override bool EstCoche()
        {
            bool rep = false;

            if (!string.IsNullOrEmpty(_value.Valeur()))
            {
                if (!Properties.Resources.image_depart.Equals(MethodesGlobales.GetSauvegardeAvantDerniereCoche()))
                {
                    rep = true;
                }
            }

            return rep;
        }

        public IElement GetPion()
        {
            return _value;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public override void RecevoirElement(IElement unPion)
        {
            _value = unPion;
        }
    }
}
