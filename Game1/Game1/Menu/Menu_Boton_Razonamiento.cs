using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Menu
{
    class Menu_Boton_Razonamiento : Sprite
    {
        private Game1 game;
        private Point mousePosition;
        
        public Menu_Boton_Razonamiento(Game1 game)
            : base(null)
        {   
           
            animacion = new Animacion();
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/btn_razonamiento"), 200);
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/btn_razonamiento"), 200);
            animacion.agregarFrame(game.Content.Load<Texture2D>("sprites/btn_razonamiento"), 200);
            //rectangulo = new Rectangle(1, (int)this.y, animacion.obtenerImagen().Width, animacion.obtenerImagen().Height);
            this.game = game;
            base.animacion = animacion;
        }
        public override void actualizar(long tiempo)
        {

            //colision con el mouse
            mousePosition = new Point(Mouse1.Instance.getmousestate.X, Mouse1.Instance.getmousestate.Y);
            
            base.actualizar(tiempo);

        }

        public override void evento_ColisionHorizontalTile()
        {

          
        }

        public override void evento_ColisionHorizontalSprite(Sprite objSprite)
        {
            try
            {
                TileMap.GetInstance.mapName = "Content/Mapas/mapa_1-1.csv";
                TileMap.GetInstance.posSpriteScrollingTileX = 10;
                TileMap.GetInstance.posSpriteScrollingTileY = 10;
                TileMap.GetInstance.spriteFactory = new Raz_mapa1_1_SpriteFactory(game);
                TileMap.GetInstance.regenerarMapa();

            }
            catch
            {

            } 

        }
    
    }
}
