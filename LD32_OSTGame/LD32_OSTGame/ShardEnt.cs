using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class ShardEnt : Projectile
    {
        public ShardEnt()
        {
            this.Damage = 1;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("thing");
        }
    }
}
