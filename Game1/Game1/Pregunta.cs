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
        List<Alternativa> p = new List<Alternativa>();

        public Pregunta()
        {
            p.Add(new Alternativa("PuzzlesArit/question"));
            p.Add(new Alternativa("PuzzlesArit/OpA"));
            p.Add(new Alternativa("PuzzlesArit/OpB"));
            p.Add(new Alternativa("PuzzlesArit/OpC"));
        }

        public void LoadContent(ContentManager cont)
        {
            foreach(Alternativa item in p)
            {
                item.LoadContent(cont);
                item.Centrar(200,280);
            }

            p.Find(x => x.Cadena == "PuzzlesArit/OpA").moverElemento(50, 150);
            p.Find(x => x.Cadena == "PuzzlesArit/OpB").moverElemento(170, 150);
            p.Find(x => x.Cadena == "PuzzlesArit/OpC").moverElemento(290, 150);
        }

        public void Update()
        {
            foreach (Alternativa item in p)
            {
                item.Update();
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Alternativa it in p)
            {
                it.Draw(sb);
            }
        }

        

    }
}
