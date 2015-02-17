using APIJeuMorpionCsharp;
using APIJeuMorpionCsharp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APIJeuMorpionCsharp.Interfaces;
using System.Threading;
using APIJeuMorpionCsharp.Globales;

namespace APIJeuMorpionCsharp.Formes
{
    public partial class FormPlateau : Form
    {
        protected IDictionary<string, IJoueur> _mesJoueurs;
        protected string _idGagnant;
        protected ITerrainJeu _monTerrain;
        protected ConfigurationPartie _maConfiguration;
        private bool demarre;
        private Thread _tour;

        public FormPlateau()
        {
            InitializeComponent();
            _mesJoueurs = new Dictionary<string, IJoueur>();
            _monTerrain = null;
            demarre = false;
        }

        public FormPlateau(ConfigurationPartie _maConfiguration)
        {
            InitializeComponent();
            _mesJoueurs = new Dictionary<string, IJoueur>();
            _monTerrain = null;
            this._maConfiguration = _maConfiguration;
        }

        public ITerrainJeu Terrain { get { return _monTerrain; } set { _monTerrain = value; } }
        public IDictionary<string, IJoueur> Joueurs { get { return _mesJoueurs; } set { _mesJoueurs = value; } }

        public void ChargerCases(List<ICase> lesCases)
        {
            foreach (ICase uneCase in lesCases)
            {
                flp_terrain.Controls.Add((ControlCaseMorpion)uneCase.GetRepresentation());
            }

            flp_terrain.Refresh();
        }

        private void btn_demarrerPartie_Click(object sender, EventArgs e)
        {

        }

        private void TourDeJeu()
        {
            bool partieTerminee = false;

            Pion unPion = null;

            while (!partieTerminee)
            {
                foreach (IJoueur unJoueur in _mesJoueurs.Values)
                {
                    bool tourTermine = false;

                    if (MethodesGlobales.CocheXAMettre())
                    {
                        unPion = new Pion("X");
                    }
                    else
                    {
                        unPion = new Pion("O");
                    }

                    while (!tourTermine && !partieTerminee)
                    {

                        MessageBox.Show(string.Format("Joueur : {0} à vous de jouer !", unJoueur.GetNom()));

                        MethodesGlobales._leThreadTour.Suspend();

                        Coordonnee uneCoordonnee = unJoueur.Jouer();

                        if (_monTerrain.CaseLibre(uneCoordonnee))
                        {
                            _monTerrain.PoserElement(uneCoordonnee, unPion);

                            if (_monTerrain.VerifierSiJoueurGagne(uneCoordonnee, unPion, _maConfiguration.NbrElementGagnant))
                            {
                                _idGagnant = unJoueur.GetId();
                                partieTerminee = true;
                            }
                            else if (_monTerrain.TerrainRempli())
                            {
                                partieTerminee = true;
                            }

                            tourTermine = true;
                        }
                        else
                        {
                            MessageBox.Show("Cette case est déjà cochée !");
                            _monTerrain.AnnulerPoseElement(uneCoordonnee, MethodesGlobales.GetSauvegardeAvantDerniereCoche());
                        }
                    }

                }
            }

            if (partieTerminee && !string.IsNullOrEmpty(_idGagnant))
            {
                MessageBox.Show(String.Format("Le gagnant est {0} identifié par l'id {0} !", _mesJoueurs[_idGagnant].GetNom(), _mesJoueurs[_idGagnant].GetId()));
            }
            else
            {
                MessageBox.Show("Aucun vainqueur ! Match nul !");
            }
        }

        private void FormPlateau_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void FormPlateau_Load(object sender, EventArgs e)
        {
            MethodesGlobales._leThreadTour = new Thread(TourDeJeu);
            MethodesGlobales._leThreadTour.Name = "Tour de jeu";
            MethodesGlobales._leThreadTour.Start();
        }

        private void flp_terrain_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
