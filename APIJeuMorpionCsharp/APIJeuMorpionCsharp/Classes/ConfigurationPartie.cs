using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public class ConfigurationPartie : ICloneable
    {
        protected int _nbrJoueurs;
        protected int _nbrPions;
        protected IList<string> _lesNomsJoueurs;
        protected int _tailleTerrain;
        
        public ConfigurationPartie(int nbrJoueur, IList<string> lesNomsJoueurs, int tailleTerrain)
        {
            _nbrJoueurs = nbrJoueur;
            _tailleTerrain = tailleTerrain;
            _lesNomsJoueurs = lesNomsJoueurs.ToList();
        }

        public int NbrJoueur { get { return _lesNomsJoueurs.Count; } }
        public List<string> GetNomDesJoueurs { get { return _lesNomsJoueurs.ToList(); } }
        public int TailleGrille { get { return _tailleTerrain; } }
        public int NbrCases
        {
            get
            {
                return _tailleTerrain * _tailleTerrain;
            }
        }
        public int NbrPions
        { 
            get
            { 
                return _tailleTerrain*_tailleTerrain;
            } 
        }
        public int NbrElementGagnant { get { return TailleGrille; } }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
