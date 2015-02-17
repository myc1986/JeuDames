using APIJeuMorpionCsharp.Globales;
using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Classes
{
    public class Plateau : ITerrainJeu
    {
        protected IDictionary<string, ICase> _mesCases;

        public Plateau(int taillePlateau)
        {
            _mesCases = new Dictionary<string, ICase>();



            for (int x = 0; x < taillePlateau; x++)
            {
                for (int y = 0; y < taillePlateau; y++)
                {
                    Coordonnee uneCoordonnee = new Coordonnee(x, y);
                    CaseMorpion uneCase = new CaseMorpion(uneCoordonnee);

                    ControlCaseMorpion unControl = (ControlCaseMorpion)uneCase.GetRepresentation();
                    _mesCases.Add(ConvertIdCase(x, y), uneCase);
                   

                }
            }
        }

        public bool TerrainRempli()
        {
            bool rep = true;

            foreach (ICase uneCase in _mesCases.Values)
            {
                
                if (!uneCase.EstCoche())
                {
                    rep = false;
                }
            }

            return rep;
        }

        public bool CaseLibre(Coordonnee cetteCoordonnee)
        {
            bool rep = false;

            if (_mesCases.ContainsKey(ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)))
            {
                if (!_mesCases[ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)].EstCoche())
                {
                    rep = true;
                }
            }

            return rep;
        }

        

        public bool SymbolePlusRepresente()
        {
            throw new NotImplementedException();
        }


        public void PoserElement(Coordonnee cetteCoordonnee, Pion unPion)
        {
            if (_mesCases.ContainsKey(ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)))
            {
                if (!_mesCases[ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)].EstCoche())
                {
                    _mesCases[ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)].RecevoirElement(unPion);
                }
            }
        }

        public bool VerifierSiJoueurGagne(Coordonnee uneCoordonnee, Pion unPion, int nbrElementGagnantMax)
        {
            if (VerfierSiJoueurGagneHorizontalement(uneCoordonnee, unPion, nbrElementGagnantMax))
            {
                return true;
            }

            if (VerifierSiJoueurGagneVerticalement(uneCoordonnee, unPion, nbrElementGagnantMax))
            {
                return true;
            }

            if (VerifierSiJoueurGagneDiagonalement(uneCoordonnee, unPion, nbrElementGagnantMax))
            {
                return true;
            }

            return false;
        }

        private bool VerifierSiJoueurGagneDiagonalement(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            if (PeutGagneDiagonalement(uneCoordonnee, p_nbrElementGagnant))
            {
                int nbrElementTrouve = GetNbrElementsTrouvesIdentiquesDiagonalement(uneCoordonnee, unPion, p_nbrElementGagnant);

                if (nbrElementTrouve == p_nbrElementGagnant)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetNbrElementsTrouvesIdentiquesDiagonalement(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            int nbrElementTrouve = 0;

            if (PeutAllerEnHautADroite(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnHautADroite(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            if (PeutAllerEnHautAGauche(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnHautAGauche(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            if (PeutAllerEnBasADroite(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBasADroite(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            if (PeutAllerEnBasAGauche(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBasAGauche(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            if (PeutAllerEnHautADroiteEtEnBasAGauche(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnHautADroite(uneCoordonnee, unPion, p_nbrElementGagnant);
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBasAGauche(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            if (PeutAllerEnHautAGaucheEtEnBasADroite(uneCoordonnee, p_nbrElementGagnant))
            {
                nbrElementTrouve = 0;
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnHautAGauche(uneCoordonnee, unPion, p_nbrElementGagnant);
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBasADroite(uneCoordonnee, unPion, p_nbrElementGagnant);
            }

            nbrElementTrouve++;

            return nbrElementTrouve;
        }

        private bool PeutGagneDiagonalement(Coordonnee uneCoordonnee, int p_nbrElementGagnant)
        {
            return PeutAllerEnHautADroite(uneCoordonnee, p_nbrElementGagnant) || PeutAllerEnHautAGauche(uneCoordonnee, p_nbrElementGagnant) || PeutAllerEnBasAGauche(uneCoordonnee, p_nbrElementGagnant) || PeutAllerEnBasADroite(uneCoordonnee, p_nbrElementGagnant) || PeutAllerEnHautADroiteEtEnBasAGauche(uneCoordonnee, p_nbrElementGagnant) || PeutAllerEnHautAGaucheEtEnBasADroite(uneCoordonnee, p_nbrElementGagnant);
        }

        private int GetNbrElementsIdentiquesEnBasAGauche(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            int nbrElementTrouve = 0;

            int nbrMaxCount = p_nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X - iCompteur < nbrMaxCount) && (uneCoordonnee.Y + iCompteur < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X - iCompteur, uneCoordonnee.Y + iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrElementsIdentiquesEnHautADroite(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = p_nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X + iCompteur < nbrMaxCount) && (uneCoordonnee.Y - iCompteur < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X + iCompteur, uneCoordonnee.Y - iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrElementsIdentiquesEnBasADroite(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = p_nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X + iCompteur < nbrMaxCount) && (uneCoordonnee.X + iCompteur >= 0) && (uneCoordonnee.Y + iCompteur < nbrMaxCount) && (uneCoordonnee.Y + iCompteur >= 0))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X + iCompteur, uneCoordonnee.Y + iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrElementsIdentiquesEnHautAGauche(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = p_nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X - iCompteur < nbrMaxCount) && (uneCoordonnee.X - iCompteur >= 0) && (uneCoordonnee.Y - iCompteur < nbrMaxCount) && (uneCoordonnee.Y - iCompteur >= 0))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X - iCompteur, uneCoordonnee.Y - iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private bool PeutAllerEnHautAGaucheEtEnBasADroite(Coordonnee uneCoordonnee, int p_nbrElementGagnant)
        {
            return CaseAyantBordureCommeVoisinDeCase(uneCoordonnee, p_nbrElementGagnant);
        }

        private bool PeutAllerEnHautADroiteEtEnBasAGauche(Coordonnee uneCoordonnee, int p_nbrElementGagnant)
        {
            return CaseAyantBordureCommeVoisinDeCase(uneCoordonnee, p_nbrElementGagnant);
        }

        private static bool CaseAyantBordureCommeVoisinDeCase(Coordonnee uneCoordonnee, int p_nbrElementGagnant)
        {
            int nbrCaseEnHaut = uneCoordonnee.Y - 0;
            int nbrCaseAGauche = uneCoordonnee.X - 0;

            int nbrCaseEnBas = (p_nbrElementGagnant - 1) - uneCoordonnee.Y;
            int nbrCaseADroite = (p_nbrElementGagnant - 1) - uneCoordonnee.X;

            return (nbrCaseEnHaut >= 1) && (nbrCaseAGauche >= 1) && (nbrCaseEnBas >= 1) && (nbrCaseADroite >= 1);
        }

        private bool VerifierSiJoueurGagneVerticalement(Coordonnee uneCoordonnee, Pion unPion, int p_nbrElementGagnant)
        {
            if (PeutGagneVerticalement(uneCoordonnee, p_nbrElementGagnant))
            {
                int nbrElementTrouve = GetNbrElementsTrouvesIdentiquesVerticale(uneCoordonnee, unPion, p_nbrElementGagnant);

                if (nbrElementTrouve == p_nbrElementGagnant)
                {
                    return true;
                }
            }

            return false;
        }

        private bool VerfierSiJoueurGagneHorizontalement(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            if (PeutGagneHorizontalement(uneCoordonnee, nbrElementGagnant))
            {
                int nbrElementTrouve = GetNbrElementsTrouvesIdentiquesHorizontale(uneCoordonnee, unPion, nbrElementGagnant);

                if (nbrElementTrouve == nbrElementGagnant)
                {
                    return true;
                }
            }

            return false;
        }

        private int GetNbrElementsTrouvesIdentiquesHorizontale(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;

            if (PeutAllerAGauche(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrELementsIdentiqueAGauche(uneCoordonnee, unPion, nbrElementGagnant);
            }

            if (PeutAllerADroite(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesADroite(uneCoordonnee, unPion, nbrElementGagnant);
            }

            if (PeutAvoirDesElementsIdentiquesAGaucheEtDroiteGagnant(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesADroite(uneCoordonnee, unPion, nbrElementGagnant);
                nbrElementTrouve = nbrElementTrouve + GetNbrELementsIdentiqueAGauche(uneCoordonnee, unPion, nbrElementGagnant);
            }


            nbrElementTrouve++;//Plus l'élément lui même coché

            return nbrElementTrouve;
        }

        private int GetNbrElementsTrouvesIdentiquesVerticale(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;

            if (PeutAllerEnHaut(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrELementsIdentiqueEnHaut(uneCoordonnee, unPion, nbrElementGagnant);
            }

            if (PeutAllerEnBas(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBas(uneCoordonnee, unPion, nbrElementGagnant);
            }

            if (PeutAvoirDesElementsIdentiquesEnHautEtEnBasGagnant(uneCoordonnee, nbrElementGagnant))
            {
                nbrElementTrouve = nbrElementTrouve + GetNbrELementsIdentiqueEnHaut(uneCoordonnee, unPion, nbrElementGagnant);
                nbrElementTrouve = nbrElementTrouve + GetNbrElementsIdentiquesEnBas(uneCoordonnee, unPion, nbrElementGagnant);
            }

            nbrElementTrouve++;//Plus l'élément lui même coché

            return nbrElementTrouve;
        }

        private int GetNbrElementsIdentiquesEnBas(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X < nbrMaxCount) && (uneCoordonnee.Y + iCompteur < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y + iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrELementsIdentiqueEnHaut(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = nbrElementGagnant;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X < nbrMaxCount) && (uneCoordonnee.Y + iCompteur < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y + iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrElementsIdentiquesEnHaut(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = nbrElementGagnant * -1;

            int iCompteur = uneCoordonnee.Y;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X > nbrMaxCount) && (uneCoordonnee.Y + iCompteur > nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y+iCompteur)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur--;
            }

            return nbrElementTrouve - 1;
        }

        private int GetNbrElementsIdentiquesADroite(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = nbrElementGagnant;
            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X + iCompteur < nbrMaxCount) && (uneCoordonnee.Y < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X + iCompteur, uneCoordonnee.Y)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve-1;
        }

        private int GetNbrELementsIdentiqueAGauche(Coordonnee uneCoordonnee, IElement unPion, int nbrElementGagnant)
        {
            int nbrElementTrouve = 0;
            int nbrMaxCount = (nbrElementGagnant)*-1;

            int iCompteur = 0;
            bool aTrouveeUnMemePion = true;

            while (aTrouveeUnMemePion && (uneCoordonnee.X + iCompteur < nbrMaxCount) && (uneCoordonnee.Y < nbrMaxCount))
            {
                if (_mesCases[ConvertIdCase(uneCoordonnee.X + iCompteur, uneCoordonnee.Y)].GetElement().Valeur().Equals(unPion.Valeur()))
                {
                    nbrElementTrouve++;
                }
                else
                {
                    aTrouveeUnMemePion = false;
                }

                iCompteur++;
            }

            return nbrElementTrouve-1;
        }


        private static string ConvertIdCase(int x, int y)
        {
            return String.Format("X{0}Y{1}", x, y);
        }

        private static string ConvertIdCaseVarX(Coordonnee uneCoordonnee, int i)
        {
            return String.Format("X{0}Y{1}", uneCoordonnee.X + i, uneCoordonnee.Y);
        }

        private static string ConvertIdCaseVarY(Coordonnee uneCoordonnee, int i)
        {
            return String.Format("X{0}Y{1}", uneCoordonnee.X, uneCoordonnee.Y+i);
        }

        private static bool PeutAllerAGauche(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return (uneCoordonnee.X - 0) == (nbrElementGagnant - 1);
        }

        private static bool PeutAllerADroite(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return ((nbrElementGagnant - 1) - uneCoordonnee.X) == (nbrElementGagnant - 1);
        }

        private static bool PeutAllerEnHaut(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return (uneCoordonnee.Y - (nbrElementGagnant - 1)) == (nbrElementGagnant - 1);
        }

        private static bool PeutAllerEnBas(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return ((nbrElementGagnant - 1) - uneCoordonnee.Y) == (nbrElementGagnant - 1);
        }

        private static bool PeutAllerEnBasAGauche(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAllerEnBas(uneCoordonnee, nbrElementGagnant) && PeutAllerAGauche(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutAllerEnBasADroite(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAllerEnBas(uneCoordonnee, nbrElementGagnant) && PeutAllerADroite(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutAllerEnHautAGauche(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAllerEnHaut(uneCoordonnee, nbrElementGagnant) && PeutAllerAGauche(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutAllerEnHautADroite(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAllerEnHaut(uneCoordonnee, nbrElementGagnant) && PeutAllerADroite(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutGagneHorizontalement(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAvoirDesElementsIdentiquesSeSuivantAGaucheOuADroite(uneCoordonnee, nbrElementGagnant) || PeutAvoirDesElementsIdentiquesAGaucheEtDroiteGagnant(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutAvoirDesElementsIdentiquesSeSuivantAGaucheOuADroite(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return (Math.Abs(uneCoordonnee.X - (nbrElementGagnant-1)) == nbrElementGagnant - 1);
        }

        private static bool PeutAvoirDesElementsIdentiquesAGaucheEtDroiteGagnant(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            int nbrCaseRestantADroite = (nbrElementGagnant-1)-uneCoordonnee.X;
            int nbrCaseRestanteAGauche = uneCoordonnee.X - 0;

            return (nbrCaseRestantADroite >= 1) && (nbrCaseRestanteAGauche >= 1);
        }

        private static bool PeutGagneVerticalement(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return PeutAvoirDesElementsIdentiquesSeSuivantEnHautOuEnBas(uneCoordonnee, nbrElementGagnant) || PeutAvoirDesElementsIdentiquesEnHautEtEnBasGagnant(uneCoordonnee, nbrElementGagnant);
        }

        private static bool PeutAvoirDesElementsIdentiquesSeSuivantEnHautOuEnBas(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            return Math.Abs(uneCoordonnee.Y - (nbrElementGagnant - 1)) == (nbrElementGagnant - 1);
        }

        private static bool PeutAvoirDesElementsIdentiquesEnHautEtEnBasGagnant(Coordonnee uneCoordonnee, int nbrElementGagnant)
        {
            int nbrCaseRestantEnBas = (nbrElementGagnant - 1) - uneCoordonnee.Y;
            int nbrCaseRestantEnHaut = uneCoordonnee.Y - 0;

            return (nbrCaseRestantEnBas >= 1) && (nbrCaseRestantEnHaut >= 1);
        }


        public void PoserElement(Coordonnee cetteCoordonnee, IElement unPion)
        {
            if (_mesCases.ContainsKey(ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)))
            {
                if (!_mesCases[ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)].EstCoche())
                {
                    _mesCases[ConvertIdCase(cetteCoordonnee.X, cetteCoordonnee.Y)].RecevoirElement(unPion);
                }
            }
        }


        public List<ICase> GetCases()
        {
            return _mesCases.Values.ToList();
        }


        public void AnnulerPoseElement(Coordonnee uneCoordonnee, System.Drawing.Image image)
        {
            if (_mesCases.ContainsKey(ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y)))
            {
                if (Properties.Resources.image_O.Equals(MethodesGlobales.GetSauvegardeAvantDerniereCoche()))
                {
                    _mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y)].AnnulerElement(new Pion("O"), MethodesGlobales.GetSauvegardeAvantDerniereCoche());
                }
                else if (Properties.Resources.image_X.Equals(MethodesGlobales.GetSauvegardeAvantDerniereCoche()))
                {
                    _mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y)].AnnulerElement(new Pion("X"), MethodesGlobales.GetSauvegardeAvantDerniereCoche());
                }
                else
                {
                    _mesCases[ConvertIdCase(uneCoordonnee.X, uneCoordonnee.Y)].AnnulerElement(new Pion(""), MethodesGlobales.GetSauvegardeAvantDerniereCoche());
                }
                
            }
        }
    }
}
