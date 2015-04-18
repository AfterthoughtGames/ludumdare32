using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
    public class PowerUp : Entity
    {
        public PowerUp()
        {
            this.Health = 1;
        }

        public override void Collided(Entity collidedWith)
        {
            Pickup();

            base.Collided(collidedWith);
        }

        private void Pickup()
        {
            this.Health = 0;
        }
    }
}
