using APIJeuMorpionCsharp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Interfaces
{
    public interface IJoueur
    {
        Coordonnee Jouer();
        IJoueur CreerCopie();
        string GetId();
        string GetNom();
    }
}
