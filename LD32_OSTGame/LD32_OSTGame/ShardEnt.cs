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
        public ShardEnt(Texture2D img)
        {
            this.Damage = 1;
            this.image = img;
        }

        public ShardEnt(Vector2 vol, float roatation, Vector2 pos, Guid entID, Texture2D img)
        {
            this.Velocity = vol;
            this.Rotation = roatation;
            this.Position = pos;
            this.parrentID = entID;
            this.image = img;

            this.Thrust(-1);
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("Shard");
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, this.Position, Color.White);
        } 
    }
}
