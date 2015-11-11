using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesis_02
{
    public class Mouse1
    {
       // private Mouse mouseState;
        private static Mouse1 instance;


         private Mouse1() { }

         public static Mouse1 Instance
       {
          get 
          {
             if (instance == null)
             {
                 instance = new Mouse1();
             }
             return instance;
          }
       }
         public MouseState getmousestate
         {
             get { return Mouse.GetState(); }
         }

    }
}
