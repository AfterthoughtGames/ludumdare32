using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LD32_OSTGame
{
    public class Razor : PowerUp
    {
        Vector2 origin;
        float rotationSpeed;

        public Razor(Texture2D image, Vector2 position, float scale, float rotationSpeed, int ammoCount) : base()
        {
            this.image = image;
            this.Position = position;
            this.Scale = scale;
            this.Health = 1;
            this.rotationSpeed = rotationSpeed;
            this.AmmoCount = ammoCount;

            origin = new Vector2(image.Width / 2, image.Height / 2);
        }

        //public void LoadContent(ContentManager cm)
        //{
        //    this.image = cm.Load<Texture2D>("HappyRazorBladePickup");
        //}

        public override void Collided(Entity collidedWith)
          {
            base.Collided(collidedWith);
        }

        public override void Update(GameTime gameTime)
        {
            Body = this.ReturnNewBody();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, null, origin, Rotation, null,Color.White,SpriteEffects.None, 0);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
