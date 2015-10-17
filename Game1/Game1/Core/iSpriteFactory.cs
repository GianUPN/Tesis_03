using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesis_02.Core
{
    public interface iSpriteFactory
    {
        Sprite obtenerSprite(String nombreSprite);
    }
}
