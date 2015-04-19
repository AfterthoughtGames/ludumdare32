using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class KittenEnt : Projectile
    {
        float imageRotation;

        public KittenEnt(Vector2 vol, float roatation, Vector2 pos, Guid entID, Texture2D img, float randomness)
        {
            this.Velocity = vol;
            this.Rotation = roatation;
            this.Position = pos;
            this.parrentID = entID;
            this.image = img;
            this.Health = 1;
            this.Scale = randomness;
            this.imageRotation = 360f * randomness;

            this.Body = new Rectangle((int)pos.X, (int)pos.Y, img.Width, img.Height);

            this.Thrust(-1.75f);
        }

        public override void Update(GameTime gameTime)
        {
            Position += Velocity;
            this.Body = this.ReturnNewBody();

            if (Position.X < 0 || Position.X > Game1.ScreenWidth || Position.Y < 0 || Position.Y > Game1.ScreenHeight) this.Health = 0;
        }

        public override void Draw(GameTime gameTime, SpriteBatch batch)
        {
            batch.Draw(image, this.Position, null, null, new Vector2(6, 8), imageRotation, new Vector2(Scale), Color.White);

            base.Draw(gameTime, batch);
        } 
    }
}
