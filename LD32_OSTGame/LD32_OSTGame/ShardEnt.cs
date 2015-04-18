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
            this.Health = 1;
        }

        public ShardEnt(Vector2 vol, float roatation, Vector2 pos, Guid entID, Texture2D img)
        {
            this.Velocity = vol;
            this.Rotation = roatation;
            this.Position = pos;
            this.parrentID = entID;
            this.image = img;
            this.Health = 1;

            this.Body = new Rectangle((int)pos.X, (int)pos.Y, img.Width, img.Height);

            this.Thrust(-1.5f);
        }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager cm)
        {
            this.image = cm.Load<Texture2D>("Shard");
        }

        public override void Collided(Entity collidedWith)
        {
            if(collidedWith.GetType() == typeof(Plane))
            {
                if(((Plane)collidedWith).PlaneID != this.parrentID)
                {
                    this.Health--;
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            this.Body = this.ReturnNewBody();

            if (Position.X < 0 || Position.X > Game1.ScreenWidth || Position.Y < 0 || Position.Y > Game1.ScrrenHeight) this.Health = 0;
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, this.Position, Color.White);

            base.Draw(gameTime, batch);
        } 
    }
}
