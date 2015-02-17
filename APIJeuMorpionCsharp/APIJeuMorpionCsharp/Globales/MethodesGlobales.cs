using APIJeuMorpionCsharp.Classes;
using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIJeuMorpionCsharp.Globales
{
    public static class MethodesGlobales
    {
        static Coordonnee _monSelectionneurCoodonnee;
        static Form _maFormActive;
        static bool _doitCocheX;
        static Image _maReresentationAvantDernierCoche;
        public static Thread _leThreadTour;

        public static void InitiialiserPremiereCocheAXOuO(bool mettreAX)
        {
            _doitCocheX = mettreAX;
        }

        public static void SauvegarderAvantDerniereCoche(Image laCoche)
        {
            _maReresentationAvantDernierCoche = laCoche;
        }

        public static Image GetSauvegardeAvantDerniereCoche()
        {
            return _maReresentationAvantDernierCoche;
        }

        public static void DefinirCoordonneeSelectionne(Coordonnee unSelecteurCoordonnee)
        {
            _monSelectionneurCoodonnee = unSelecteurCoordonnee;
        }

        internal static Coordonnee SelectionnerCoordonnee()
        {
            return _monSelectionneurCoodonnee;
        }

        public static void DefinirFormActive(Form uneForm)
        {
            _maFormActive = uneForm;
        }

        public static void FermerFormeActive()
        {
            _maFormActive.Close();
        }

        public static void MettreCocheXAuProchaineClick()
        {
            _doitCocheX = true;
        }
        
        public static void MettreCocheOAuProchaineClick()
        {
            _doitCocheX = false;
        }

        public static bool CocheXAMettre()
        {
            return _doitCocheX;
        }

        public static string ConvertirCoordonneEnIdCase(Coordonnee uneCoordonnee)
        {
            return string.Format("X{0}Y{1}", uneCoordonnee.X, uneCoordonnee.Y);
        }

        public static Coordonnee ConvertirIdCaseEnCoordonnee(string idCase)
        {
            Regex maRegexCoordonnee = new Regex("^x([0-9]+)y([0-9]+)$", RegexOptions.IgnoreCase);

            Coordonnee uneCoordonnee;

            if (maRegexCoordonnee.IsMatch(idCase))
            {
                int X = int.Parse(maRegexCoordonnee.Match(idCase).Groups[1].ToString());
                int Y = int.Parse(maRegexCoordonnee.Match(idCase).Groups[2].ToString());

                uneCoordonnee = new Coordonnee(X, Y);
            }
            else
            {
                MessageBox.Show("Extraction coordonnées raté !");
                uneCoordonnee = null;
            }

            return uneCoordonnee;
        }

        public static string ConvertirCoordonneEnIdCase(int p_x, int p_y)
        {
            return string.Format("X{0}Y{1}", p_x, p_y);
        }

        public static string ConvertIdCase(int x, int y)
        {
            return String.Format("X{0}Y{1}", x, y);
        }

        public static string ConvertIdCaseVarX(Coordonnee uneCoordonnee, int i)
        {
            return String.Format("X{0}Y{1}", uneCoordonnee.X + i, uneCoordonnee.Y);
        }

        public static string ConvertIdCaseVarY(Coordonnee uneCoordonnee, int i)
        {
            return String.Format("X{0}Y{1}", uneCoordonnee.X, uneCoordonnee.Y + i);
        }
    }
}
