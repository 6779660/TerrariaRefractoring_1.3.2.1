using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Menus
{
    public abstract class Menu
    {
        private static readonly Dictionary<int, Menu> Menus = new Dictionary<int,Menu>{
            {-1, new NoneMenu()},
            {1212, new SelectStaticLangMenu()},
            {1213, new SelectLangMenu()},
        };

        public static Menu menuOf(int menuID)
        {
            if (Menus.ContainsKey(menuID))
            {
                return Menus[menuID];
            }
            else
            {
                return Menus[-1];
            }
        }

        public abstract void Draw();
    }
}
