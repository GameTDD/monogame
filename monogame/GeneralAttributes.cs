using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame
{

    public class GeneralAttributes
    {

        public static Texture2D LineTexture { get; set; }

        public static Color BackgroundColor()
        {
            return Color.White;
        }

        public void GenerateTextures(GraphicsDevice graphics)
        {
            LineTexture = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            Color[] colorData = { Color.Black };
            LineTexture.SetData<Color>(colorData);
        }
    }
}
