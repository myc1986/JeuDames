using APIJeuMorpionCsharp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Interfaces
{
    public interface ITerrainJeu
    {
        bool TerrainRempli();
        bool CaseLibre(Coordonnee cetteCoordonnee);
        bool SymbolePlusRepresente();
        void PoserElement(Coordonnee cetteCoordonnee, IElement unPion);
        bool VerifierSiJoueurGagne(Coordonnee uneCoordonnee, Pion unPion, int nbrElementGagnantMax);
        List<ICase> GetCases();

        void AnnulerPoseElement(Coordonnee uneCoordonnee, System.Drawing.Image image);
    }
}
