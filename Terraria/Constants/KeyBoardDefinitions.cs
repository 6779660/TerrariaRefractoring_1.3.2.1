using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Terraria.Constants
{
    public class KeyBoardDefinitions
    {
        public static string cUp = "W";
        public static string cLeft = "A";
        public static string cDown = "S";
        public static string cRight = "D";
        public static string cJump = "Space";
        public static string cThrowItem = "T";
        public static string cHeal = "H";
        public static string cMana = "J";
        public static string cBuff = "B";
        public static string cHook = "E";
        public static string cTorch = "LeftShift";
        public static string cInv = "Escape";
        public static string cMapZoomIn = "Add";
        public static string cMapZoomOut = "Subtract";
        public static string cMapAlphaUp = "PageUp";
        public static string cMapAlphaDown = "PageDown";
        public static string cMapFull = "M";
        public static string cMapStyle = "Tab";

        public static void setBindingMapValue(int bindingMapKey, string BindingMapValue)
        {
            if (BindingMapValue == "None") {
                return;
            }
            switch (bindingMapKey)
            {
                case 0:
                    cMapStyle = BindingMapValue;
                    break;
                case 1:
                    cMapFull = BindingMapValue;
                    break;
                case 2:
                    cMapZoomIn = BindingMapValue;
                    break;
                case 3:
                    cMapZoomOut = BindingMapValue;
                    break;
                case 4:
                    cMapAlphaUp = BindingMapValue;
                    break;
                case 5:
                    cMapAlphaDown = BindingMapValue;
                    break;
                default:
                    break;
            };
        }

        public static void resetBindingValues()
        {
            cUp = "W";
            cDown = "S";
            cLeft = "A";
            cRight = "D";
            cJump = "Space";
            cThrowItem = "T";
            cInv = "Escape";
            cHeal = "H";
            cMana = "M";
            cBuff = "B";
            cHook = "E";
            cTorch = "LeftShift";
        }

        public static void resetMapBindingValues() {
            cMapStyle = "Tab";
            cMapFull = "M";
            cMapZoomIn = "Add";
            cMapZoomOut = "Subtract";
            cMapAlphaUp = "PageUp";
            cMapAlphaDown = "PageDown";
        }
        public static void setBindingValue(int bindingKey, string BindingValue)
        {
            if (BindingValue == "None")
            {
                return;
            }
            switch (bindingKey)
            {
                case 0:
                    cUp = BindingValue;
                    break;
                case 1:
                    cDown = BindingValue;
                    break;
                case 2:
                    cLeft = BindingValue;
                    break;
                case 3:
                    cRight = BindingValue;
                    break;
                case 4:
                    cJump = BindingValue;
                    break;
                case 5:
                    cThrowItem = BindingValue;
                    break;
                case 6:
                    cInv = BindingValue;
                    break;
                case 7:
                    cHeal = BindingValue;
                    break;
                case 8:
                    cMana = BindingValue;
                    break;
                case 9:
                    cBuff = BindingValue;
                    break;
                case 10:
                    cHook = BindingValue;
                    break;
                case 11:
                    cTorch = BindingValue;
                    break;
                default:
                    break;
            };
        }
    }
}
