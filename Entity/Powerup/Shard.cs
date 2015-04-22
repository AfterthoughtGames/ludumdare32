using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace papercut
{
    public class Shard : PowerUp
    {
        public void LoadContent(ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("thing");
        }
    }
}
