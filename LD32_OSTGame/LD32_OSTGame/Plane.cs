using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
   

    public class Plane : Entity
    {

        protected float FireRate { get; set; }
        protected Vector2 origin;
        protected List<PowerUp> PowerUps { get; set; }
        private int PowerSlotIndex { get; set; }
        public Guid PlaneID { get; set; }

        public Plane(Texture2D image, int health, Vector2 position, float scale, Vector2 velocity, float rotation) : base()
        {
            this.image = image;
            this.Health = health;
            this.Position = position;
            this.Scale = scale;
            this.Velocity = velocity;
            this.Rotation = rotation;

            PlaneID = Guid.NewGuid();

            origin = new Vector2(image.Width / 2, image.Height / 2);

            PowerUps = new List<PowerUp>();
            PowerUps.Add(new Shard());
        }

        public void Fire()
        {
            if(PowerUps[PowerSlotIndex].GetType() == typeof(Shard))
            {
                Game1.Entites.Add(new ShardEnt(this.Velocity, this.Rotation, this.Position, this.PlaneID, Game1.ShardImg));
            }
        }

        public void SwitchUpgrade(SwitchDirection dir)
        {
            if(dir == SwitchDirection.Right)
            {
                if(PowerUps.Count >= PowerSlotIndex + 1)
                {
                    PowerSlotIndex++;
                }
            }
            else
            {
                if (PowerUps.Count <= PowerSlotIndex - 1)
                {
                    PowerSlotIndex--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(image, Position, null, null, origin, Rotation, null,Color.White,SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
        }


    }
}
