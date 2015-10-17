﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;
using Tesis_02.Objetos;
using Tesis_02.Personajes.MundoRaz;

namespace Tesis_02
{
    class RazonamientoSpriteFactory : iSpriteFactory
    {
        private Game1 game;

        public RazonamientoSpriteFactory(Game1 game)
        {
            this.game = game;

        }

        public Sprite obtenerSprite(String nombreSprite){

            Sprite objSprite = null;
            switch (nombreSprite)
            {
                case "indiana":
                    objSprite = new Personaje_Indiana(game);
                    break;

                case "puerta":
                    objSprite = new Puerta(game);
                    break;

                case "portal01":
                    objSprite = new Portal01(game);
                    break;
            }
            return objSprite;
        }

        
        

    }
}
