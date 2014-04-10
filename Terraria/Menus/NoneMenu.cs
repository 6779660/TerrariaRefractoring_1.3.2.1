using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Menus
{
    public class NoneMenu : Menu
    {
        public override void Draw()
        {
            Main.menuMode = 0;
        }
    }
}
