using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Objetos
{
    class Portal01 : Sprite
    {
        private Game1 game;
        public Portal01(Game1 game)
            : base(null)
        {
            animacion = new Animacion();
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/warp01"), 40);
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/warp02"), 40);
            this.game = game;
            base.animacion = animacion;
        }
        public override void actualizar(long tiempo)
        {

            base.actualizar(tiempo);

        }

        public override void evento_ColisionHorizontalTile()
        {

            //base.evento_ColisionHorizontalTile();
        }

        public override void evento_ColisionHorizontalSprite(Sprite objSprite)
        {
            if (objSprite is PersonajePrincipal)
            {
                TileMap.GetInstance.posSpriteScrollingTileX = 9;
                TileMap.GetInstance.posSpriteScrollingTileY = 10;
                TileMap.GetInstance.regenerarMapa();
            }

        }
    }
}