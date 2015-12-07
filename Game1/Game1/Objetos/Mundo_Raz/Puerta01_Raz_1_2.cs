using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Objetos.Mundo_Raz
{
    class Puerta01_Raz_1_2:Sprite
    {
        private Game1 game;
        public Puerta01_Raz_1_2(Game1 game)
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
                
                Texture2D fondo = game.Content.Load<Texture2D>("Backgrounds/fondoisometrico");
                TileMap.GetInstance.mapName = "Content/Mapas/mapa_1-1.csv";
                TileMap.GetInstance.posSpriteScrollingTileX = 34;
                TileMap.GetInstance.posSpriteScrollingTileY = 18;
                TileMap.GetInstance.spriteFactory = new Raz_mapa1_1_SpriteFactory(game);
                TileMap.GetInstance.ParallaxBackground = fondo;
                TileMap.GetInstance.regenerarMapa();
                
                
            }
            
        }
    }
}
