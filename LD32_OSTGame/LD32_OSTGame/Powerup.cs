using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class PowerUp : Entity
    {
        public int AmmoCount { get; set; }

        public override void Collided(Entity collidedWith)
        {
            if (collidedWith.GetType() == typeof(Plane))
            {
                Pickup();
            }

            base.Collided(collidedWith);
        }

        private void Pickup()
        {
            this.Health = 0;
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            base.Draw(gameTime, batch);
        }
    }
}
