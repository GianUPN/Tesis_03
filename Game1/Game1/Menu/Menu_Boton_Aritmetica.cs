using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Menu
{
    class Menu_Boton_Aritmetica : Sprite
    {
    private Game1 game;
       

        public Menu_Boton_Aritmetica(Game1 game)
            : base(null)
        {   
           
            animacion = new Animacion();
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/btn_aritmetica"), 200);
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/btn_aritmetica"), 200);
            //rectangulo = new Rectangle(1, (int)this.y, animacion.obtenerImagen().Width, animacion.obtenerImagen().Height);
            this.game = game;
            base.animacion = animacion;
        }
        public override void actualizar(long tiempo)
        {

            //colision con el mouse

            base.actualizar(tiempo);

        }

        public override void evento_ColisionHorizontalTile()
        {

          
        }

        public override void evento_ColisionHorizontalSprite(Sprite objSprite)
        {
            try
            {
                Texture2D fondo = game.Content.Load<Texture2D>("Backgrounds/dungeon");
                TileMap.GetInstance.mapName = "Content/Mapas/mapa_1-2.csv";
                TileMap.GetInstance.posSpriteScrollingTileX = 20;
                TileMap.GetInstance.posSpriteScrollingTileY = 10;
                TileMap.GetInstance.spriteFactory = new Raz_mapa1_2_SpriteFactory(game);
                TileMap.GetInstance.ParallaxBackground = fondo;
                TileMap.GetInstance.regenerarMapa();

            }
            catch
            {

            } 

        }
    
    }
}
