using APIJeuMorpionCsharp.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace APIJeuMorpionCsharp.Classes
{
    public class Coordonnee : ICloneable
    {
        private string _id;

        public Coordonnee(int x, int y)
        {
            X = x;
            Y = y;
            _id = MethodesGlobales.ConvertirCoordonneEnIdCase(x, y);
        }

        public Coordonnee(string idCase)
        {
            this._id = idCase;
            ExtraireCoordonnees(idCase);
        }

        private void ExtraireCoordonnees(string idCase)
        {
            X = MethodesGlobales.ConvertirIdCaseEnCoordonnee(idCase).X;
            Y = MethodesGlobales.ConvertirIdCaseEnCoordonnee(idCase).Y;
        }
        /// <summary>
        ///  sigzida
        /// </summary>
        public int X{ get; set; }
        public int Y { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
