using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Tesis_02.Core
{
    public class CuadroAnimacion
    {
        public Texture2D imagen {get; set;}
        public long tiempo { get; set; }

        public CuadroAnimacion(Texture2D imagen, long tiempo)
        {
            this.imagen = imagen;
            this.tiempo = tiempo;
        }
    }
}
