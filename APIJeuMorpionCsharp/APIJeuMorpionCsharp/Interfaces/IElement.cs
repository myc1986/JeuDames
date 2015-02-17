using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIJeuMorpionCsharp.Interfaces
{
    public interface IElement : ICloneable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string Valeur();
        new object Clone();
    }
}
