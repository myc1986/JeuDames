using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APIJeuMorpionCsharp.Globales;

namespace APIJeuMorpionCsharp.Classes
{
    public partial class ControlCaseMorpion : UserControl, IRepresentationCaseMorpion
    {
        protected string _id;
        protected bool _ressouceChoisiPourCocheEstX;

        public ControlCaseMorpion(string IdCaseMorpion) : base()
        {
            InitializeComponent();
            _id = IdCaseMorpion;
        }

        public void CocherX()
        {
            pictureBox1.BackgroundImage = Properties.Resources.image_X;
            pictureBox1.Refresh();
            MethodesGlobales.MettreCocheOAuProchaineClick();
        }

        public void CocherO()
        {
            this.pictureBox1.BackgroundImage = Properties.Resources.image_O;
            pictureBox1.Refresh();
            MethodesGlobales.MettreCocheXAuProchaineClick();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MethodesGlobales.SauvegarderAvantDerniereCoche(pictureBox1.BackgroundImage);

            if (MethodesGlobales.CocheXAMettre())
            {
                CocherX();
            }
            else
            {
                CocherO();
            }

            MethodesGlobales.DefinirCoordonneeSelectionne(new Coordonnee(_id));
            MethodesGlobales._leThreadTour.Resume();
            //MethodesGlobales.FermerFormeActive();
        }

        public bool EstCocherX()
        {
            return _ressouceChoisiPourCocheEstX;
        }

        public void DefinirToutesLesFutursCoche(bool seraCocheX)
        {
            _ressouceChoisiPourCocheEstX = seraCocheX;
        }


        public void AnnulerCoche(Image image)
        {
            pictureBox1.BackgroundImage = image;

            if (MethodesGlobales.CocheXAMettre())
            {
                MethodesGlobales.MettreCocheOAuProchaineClick();
            }
            else
            {
                MethodesGlobales.MettreCocheXAuProchaineClick();
            }
        }
    }
}
