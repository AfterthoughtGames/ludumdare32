using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class ShardEnt : Projectile
    {
        public ShardEnt()
        {
            this.Damage = 1;
        }

        public ShardEnt(Vector2 vol, float roatation, Vector2 pos, Guid entID)
        {
            this.Velocity = vol + new Vector2(1, 1);
            this.Rotation = roatation;
            this.Position = pos;
            this.parrentID = entID;
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("thing");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
