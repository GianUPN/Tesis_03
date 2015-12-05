using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Clases
{
    class Video01:Sprite
    {
    //private float fuerzaGravedad = 0.002f;



        protected Game1 game { get; set; }
      

        public Video01(Game1 game)
            : base(null)
        {
            this.game = game;


            Texture2D parado = game.Content.Load<Texture2D>("Player/parado"); //Parado
           // base.animacion = animParado;
           
        }

        public override void actualizar(long tiempo)
        {
            //Animacion correcta
           

            base.actualizar(tiempo);
            //Gravedad
            //velocidadY += fuerzaGravedad * tiempo;
        }

      
        public override void evento_ColisionVerticalTile()
        {
            
        }


        public override void evento_ColisionHorizontalTile()
        {
           
           // base.evento_ColisionHorizontalTile();
        }

        public override void evento_ColisionHorizontalSprite(Sprite objSprite)
        {

         

        }
        public override void evento_ColisionVerticalSprite(Sprite objSprite)
        {
           
        }

    }
}
