﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;
using Tesis_02.Objetos;
using Tesis_02.Personajes.MundoRaz;

namespace Tesis_02
{
    class Raz_mapa1_1_SpriteFactory : iSpriteFactory
    {
        private Game1 game;

        public Raz_mapa1_1_SpriteFactory(Game1 game)
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
                case "indiana2":
                    objSprite = new Personaje_Indiana02(game);
                    break;

                case "indiana3":
                    objSprite = new Personaje_Indiana03(game);
                    break;
                case "indiana4":
                    objSprite = new Personaje_Indiana04(game);
                    break;   
                case "puerta":
                    objSprite = new Puerta(game);
                    break;

                case "puerta2":
                    objSprite = new Puerta02_Raz_1_1(game);
                    break;
                case "portal01":
                    objSprite = new Portal01(game);
                    break;
            }
            return objSprite;
        }

        
        

    }
}
