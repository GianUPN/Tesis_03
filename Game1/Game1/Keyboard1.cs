using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Tesis_02
{
    public class Keyboard1
    {

        private KeyboardState keyboardStateActual;
        private KeyboardState keyboardStatePrevio;

        private static Keyboard1 instance;

        
        private Keyboard1() { }

        public static Keyboard1 Instance
       {
          get 
          {
             if (instance == null)
             {
                 instance = new Keyboard1();
             }
             return instance;
          }
       }

        public KeyboardState getkeyboardStateActual
        {
            get { return this.keyboardStateActual; }
        }
        public void setkeyboardStateActual(KeyboardState estado)
        {
            this.keyboardStateActual = estado;
        }

        public KeyboardState getkeyboardStatePrevio
        {
            get { return this.keyboardStatePrevio; }
        }
        public void setkeyboardStatePrevio(KeyboardState estado)
        {
            this.keyboardStatePrevio = estado;
        }

    }
}
