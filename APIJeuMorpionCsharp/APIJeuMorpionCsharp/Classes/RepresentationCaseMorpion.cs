using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APIJeuMorpionCsharp.Classes
{
    public class RepresentationCaseMorpion : Representation
    {
        protected PictureBox _monImage;

        public RepresentationCaseMorpion(PictureBox uneImage) : base()
        {
            _monImage = uneImage;
            
        }


    }
}
