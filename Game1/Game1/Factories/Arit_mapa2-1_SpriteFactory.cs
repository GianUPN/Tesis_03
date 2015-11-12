using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Personajes;
using Tesis02.Personajes.MundoArit;
using Tesis_02.Core;

namespace Tesis_02
{
    class Arit_mapa2_1_SpriteFactory : iSpriteFactory
    {
        private Game1 game;

        public Arit_mapa2_1_SpriteFactory(Game1 game)
        {
            this.game = game;
        }

        public Core.Sprite obtenerSprite(String nombreSprite)
        {
            Core.Sprite objSprite = null;
            switch (nombreSprite)
            {
                case "profesor":
                    objSprite = new Aritmetica_Maestro01(game);
                    break;
            }
            return objSprite;
        }
    }
}
