using Game1;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesis_02.Core;

namespace Tesis_02.Personajes.MundoRaz
{
    public class Personaje_Indiana03:Sprite
    {
    //private float fuerzaGravedad = 0.002f;

        public float velocidad { get; set; }
        public enum Direccion { Izquierda, Derecha, Arriba, Abajo };
        public Direccion direccion { get; set; }
        public enum Estado { Caminando, Parado};
        public Estado estado { get; set; }

        protected Game1 game { get; set; }
        private int band = 0;
        private Animacion animParado;
        private Animacion animParadoDerecha;
        private Animacion animParadoIzquierda;
        private Animacion animParadoArriba;
        private Animacion animCaminandoAbajo;
        private Animacion animCaminandoDerecha;
        private Animacion animCaminandoIzquierda;
        private Animacion animCaminandoArriba;


        public Personaje_Indiana03(Game1 game)
            : base(null)
        {
            this.game = game;

            Texture2D parado = game.Content.Load<Texture2D>("Player/parado"); //Parado
            animParado = new Animacion();
            animParado.agregarFrame(parado,200);

            Texture2D miraDerecha = game.Content.Load<Texture2D>("Player/derecha"); //Parado a la derecha
            animParadoDerecha = new Animacion();
            animParadoDerecha.agregarFrame(miraDerecha, 200);

            Texture2D miraIzquierda = game.Content.Load<Texture2D>("Player/izquierda"); //Parado a la izquierda
            animParadoIzquierda = new Animacion();
            animParadoIzquierda.agregarFrame(miraIzquierda, 200);

            Texture2D miraArriba = game.Content.Load<Texture2D>("Player/arriba"); //Parado hacia arriba
            animParadoArriba = new Animacion();
            animParadoArriba.agregarFrame(miraArriba, 200);

            Texture2D caminandoAbajo1 = game.Content.Load<Texture2D>("Player/abajo1");//Caminando hacia abajo
            Texture2D caminandoAbajo2 = game.Content.Load<Texture2D>("Player/abajo2");
            Texture2D caminandoAbajo3 = game.Content.Load<Texture2D>("Player/abajo3");
            animCaminandoAbajo = new Animacion();
            animCaminandoAbajo.agregarFrame(caminandoAbajo1, 200);
            animCaminandoAbajo.agregarFrame(caminandoAbajo2, 200);
            animCaminandoAbajo.agregarFrame(caminandoAbajo3, 200);

            Texture2D caminandoDerecha1 = game.Content.Load<Texture2D>("Player/derecha1");//Caminando hacia la derecha
            Texture2D caminandoDerecha2 = game.Content.Load<Texture2D>("Player/derecha2");
            Texture2D caminandoDerecha3 = game.Content.Load<Texture2D>("Player/derecha3");
            animCaminandoDerecha = new Animacion();
            animCaminandoDerecha.agregarFrame(caminandoDerecha1, 200);
            animCaminandoDerecha.agregarFrame(caminandoDerecha2, 200);
            animCaminandoDerecha.agregarFrame(caminandoDerecha3, 200);

            Texture2D caminandoIzquierda1 = game.Content.Load<Texture2D>("Player/izquierda1");//Caminando hacia la izquierda
            Texture2D caminandoIzquierda2 = game.Content.Load<Texture2D>("Player/izquierda2");
            Texture2D caminandoIzquierda3 = game.Content.Load<Texture2D>("Player/izquierda3");
            animCaminandoIzquierda = new Animacion();
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda1, 200);
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda2, 200);
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda3, 200);


            Texture2D caminandoArriba1 = game.Content.Load<Texture2D>("Player/arriba1");//Caminando hacia arriba
            Texture2D caminandoArriba2 = game.Content.Load<Texture2D>("Player/arriba2");
            Texture2D caminandoArriba3 = game.Content.Load<Texture2D>("Player/arriba3");
            animCaminandoArriba = new Animacion();
            animCaminandoArriba.agregarFrame(caminandoArriba1, 200);
            animCaminandoArriba.agregarFrame(caminandoArriba2, 200);
            animCaminandoArriba.agregarFrame(caminandoArriba3, 200);

            base.animacion = animParado;
            velocidad = 0.15f;
            this.velocidadY = 0.03f;
        }

        public override void actualizar(long tiempo)
        {
            //Animacion correcta
            this.velocidadX = 0;
            


            actualizar_movimiento();
            switch (direccion)
            {
                case Direccion.Izquierda:
                    switch (estado)
                    {
                        case Estado.Caminando:
                            base.animacion = animCaminandoIzquierda;
                            break;
                        case Estado.Parado:
                            base.animacion = animParadoIzquierda;
                            break;
                    }
                    break;

                case Direccion.Derecha:
                    switch (estado)
                    {
                        case Estado.Caminando:
                            base.animacion = animCaminandoDerecha;
                            break;
                        case Estado.Parado:
                            base.animacion = animParadoDerecha;
                            break;
                    }
                    break;

                case Direccion.Arriba:
                    switch (estado)
                    {
                        case Estado.Caminando:
                            base.animacion = animCaminandoArriba;
                            break;
                        case Estado.Parado:
                            base.animacion = animParadoArriba;
                            break;
                    }
                    break;

                case Direccion.Abajo:
                    switch (estado)
                    {
                        case Estado.Caminando:
                            base.animacion = animCaminandoAbajo;
                            break;
                        case Estado.Parado:
                            base.animacion = animParado;
                            break;
                    }
                    break;
            }
            //actualizar_teclas();



            base.actualizar(tiempo);
            //Gravedad
            //velocidadY += fuerzaGravedad * tiempo;
        }

        public void actualizar_movimiento()
        {
            if (velocidadY > 0)
            {
                this.direccion = Direccion.Abajo; 
            }
            if (velocidadY < 0)
            {
                this.direccion = Direccion.Arriba;
            }
           
            //actualizar estados de personaje
            if (this.velocidadX != 0 || this.velocidadY != 0)
            {
                this.estado = Personaje_Indiana03.Estado.Caminando;
            }
            else
            {
                this.estado = Personaje_Indiana03.Estado.Parado;
            }
        }

        public void parar_personaje()
        {
            this.velocidadX = 0;
            this.velocidadY = 0;
        }

        public override void evento_ColisionVerticalTile()
        {
            this.velocidadY = -this.velocidadY;
           // base.evento_ColisionVerticalTile();
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
            if (objSprite is PersonajePrincipal && Keyboard1.Instance.getkeyboardStateActual.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space) && band==0)
            {
                //band = 1;
                PersonajePrincipal personaje = (PersonajePrincipal)objSprite;
                
                Frm_Pregunta fr = new Frm_Pregunta("puzzle03",4);
                {
                    fr.Show();

                }

            }
        }

    }
}
