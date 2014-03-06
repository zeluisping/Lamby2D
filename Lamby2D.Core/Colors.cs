using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lamby2D.Core
{
    /// <summary>
    /// A collection of constant colors.
    /// </summary>
    public static class Colors
    {
        /// <summary>
        /// The color black (0, 0, 0, 1).
        /// </summary>
        public static readonly Color Black = new Color(0, 0, 0);
        /// <summary>
        /// The color white (1, 1, 1, 1).
        /// </summary>
        public static readonly Color White = new Color(1, 1, 1);

        /// <summary>
        /// The color red (1, 0, 0, 1).
        /// </summary>
        public static readonly Color Red = new Color(1, 0, 0);
        /// <summary>
        /// The color green (0, 1, 0, 1).
        /// </summary>
        public static readonly Color Green = new Color(0, 1, 0);
        /// <summary>
        /// The color blue (0, 0, 1, 1).
        /// </summary>
        public static readonly Color Blue = new Color(0, 0, 1);

        /// <summary>
        /// The transparent color (0, 0, 0, 0).
        /// </summary>
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        /// <summary>
        /// The color magenta (1, 0, 1, 1).
        /// </summary>
        public static readonly Color Magenta = new Color(1, 0, 1);
        /// <summary>
        /// The color purple (0.5, 0, 0.5, 1).
        /// </summary>
        public static readonly Color Purple = new Color(0.5f, 0, 0.5f);
        /// <summary>
        /// The orange color (1, 11/17, 0, 1).
        /// </summary>
        public static readonly Color Orange = new Color(1, 165 / 255f, 0);

        /// <summary>
        /// The corn flower blue color (0.4, 0.6, 0.9, 1).
        /// </summary>
        public static readonly Color CornFlowerBlue = new Color(0.4f, 0.6f, 0.9f);

        public static readonly Color AliceBlue = new Color(240, 248f / 255f, 1);
        public static readonly Color LightSalmon = new Color(1, 160, 122f / 255f);
        public static readonly Color AntiqueWhite = new Color(250, 235f / 255f, 215f / 255f);
        public static readonly Color LightSeaGreen = new Color(32f / 255f, 178f / 255f, 170);
        public static readonly Color Aqua = new Color(0, 1, 1);
        public static readonly Color LightSkyBlue = new Color(135f / 255f, 206f / 255f, 250);
        public static readonly Color Aquamarine = new Color(127f / 255f, 1, 212f / 255f);
        public static readonly Color LightSlateGray = new Color(119f / 255f, 136f / 255f, 153f / 255f);
        public static readonly Color Azure = new Color(240, 1, 1);
        public static readonly Color LightSteelBlue = new Color(176f / 255f, 196f / 255f, 222f / 255f);
        public static readonly Color Beige = new Color(245f / 255f, 245f / 255f, 220);
        public static readonly Color LightYellow = new Color(1, 1, 224f / 255f);
        public static readonly Color Bisque = new Color(1, 228f / 255f, 196f / 255f);
        public static readonly Color Lime = new Color(0, 1, 0);
        public static readonly Color LimeGreen = new Color(50, 205f / 255f, 50);
        public static readonly Color BlanchedAlmond = new Color(1, 1, 205f / 255f);
        public static readonly Color Linen = new Color(250, 240, 230);
        public static readonly Color BlueViolet = new Color(138f / 255f, 43f / 255f, 226f / 255f);
        public static readonly Color Maroon = new Color(0.5f, 0, 0);
        public static readonly Color Brown = new Color(165f / 255f, 42f / 255f, 42f / 255f);
        public static readonly Color MediumAquamarine = new Color(102f / 255f, 205f / 255f, 170);
        public static readonly Color BurlyWood = new Color(222f / 255f, 184f / 255f, 135f / 255f);
        public static readonly Color MediumBlue = new Color(0, 0, 205f / 255f);
        public static readonly Color CadetBlue = new Color(95f / 255f, 158f / 255f, 160);
        public static readonly Color MediumOrchid = new Color(186f / 255f, 85f / 255f, 211f / 255f);
        public static readonly Color Chartreuse = new Color(127f / 255f, 1, 0);
        public static readonly Color MediumPurple = new Color(147f / 255f, 112f / 255f, 219f / 255f);
        public static readonly Color Chocolate = new Color(210, 105f / 255f, 30);
        public static readonly Color MediumSeaGreen = new Color(60, 179f / 255f, 113f / 255f);
        public static readonly Color Coral = new Color(1, 127f / 255f, 80);
        public static readonly Color MediumSlateBlue = new Color(123f / 255f, 104f / 255f, 238f / 255f);
        public static readonly Color CornflowerBlue = new Color(100, 149f / 255f, 237f / 255f);
        public static readonly Color MediumSpringGreen = new Color(0, 250, 154f / 255f);
        public static readonly Color Cornsilk = new Color(1, 248f / 255f, 220);
        public static readonly Color MediumTurquoise = new Color(72f / 255f, 209f / 255f, 204f / 255f);
        public static readonly Color Crimson = new Color(220, 20, 60);
        public static readonly Color MediumVioletRed = new Color(199f / 255f, 21f / 255f, 112f / 255f);
        public static readonly Color Cyan = new Color(0, 1, 1);
        public static readonly Color MidnightBlue = new Color(25f / 255f, 25f / 255f, 112f / 255f);
        public static readonly Color DarkBlue = new Color(0, 0, 139f / 255f);
        public static readonly Color MintCream = new Color(245f / 255f, 1, 250);
        public static readonly Color DarkCyan = new Color(0, 139f / 255f, 139f / 255f);
        public static readonly Color MistyRose = new Color(1, 228f / 255f, 225f / 255f);
        public static readonly Color DarkGoldenrod = new Color(184f / 255f, 134f / 255f, 11f / 255f);
        public static readonly Color Moccasin = new Color(1, 228f / 255f, 181f / 255f);
        public static readonly Color DarkGray = new Color(169f / 255f, 169f / 255f, 169f / 255f);
        public static readonly Color NavajoWhite = new Color(1, 222f / 255f, 173f / 255f);
        public static readonly Color DarkGreen = new Color(0, 100, 0);
        public static readonly Color Navy = new Color(0, 0, 0.5f);
        public static readonly Color DarkKhaki = new Color(189f / 255f, 183f / 255f, 107f / 255f);
        public static readonly Color OldLace = new Color(253f / 255f, 245f / 255f, 230);
        public static readonly Color DarkMagena = new Color(139f / 255f, 0, 139f / 255f);
        public static readonly Color Olive = new Color(0.5f, 0.5f, 0);
        public static readonly Color DarkOliveGreen = new Color(85f / 255f, 107f / 255f, 47f / 255f);
        public static readonly Color OliveDrab = new Color(107f / 255f, 142f / 255f, 45f / 255f);
        public static readonly Color DarkOrange = new Color(1, 140, 0);
        public static readonly Color DarkOrchid = new Color(153f / 255f, 50, 204f / 255f);
        public static readonly Color OrangeRed = new Color(1, 69f / 255f, 0);
        public static readonly Color DarkRed = new Color(139f / 255f, 0, 0);
        public static readonly Color Orchid = new Color(218f / 255f, 112f / 255f, 214f / 255f);
        public static readonly Color DarkSalmon = new Color(233f / 255f, 150, 122f / 255f);
        public static readonly Color PaleGoldenrod = new Color(238f / 255f, 232f / 255f, 170);
        public static readonly Color DarkSeaGreen = new Color(143f / 255f, 188f / 255f, 143f / 255f);
        public static readonly Color PaleGreen = new Color(152f / 255f, 251f / 255f, 152f / 255f);
        public static readonly Color DarkSlateBlue = new Color(72f / 255f, 61f / 255f, 139f / 255f);
        public static readonly Color PaleTurquoise = new Color(175f / 255f, 238f / 255f, 238f / 255f);
        public static readonly Color DarkSlateGray = new Color(40, 79f / 255f, 79f / 255f);
        public static readonly Color PaleVioletRed = new Color(219f / 255f, 112f / 255f, 147f / 255f);
        public static readonly Color DarkTurquoise = new Color(0, 206f / 255f, 209f / 255f);
        public static readonly Color PapayaWhip = new Color(1, 239f / 255f, 213f / 255f);
        public static readonly Color DarkViolet = new Color(148f / 255f, 0, 211f / 255f);
        public static readonly Color PeachPuff = new Color(1, 218f / 255f, 155f / 255f);
        public static readonly Color DeepPink = new Color(1, 20, 147f / 255f);
        public static readonly Color Peru = new Color(205f / 255f, 133f / 255f, 63f / 255f);
        public static readonly Color DeepSkyBlue = new Color(0, 191f / 255f, 1);
        public static readonly Color Pink = new Color(1, 192f / 255f, 203f / 255f);
        public static readonly Color DimGray = new Color(105f / 255f, 105f / 255f, 105f / 255f);
        public static readonly Color Plum = new Color(221f / 255f, 160, 221f / 255f);
        public static readonly Color DodgerBlue = new Color(30, 144f / 255f, 1);
        public static readonly Color PowderBlue = new Color(176f / 255f, 224f / 255f, 230);
        public static readonly Color Firebrick = new Color(178f / 255f, 34f / 255f, 34f / 255f);
        public static readonly Color FloralWhite = new Color(1, 250, 240);
        public static readonly Color ForestGreen = new Color(34f / 255f, 139f / 255f, 34f / 255f);
        public static readonly Color RosyBrown = new Color(188f / 255f, 143f / 255f, 143f / 255f);
        public static readonly Color Fuschia = new Color(1, 0, 1);
        public static readonly Color RoyalBlue = new Color(65f / 255f, 105f / 255f, 225f / 255f);
        public static readonly Color Gainsboro = new Color(220, 220, 220);
        public static readonly Color SaddleBrown = new Color(139f / 255f, 69f / 255f, 19f / 255f);
        public static readonly Color GhostWhite = new Color(248f / 255f, 248f / 255f, 1);
        public static readonly Color Salmon = new Color(250, 0.5f, 114f / 255f);
        public static readonly Color Gold = new Color(1, 215f / 255f, 0);
        public static readonly Color SandyBrown = new Color(244f / 255f, 164f / 255f, 96f / 255f);
        public static readonly Color Goldenrod = new Color(218f / 255f, 165f / 255f, 32f / 255f);
        public static readonly Color SeaGreen = new Color(46f / 255f, 139f / 255f, 87f / 255f);
        public static readonly Color Gray = new Color(0.5f, 0.5f, 0.5f);
        public static readonly Color Seashell = new Color(1, 245f / 255f, 238f / 255f);
        public static readonly Color Sienna = new Color(160, 82f / 255f, 45f / 255f);
        public static readonly Color GreenYellow = new Color(173f / 255f, 1, 47f / 255f);
        public static readonly Color Silver = new Color(192f / 255f, 192f / 255f, 192f / 255f);
        public static readonly Color Honeydew = new Color(240, 1, 240);
        public static readonly Color SkyBlue = new Color(135f / 255f, 206f / 255f, 235f / 255f);
        public static readonly Color HotPink = new Color(1, 105f / 255f, 180);
        public static readonly Color SlateBlue = new Color(106f / 255f, 90, 205f / 255f);
        public static readonly Color IndianRed = new Color(205f / 255f, 92f / 255f, 92f / 255f);
        public static readonly Color SlateGray = new Color(112f / 255f, 0.5f, 144f / 255f);
        public static readonly Color Indigo = new Color(75f / 255f, 0, 130);
        public static readonly Color Snow = new Color(1, 250, 250);
        public static readonly Color Ivory = new Color(1, 240, 240);
        public static readonly Color SpringGreen = new Color(0, 1, 127f / 255f);
        public static readonly Color Khaki = new Color(240, 230, 140);
        public static readonly Color SteelBlue = new Color(70, 130, 180);
        public static readonly Color Lavender = new Color(230, 230, 250);
        public static readonly Color Tan = new Color(210, 180, 140);
        public static readonly Color LavenderBlush = new Color(1, 240, 245f / 255f);
        public static readonly Color Teal = new Color(0, 0.5f, 0.5f);
        public static readonly Color LawnGreen = new Color(124f / 255f, 252f / 255f, 0);
        public static readonly Color Thistle = new Color(216f / 255f, 191f / 255f, 216f / 255f);
        public static readonly Color LemonChiffon = new Color(1, 250, 205f / 255f);
        public static readonly Color Tomato = new Color(253f / 255f, 99f / 255f, 71f / 255f);
        public static readonly Color LightBlue = new Color(173f / 255f, 216f / 255f, 230);
        public static readonly Color Turquoise = new Color(64f / 255f, 224f / 255f, 208f / 255f);
        public static readonly Color LightCoral = new Color(240, 0.5f, 0.5f);
        public static readonly Color Violet = new Color(238f / 255f, 130, 238f / 255f);
        public static readonly Color LightCyan = new Color(224f / 255f, 1, 1);
        public static readonly Color Wheat = new Color(245f / 255f, 222f / 255f, 179f / 255f);
        public static readonly Color LightGoldenrodYellow = new Color(250, 250, 210);
        public static readonly Color LightGreen = new Color(144f / 255f, 238f / 255f, 144f / 255f);
        public static readonly Color WhiteSmoke = new Color(245f / 255f, 245f / 255f, 245f / 255f);
        public static readonly Color LightGray = new Color(211f / 255f, 211f / 255f, 211f / 255f);
        public static readonly Color Yellow = new Color(1, 1, 0);
        public static readonly Color LightPink = new Color(1, 182f / 255f, 193f / 255f);
        public static readonly Color YellowGreen = new Color(154f / 255f, 205f / 255f, 50 / 255f);
    }
}
