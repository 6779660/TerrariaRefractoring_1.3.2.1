using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Entities
{
    public class Spawn : EntityBase
    {
        public string worldName;
        public int worldID;
        public int posX;
        public int posY;
        public override void save(System.IO.BinaryWriter Data)
        {
            Data.Write(posX);
            Data.Write(posY);
            Data.Write(worldID);
            Data.Write(worldName);
        }

        public override void load(System.IO.BinaryReader Data)
        {
            int posX = Data.ReadInt32();
            if (posX == -1)
            {
                throw new Exception();
            }
            else
            {
                this.posX = posX;
                this.posY = Data.ReadInt32();
                this.worldID = Data.ReadInt32();
                this.worldName = Data.ReadString();
            }
        }
    }
}
