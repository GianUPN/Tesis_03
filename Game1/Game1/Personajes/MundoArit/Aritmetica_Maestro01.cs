using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using Tesis_02.Core;
using Tesis_02;
//xd
namespace Tesis02.Personajes.MundoArit
{
    class Aritmetica_Maestro01 : Sprite
    {
        public float velocidad { get; set; }
        public enum Direccion { Arriba, Abajo, Izquierda, Derecha };
        public Direccion direccion { get; set; }
        public enum Estado { Caminando, Parado };
        public Estado estado { get; set; }

        protected Game1 game { get; set; }

        private Animacion animParado;
        private Animacion animParadoDerecha;
        private Animacion animParadoIzquierda;
        private Animacion animParadoArriba;
        private Animacion animCaminandoAbajo;
        private Animacion animCaminandoDerecha;
        private Animacion animCaminandoIzquierda;
        private Animacion animCaminandoArriba;


        public Aritmetica_Maestro01(Game1 game)
            : base(null)
        {
            this.game = game;

            Texture2D parado = game.Content.Load<Texture2D>("ProfeArit/parado"); //Parado
            animParado = new Animacion();
            animParado.agregarFrame(parado, 100);

            Texture2D miraDerecha = game.Content.Load<Texture2D>("ProfeArit/derecha"); //Parado a la derecha
            animParadoDerecha = new Animacion();
            animParadoDerecha.agregarFrame(miraDerecha, 100);

            Texture2D miraIzquierda = game.Content.Load<Texture2D>("ProfeArit/izquierda"); //Parado a la izquierda
            animParadoIzquierda = new Animacion();
            animParadoIzquierda.agregarFrame(miraIzquierda, 100);

            Texture2D miraArriba = game.Content.Load<Texture2D>("ProfeArit/arriba"); //Parado hacia arriba
            animParadoArriba = new Animacion();
            animParadoArriba.agregarFrame(miraArriba, 100);

            //Caminando hacia abajo
            Texture2D caminandoAbajo1 = game.Content.Load<Texture2D>("ProfeArit/abajo1");
            Texture2D caminandoAbajo2 = game.Content.Load<Texture2D>("ProfeArit/abajo2");
            Texture2D caminandoAbajo3 = game.Content.Load<Texture2D>("ProfeArit/parado");
            animCaminandoAbajo = new Animacion();
            animCaminandoAbajo.agregarFrame(caminandoAbajo1, 250);
            animCaminandoAbajo.agregarFrame(caminandoAbajo2, 250);
            animCaminandoAbajo.agregarFrame(caminandoAbajo3, 250);

            //Caminando hacia la derecha
            Texture2D caminandoDerecha1 = game.Content.Load<Texture2D>("ProfeArit/derecha1");
            Texture2D caminandoDerecha2 = game.Content.Load<Texture2D>("ProfeArit/derecha2");
            Texture2D caminandoDerecha3 = game.Content.Load<Texture2D>("ProfeArit/derecha");
            animCaminandoDerecha = new Animacion();
            animCaminandoDerecha.agregarFrame(caminandoDerecha1, 250);
            animCaminandoDerecha.agregarFrame(caminandoDerecha2, 250);
            animCaminandoDerecha.agregarFrame(caminandoDerecha3, 250);

            //Caminando hacia la izquierda
            Texture2D caminandoIzquierda1 = game.Content.Load<Texture2D>("ProfeArit/izquierda1");
            Texture2D caminandoIzquierda2 = game.Content.Load<Texture2D>("ProfeArit/izquierda2");
            Texture2D caminandoIzquierda3 = game.Content.Load<Texture2D>("ProfeArit/izquierda");
            animCaminandoIzquierda = new Animacion();
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda1, 250);
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda2, 250);
            animCaminandoIzquierda.agregarFrame(caminandoIzquierda3, 250);

            //Caminando hacia arriba
            Texture2D caminandoArriba1 = game.Content.Load<Texture2D>("ProfeArit/arriba1");
            Texture2D caminandoArriba2 = game.Content.Load<Texture2D>("ProfeArit/arriba2");
            Texture2D caminandoArriba3 = game.Content.Load<Texture2D>("ProfeArit/arriba");
            animCaminandoArriba = new Animacion();
            animCaminandoArriba.agregarFrame(caminandoArriba1, 250);
            animCaminandoArriba.agregarFrame(caminandoArriba2, 250);
            animCaminandoArriba.agregarFrame(caminandoArriba3, 250);

            base.animacion = animParado;
            velocidad = 0.15f;
            this.velocidadX = 0.03f;
        }

        public override void actualizar(long tiempo)
        {
            //Animacion correcta
            this.velocidadY = 0;

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

            base.actualizar(tiempo);
            //Gravedad
            //velocidadY += fuerzaGravedad * tiempo;
        }

        public void actualizar_movimiento()
        {
            if (velocidadX > 0)
            {
                this.direccion = Direccion.Derecha;
            }
            if (velocidadX < 0)
            {
                this.direccion = Direccion.Izquierda;
            }

            //actualizar estados de personaje
            if (this.velocidadX != 0 || this.velocidadY != 0)
            {
                this.estado = Aritmetica_Maestro01.Estado.Caminando;
            }
            else
            {
                this.estado = Aritmetica_Maestro01.Estado.Parado;
            }
        }

        public void parar_personaje()
        {
            this.velocidadX = 0;
            this.velocidadY = 0;
        }

        public override void evento_ColisionVerticalTile()
        {

            // base.evento_ColisionVerticalTile();
        }

        public override void evento_ColisionHorizontalTile()
        {
            this.velocidadX = -this.velocidadX;
            // base.evento_ColisionHorizontalTile();
        }


    }
}