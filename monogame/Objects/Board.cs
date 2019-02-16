using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.Objects
{
    public class Board
    {
        public Rectangle[] lines { get; set; }
        public int Thickness { get; set; }
        public int Length { get; set; }

        public Board()
        {
            Thickness = 10;
            Length = 300;
            lines = new Rectangle[4] {
                new Rectangle(195, 100, Thickness, Length),
                new Rectangle(295, 100, Thickness, Length),
                new Rectangle(100, 195, Length, Thickness),
                new Rectangle(100, 295, Length, Thickness),
            };
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Rectangle line in lines) {
                sb.Draw(GeneralAttributes.LineTexture, line, Color.White);
            }
        }
    }
}
