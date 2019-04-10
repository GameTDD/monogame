using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace monogame.Objects
{
    public class Board
    {
        const int BASE_INVERT_AXIS = 100;
        const int FIRST_POSITION = 195;
        const int SECOND_POSITION = 295;

        public Rectangle[] lines { get; set; }
        public Region[] regions { get; set; }
        public int Thickness { get; set; }
        public int Length { get; set; }

        public Board(SpriteFont font)
        {
            Thickness = 10;
            Length = 300;
            lines = new Rectangle[4] {
                new Rectangle(FIRST_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(SECOND_POSITION, BASE_INVERT_AXIS, Thickness, Length),
                new Rectangle(BASE_INVERT_AXIS, FIRST_POSITION, Length, Thickness),
                new Rectangle(BASE_INVERT_AXIS, SECOND_POSITION, Length, Thickness),
            };
            regions = new Region[9] {
                new Region(100, 100, 94, 94, font),
                new Region(206, 100, 88, 94, font),
                new Region(306, 100, 94, 94, font),
                new Region(100, 206, 94, 88, font),
                new Region(206, 206, 88, 88, font),
                new Region(306, 206, 94, 88, font),
                new Region(100, 306, 94, 94, font),
                new Region(206, 306, 88, 94, font),
                new Region(306, 306, 94, 94, font)
            };
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Rectangle line in lines) {
                sb.Draw(GeneralAttributes.LineTexture, line, Color.White);
            }
            DrawRegions(sb);
        }

        public void DrawRegions(SpriteBatch sb) 
        {
            foreach (Region region in regions)
            {
                region.Draw(sb);
            }
        }
    }
}
