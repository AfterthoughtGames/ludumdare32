using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace papercut
{
    public class Projectile : Entity
    {
        public Guid parrentID { get; set; }
        public int Damage { get; set; }
    }
}
