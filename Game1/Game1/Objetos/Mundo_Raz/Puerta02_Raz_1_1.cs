using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Objetos
{
    class Puerta02_Raz_1_1:Sprite
    {
        private Game1 game;
        public Puerta02_Raz_1_1(Game1 game)
            : base(null)
        {
            animacion = new Animacion();
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/black01"), 200);

            this.game = game;
            base.animacion = animacion;
        }
        public override void actualizar(long tiempo)
        {
           
            base.actualizar(tiempo);

        }


        public override void evento_ColisionVerticalSprite(Sprite objSprite)
        {
            if (objSprite is PersonajePrincipal)
            {   
                
                Texture2D fondo = game.Content.Load<Texture2D>("Backgrounds/dungeon");
                TileMap.GetInstance.mapName = "Content/Mapas/mapa_1-2.csv";
                TileMap.GetInstance.posSpriteScrollingTileX = 10;
                TileMap.GetInstance.posSpriteScrollingTileY = 28;
                TileMap.GetInstance.spriteFactory = new Raz_mapa1_2_SpriteFactory(game);
                TileMap.GetInstance.ParallaxBackground = fondo;
                TileMap.GetInstance.regenerarMapa();
                
                
            }
            
        }
    }
}
