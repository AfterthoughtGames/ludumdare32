using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
    //Base Entity becasue Matt and I wanted it
    public class Entity
    {
        public Rectangle Body { get; set; }

        protected Texture2D image { get; set; }
        protected Vector2 Position { get; set; }
        protected Vector2 Velocity { get; set; }
        protected float Rotation { get; set; }
        protected float Scale { get; set; }
        protected int Health { get; set; }

        public virtual void Collided(Entity collidedWith)
        {
            //make this do things
        }

        public virtual bool CheckCollsion(Entity checkCollide)
        {
            return Body.Intersects(checkCollide.Body);
        }
    }
}
