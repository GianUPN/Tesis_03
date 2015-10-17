using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Tesis_02.Core;
namespace Tesis_02
{
    class Pared : Sprite
    {
        public Pared(Game1 game) : base(null)
        {
            Texture2D pared = game.Content.Load<Texture2D>("sprites/pared");

            base.animacion = new Animacion();
            base.animacion.agregarFrame(pared, 200);
        }

    }
}
