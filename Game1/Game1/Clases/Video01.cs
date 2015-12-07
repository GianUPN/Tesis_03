using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Clases
{
    public class Video01:Game1
    {
    //private float fuerzaGravedad = 0.002f;

        Video video;
        VideoPlayer player;
        Texture2D videoTexture;

        protected Game1 game { get; set; }
      

        public Video01(Game1 game,String videoname)   
        {
            this.game = game;
           video = game.Content.Load<Video>(videoname);
           player.IsLooped = true;
            // Clases/prueba01
           
        }

        public void Draw(SpriteBatch spritebatch, Rectangle screen)
        {
            spritebatch.Draw(videoTexture, screen, Color.White);
        }
        
    }
}
