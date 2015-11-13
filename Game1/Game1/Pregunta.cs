using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tesis_02.Core;

namespace Tesis_02
{
    class Pregunta //: Sprite
    {
        protected Game1 game { get; set; }
        private Rectangle r { get; set; }
        private Texture2D textura { get; set; }
        private String cadena { get; set; }

        /*public Pregunta(Game1 game)
            : base(null)
        {

        }*/

        public Pregunta(String cadena)
        {
            this.cadena = cadena;
        }

        public void LoadContent(ContentManager content)
        {
            textura = content.Load<Texture2D>(cadena);
            r = new Rectangle(0,0,textura.Width,textura.Height);

        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textura, r, Color.Aqua);
        }

        public void Centrar(int alto, int ancho)
        {
            r = new Rectangle(ancho, alto, this.r.Width, this.r.Height);
            //r = new Rectangle((ancho/2)-(this.r.Width/2), (alto/2)-(this.r.Height/2), this.r.Width, this.r.Height);
        }

        public void Update()
        {
            if(r.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //ahora deberia funcionar

            }
        }

    }
}
