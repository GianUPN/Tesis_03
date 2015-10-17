using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Tesis_02.Core
{
    public class Animacion
    {
        public List<CuadroAnimacion> cuadros{get;private set;}
        private int currFrameIndex;
        private long animTime;
        private long totalDuration;

        public Animacion() 
        {
            cuadros = new List<CuadroAnimacion>();
            totalDuration = 0;
            iniciar();
        }

        public void agregarFrame(Texture2D imagen, long duracion) {
            totalDuration += duracion;
            cuadros.Add(new CuadroAnimacion(imagen, totalDuration));
        }

        public void iniciar() {
            animTime = 0;
            currFrameIndex = 0;
        }

        public void actualizar(long tiempo) {
            if (cuadros.Count > 1)
            {
                animTime += tiempo;

                if (animTime >= totalDuration)
                {
                    animTime = animTime % totalDuration;
                    currFrameIndex = 0;
                }

                while (animTime > cuadros[currFrameIndex].tiempo)
                {
                    currFrameIndex++;
                }
            }
        }

        public Texture2D obtenerImagen()
        {
            if (cuadros.Count == 0 || cuadros.Count <= currFrameIndex)
            {
                return null;
            } 
            else 
            {
                return cuadros[currFrameIndex].imagen;
            }
        }

        public Texture2D obtenerImagen(int cuadro)
        {
            if (cuadros.Count == 0 || cuadros.Count <= currFrameIndex)
            {
                return null;
            } 
            else
            {
                return cuadros[cuadro].imagen;
            }
        }
    }
}