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
    class Alternativa
    {
        protected Game1 game { get; set; }
        private Rectangle r;
        private Texture2D textura { get; set; }
        public String Cadena { get; set; }

        public delegate void elementClicked(string element);
        public event elementClicked clickEvent;
        

        public Alternativa(String cadena)
        {
            this.Cadena = cadena;
        }

        public void CargarAlternativa(ContentManager content)
        {
            textura = content.Load<Texture2D>(Cadena);
            r = new Rectangle(0,0,textura.Width,textura.Height);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(textura, r,Color.White);
        }

        public void Centrar(int alto, int ancho)
        {
            r = new Rectangle(ancho, alto, this.r.Width, this.r.Height);
            //r = new Rectangle((ancho/2)-(this.r.Width/2), (alto/2)-(this.r.Height/2), this.r.Width, this.r.Height);
        }

        public void Update()
        {
            if (r.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) &&
                Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                clickEvent(Cadena);
            }
        }
        public void moverElemento(int x, int y)
        {
            r = new Rectangle(r.X += x, r.Y += y, r.Width, r.Height);
        }

    }
}
