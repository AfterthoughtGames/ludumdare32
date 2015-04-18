using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD32_OSTGame
{
    //Base Entity becasue Matt and I wanted it
    public class Entity
    {
        Texture2D image { get; set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        float Rotation { get; set; }
        float Scale { get; set; }
        int Health { get; set; }

    }
}
