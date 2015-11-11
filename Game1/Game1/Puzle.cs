using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02
{
    class Puzle:Sprite

    {
        private Game1 game;
        public Puzle(Game1 game, String puzle)
            : base(null)
        {
            animacion = new Animacion();
            animacion.agregarFrame(game.Content.Load<Texture2D>("Puzzles/"+puzle), 200);

            this.game = game;
            base.animacion = animacion;
        }
        public override void actualizar(long tiempo)
        {

            if (Keyboard1.Instance.getkeyboardStateActual.IsKeyDown(Keys.Space))
            { }


            base.actualizar(tiempo);

        }

        public override void evento_ColisionHorizontalTile()
        {
            //base.evento_ColisionHorizontalTile();
        }

        public override void evento_ColisionVerticalTile()
        {
            //base.evento_ColisionVerticalTile();
        }
        public override void evento_ColisionHorizontalSprite(Sprite objSprite)
        {
            //base.evento_ColisionHorizontalSprite(objSprite);
        }
        public override void evento_ColisionVerticalSprite(Sprite objSprite)
        {
            //base.evento_ColisionVerticalSprite(objSprite);
        }

    }
}
