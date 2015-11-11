using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;
using Tesis_02.Menu;

namespace Tesis_02
{
    class Menu_elegir01_SpriteFatory:iSpriteFactory
    {

         private Game1 game;

         public Menu_elegir01_SpriteFatory(Game1 game)
        {
            this.game = game;
        }

        public Sprite obtenerSprite(String nombreSprite){

            Sprite objSprite = null;
            switch (nombreSprite)
            {

                case "menu_btn_raz":
                    objSprite = new Menu_Boton_Razonamiento(game);
                    break;
                case "menu_btn_arit":
                    objSprite = new Menu_Boton_Aritmetica(game);
                    break;    
            }
            return objSprite;
        }

    }
}
