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
        private TimeSpan Lastfired { get; set; }

        // trash bools
        bool HasRazor = false;

        Random rand = new Random(DateTime.Now.Millisecond);

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

        public void Fire(GameTime time)
        {
            if(PowerUps[PowerSlotIndex].GetType() == typeof(Shard))
            {
                Game1.Pew.Play();

                if (Lastfired.TotalMilliseconds + 30 <= time.TotalGameTime.TotalMilliseconds)
                {
                    Game1.Entites.Add(new ShardEnt(this.Velocity, this.Rotation, this.Position, this.PlaneID, Game1.ShardImg, (float)rand.NextDouble()));
                }
            }

            if(PowerUps[PowerSlotIndex].GetType() == typeof(Razor))
            {
                Game1.Rip.Play();

                if (Lastfired.TotalMilliseconds + 30 <= time.TotalGameTime.TotalMilliseconds)
                {
                    Game1.Entites.Add(new RazorEnt(this.Velocity, this.Rotation, this.Position, this.PlaneID, Game1.RazorEntImg, (float)rand.NextDouble()));
                }
            }

            Lastfired = time.TotalGameTime;
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

        public override void Collided(Entity collidedWith)
        {
            if(collidedWith.GetType() == typeof(ShardEnt))
            {
                if(((ShardEnt)collidedWith).parrentID != this.PlaneID)
                {
                    this.Health--;

                    if(Position.X < collidedWith.Position.X)
                    {
                        //plane is left
                        this.Velocity *= new Vector2(-1,1);
                    }
                }
            }

            if (collidedWith.GetType() == typeof(Ball))
            {
                

                Vector2 away = collidedWith.Position - Position;
                if(away.Length() < 140 * collidedWith.Scale)
                {
                    away.Normalize();
                    this.Velocity = -away * 2;
                    this.Health--;
                }
                
                
            }

            if (collidedWith.GetType() == typeof(Razor))
            {
                bool hasPowerUp = false;

                foreach (PowerUp currentPowerUp in PowerUps)
                {
                    if (currentPowerUp.GetType() == typeof(Razor)) hasPowerUp = true;
                }

                if (hasPowerUp == false)
                {
                    HasRazor = true;
                    PowerUps.Add((Razor)collidedWith);
                }

                PowerSlotIndex = 1;
            }

            if(Health < 76 && Health > 49)
            {
                image = Game1.Plane2Img;
            }

            if (Health < 50 && Health > 24)
            {
                image = Game1.Plane3Img;
            }

            if (Health < 25 && Health > 0)
            {
                image = Game1.Plane4Img;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(image, Position, null, null, origin, Rotation, null,Color.Wheat ,SpriteEffects.None, 0);
            //spriteBatch.Draw(image, Position, null, null, origin, Rotation, null, 
               // new Color(236f, 249f, 155f), SpriteEffects.None, 0);
            //spriteBatch.DrawString(Game1.GUIFont, "Razor: " + HasRazor.ToString(), new Vector2(100, 100), Color.Red);
            base.Draw(gameTime, spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
            this.Body = this.ReturnNewBody();

            wrap();

            if(Health <= 0)
            {
                Game1.ActivePlay = false;
                Game1.ActiveSplash = true;
            }
        }


    }
}
