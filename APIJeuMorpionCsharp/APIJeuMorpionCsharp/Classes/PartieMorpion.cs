using APIJeuMorpionCsharp.Formes;
using APIJeuMorpionCsharp.Globales;
using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace APIJeuMorpionCsharp.Classes
{
    public class PartieMorpion
    {
        protected IDictionary<string, IJoueur> _mesJoueurs;
        protected ITerrainJeu _monTerrain;
        protected ConfigurationPartie _maConfig;
        protected string _idGagnant = "";
        protected APIJeuMorpionCsharp.Formes.FrmConfiguration _maFormConfig;
        protected Thread _monThreadPlateau;
        protected Thread _monThreadTour;
        protected FrmConfiguration _maFrmmConfig;
        protected FormPlateau _maFormPlateau;


        public PartieMorpion(int nbrJoueur, IList<string> lesNomsJoueurs, int p_tailleGrille)
        {
            _maConfig = new ConfigurationPartie(nbrJoueur, lesNomsJoueurs, p_tailleGrille);
            //Initialiser();
        }

        public PartieMorpion(ConfigurationPartie uneConfigurationPartie)
        {
            _maConfig =(ConfigurationPartie) uneConfigurationPartie.Clone();
            //Initialiser();
        }

        public PartieMorpion()
        {
            //_maFormConfig = new FrmConfiguration();
            //_maFormConfig.ShowDialog();
            //_maConfig = (ConfigurationPartie)_maFormConfig.GetConfiguration().Clone();
            //Initialiser();
        }

        public ITerrainJeu GetTerrain()
        {
            return _monTerrain;
        }

        //protected bool Initialiser()
        //{
        //    _monTerrain = new Plateau(_maConfig.TailleGrille);
        //    _mesJoueurs = new Dictionary<string, IJoueur>();

        //    List<string> lesNoms = _maConfig.GetNomDesJoueurs;

        //    for (int i = 0; i < _maConfig.GetNomDesJoueurs.Count; i++)
        //    {
        //        Joueur leJoueur = new Joueur(_maConfig.GetNomDesJoueurs[i], i);
        //        _mesJoueurs.Add(leJoueur.GetId(), leJoueur);
        //    }

        //    MethodesGlobales.InitiialiserPremiereCocheAXOuO(true);

        //    return true;
        //}

        public void Main()
        {
            DemarrerPartie();
        }

        public void DemarrerPartie()
        {
            //_maFormPlateau = new FormPlateau(_maConfig);
            //_maFormPlateau.ChargerCases(_monTerrain.GetCases());

            //_maFormConfig.Terrain = _monTerrain;
            //_maFormConfig.Joueurs = _mesJoueurs;

            Dictionary<string, object> mesObjets = new Dictionary<string, object>();

            _maFormConfig = new FrmConfiguration();
            _monThreadPlateau = new Thread(AfficherConfiguration);
            _monThreadPlateau.Name = "Configuration du jeu morpion";
            _monThreadPlateau.IsBackground = false;
            
            _monThreadPlateau.Priority = ThreadPriority.Highest;
            _monThreadPlateau.Start();
            //Initialiser();
            //_monThreadTour = new Thread(TourDeJeu);
            //_monThreadTour.Name = "Thread Tour de jeu Morpion";
            //_monThreadTour.Start();
            Thread.CurrentThread.IsBackground = true;
            Thread.CurrentThread.Join();
        }

        public void AfficherConfiguration()
        {
            _maFormConfig = new FrmConfiguration();
            _maFormConfig.ShowDialog();
        }
    }
}
