using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            
        }
        public abstract void save(BinaryWriter Data);
        public abstract void load(BinaryReader Data);
    }
}
