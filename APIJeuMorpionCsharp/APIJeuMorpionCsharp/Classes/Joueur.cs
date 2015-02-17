using APIJeuMorpionCsharp.Globales;
using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public class Joueur : IJoueur
    {
        protected string _nom;
        protected int _numero;
        protected string signe;

        public Joueur(string unNom, int numero, string signe)
        {
            this._nom = unNom;
            _numero = numero;
        }

        public Joueur(string unNom, int numero)
        {
            this._nom = unNom;
            _numero = numero;
        }

        public Coordonnee Jouer()
        {
            return MethodesGlobales.SelectionnerCoordonnee();
        }

        IJoueur IJoueur.CreerCopie()
        {
            return new Joueur(_nom, _numero);
        }

        public string GetId()
        {
            return _numero.ToString();
        }

        public string GetNom()
        {
            return _nom;
        }
    }
}
