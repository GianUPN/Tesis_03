using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    public class Global_Resolviendo
    {
          private int estado;
      //1 = resolviendo
      //0 = jugando

        private static Global_Resolviendo instance;

        private Global_Resolviendo() { }

        public static Global_Resolviendo Instance
           {
              get 
              {
                 if (instance == null)
                 {
                     instance = new Global_Resolviendo();
                 }
                 return instance;
              }
           }

        public void setEstado(int estado)
          {
              this.estado = estado;
          }

        public int getestado()
          {
              return estado;
          }
    }
}
