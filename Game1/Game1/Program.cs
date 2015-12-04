using Game1;
using System;
using System.Windows.Forms;

namespace Tesis_02
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            using (Login fr = new Login())
            {
                Application.Run(fr);
            }
            
            using (Game1 game = new Game1())
            {
                game.Run();
            }
            
        }
    }
#endif
}

