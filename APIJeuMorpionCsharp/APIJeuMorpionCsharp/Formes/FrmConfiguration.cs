using APIJeuMorpionCsharp.Classes;
using APIJeuMorpionCsharp.Globales;
using APIJeuMorpionCsharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIJeuMorpionCsharp.Formes
{
    public partial class FrmConfiguration : Form
    {
        protected ConfigurationPartie _maConfiguration;
        protected FormPlateau _maFrmPlateau;
        private Thread _unThreadPlateau;
        protected IDictionary<string, IJoueur> _mesJoueurs;
        protected ITerrainJeu _monTerrain;

        public FrmConfiguration()
        {
            InitializeComponent();
            _maConfiguration = null;
            _maFrmPlateau = new FormPlateau(_maConfiguration);
            _mesJoueurs = new Dictionary<string, IJoueur>();
            _monTerrain = null;
        }

        public ITerrainJeu Terrain { get { return _monTerrain; } set { _monTerrain = value; } }
        public IDictionary<string, IJoueur> Joueurs { get { return _mesJoueurs; } set { _mesJoueurs = value; } }
        public FormPlateau FormPlateau { get { return _maFrmPlateau; } set { _maFrmPlateau = value; } }

        public ConfigurationPartie GetConfiguration()
        {
            return _maConfiguration;
        }

        private void ChargerConfiguration()
        {
            List<string> lesNomsJoueurs = new List<string>();

            foreach (string item in lst_joueurs.Items)
            {
                lesNomsJoueurs.Add(item);
            }

            int tailleTerrain = int.Parse(txt_tailleTerrain.Text);

            _maConfiguration = new ConfigurationPartie(lst_joueurs.Items.Count, lesNomsJoueurs, tailleTerrain);
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            lst_joueurs.Items.Add(txt_nom.Text);
        }

        protected bool Initialiser()
        {
            _monTerrain = new Plateau(_maConfiguration.TailleGrille);
            _mesJoueurs = new Dictionary<string, IJoueur>();

            List<string> lesNoms = _maConfiguration.GetNomDesJoueurs;

            for (int i = 0; i < _maConfiguration.GetNomDesJoueurs.Count; i++)
            {
                Joueur leJoueur = new Joueur(_maConfiguration.GetNomDesJoueurs[i], i);
                _mesJoueurs.Add(leJoueur.GetId(), leJoueur);
            }

            MethodesGlobales.InitiialiserPremiereCocheAXOuO(true);

            return true;
        }

        private void btn_lancer_Click(object sender, EventArgs e)
        {
            int valeurTerrain = 0;

            if (int.TryParse(txt_tailleTerrain.Text, out valeurTerrain) && valeurTerrain > 0)
            {
                ChargerConfiguration();
                Hide();
                Initialiser();

                _unThreadPlateau = new Thread(AfficherPlateau);
                _unThreadPlateau.Name = "Plateau de jeu morpion";
                _unThreadPlateau.Start();
                _unThreadPlateau.Join();

                Show();
            }
            else
            {
                MessageBox.Show("Veuillez saisir un taille de terrain > 0");
            }

        }

        public void AfficherPlateau()
        {
            _maFrmPlateau = new Formes.FormPlateau(_maConfiguration);
            _maFrmPlateau.Terrain = _monTerrain;
            _maFrmPlateau.Joueurs = _mesJoueurs;
            _maFrmPlateau.ChargerCases(_monTerrain.GetCases());
            _maFrmPlateau.ShowDialog();
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
