using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace papercut
{
    public class PhysicsBody
    {
        public Rectangle BoundingBox { get; set; }
        public Vector2 Position { get; set; }
    }
}
