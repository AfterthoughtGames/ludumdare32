using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class Tape : PowerUp
    {
        public void LoadContent(ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("thing");
        }
    }
}
