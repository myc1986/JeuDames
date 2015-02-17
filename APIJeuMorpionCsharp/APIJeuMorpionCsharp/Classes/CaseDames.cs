using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIJeuMorpionCsharp.Enums;
using APIJeuMorpionCsharp.Globales;

namespace APIJeuMorpionCsharp.Classes
{
    class CaseDames : Case
    {
        protected ECouleurCaseDames _maCouleur;

        public CaseDames(Coordonnee maCoordonnee, ECouleurCaseDames couleurCase)
        {
            _maCouleur = couleurCase;
            _value = new Pion("");
            _id = MethodesGlobales.ConvertirCoordonneEnIdCase(maCoordonnee);
            //_maRepresentation = new ControlCase(MethodesGlobales.ConvertirCoordonneEnIdCase(maCoordonnee));
        }


        public override bool EstOccupee()
        {
            bool rep = false;

            if (!string.IsNullOrEmpty(_value.Valeur()))
            {
                // TODO
            }

            return rep;
        }

        public override object Clone()
        {
            return MemberwiseClone();
        }

        public bool ContientUneDame()
        {
            bool rep = false;
            
            // TODO

            return rep;
        }

        public ECouleurCaseDames EstUneCaseColoree()
        {
            return _maCouleur;
        }
    }
}
