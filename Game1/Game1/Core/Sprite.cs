using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tesis_02.Core;


namespace Tesis_02.Core
{
    public class Sprite
    {
        public Animacion animacion { get; protected set; }
        public float x { get; set; }
        public float y { get; set; }
        public float velocidadX { get; set; }
        public float velocidadY { get; set; }
        public bool visible { get; set; }
        public bool movil { get; set; }
        public bool solidoTiles { get; set; }
        public bool solidoSprites { get; set; }
        public float rotacion{get; set; }
        public Color color;
        public TileMap escenarioActual { get; set; }

        public Sprite(Animacion animacion) : this(animacion, 0, 0)
        { 
        }

        public Sprite(Animacion animacion, float x, float y)
        {
            this.animacion = animacion;
            this.x = x;
            this.y = y;
            this.movil = true;
            this.visible = true;
            this.solidoSprites = true;
            this.solidoTiles = true;
        }
         
        virtual public void actualizar(long tiempo)
        {
            if (movil)
            {
                x = x + velocidadX * tiempo;
                y = y + velocidadY * tiempo;
            }
            animacion.actualizar(tiempo);
        }

        virtual public void evento_ColisionHorizontalTile()
        {
            velocidadX = 0f;
        }

        virtual public void evento_ColisionVerticalTile()
        {
            velocidadY = 0f;
        }

        virtual public void evento_ColisionHorizontalSprite(Sprite objSprite)//En prueba
        {
            int medio = (int)this.x + (int)this.animacion.obtenerImagen().Width/2;
            int posobj = (int) objSprite.x + (int) objSprite.animacion.obtenerImagen().Width;
            if (objSprite.velocidadX > 0 &&  posobj<medio)
            {
                objSprite.velocidadX = 0f;
            }
            if (objSprite.velocidadX < 0 && medio < objSprite.x)
            {
                objSprite.velocidadX = 0f;
            }


        }

        virtual public void evento_ColisionVerticalSprite(Sprite objSprite)//En prueba
        {
            int medio = (int)this.y + (int)this.animacion.obtenerImagen().Height / 2;
            int posobj = (int)objSprite.y + (int)objSprite.animacion.obtenerImagen().Height;
            if (objSprite.velocidadY < 0 && posobj < medio)
            {
                objSprite.velocidadY = 0f;
            }
            if (objSprite.velocidadY > 0 && medio > objSprite.y)
            {
                objSprite.velocidadY = 0f;
            }
        }
     }
}