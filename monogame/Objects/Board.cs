using Microsoft.Xna.Framework;

namespace monogame.Objects
{
    public class Board
    {
        public Rectangle[] lines { get; set; }
        public int Thickness { get; set; }
        public int Length { get; set; }


        public Board()
        {
            lines = new Rectangle[4];
            Thickness = 10;
            Length = 300;
        }
    }
}
