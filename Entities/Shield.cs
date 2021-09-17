using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Shield : Entity
    {
        public char[,] graphic
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.','.','.'},
                    {'.','.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.','.'},
                    {'.','.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','.'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','.','.','.','.','.','.','.','0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','.','.','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0'},
                    {'0','0','0','0','0','.','.','.','.','.','.','.','.','.','.','.','0','0','0','0','0','0'},
                };
                return val;
            }
        }

        public Shield(int x, int y)
        {
            this.x = x;
            this.y = y;
            SetGraphic(graphic);
        }
        public int[] FindIntersect(Entity entity) // Determines intersect between Shield sprite and bullet sprite.
            {
            int[,] points1 = GetBoundingPoints();
            int[,] points2 = entity.GetBoundingPoints();

            int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0]));
            int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1]));

            int X1Start; // Variable instantiation
            int Y1Start; // Variable instantiation
            int X2Start; // Variable instantiation
            int Y2Start; // Variable instantiation

            if (points1[0, 0] < points2[0, 0]) // Compares which sprite is further left.
            {
                X2Start = 0;
                X1Start = points2[0, 0] - points1[0, 0]; // Subtracts the X value of the top left corners of each sprite.
            }
            else // Used if the first sprite is further right than the second.
            {
                X1Start = 0;
                X2Start = points1[0, 0] - points2[0, 0]; // Subtracts the X value of the top left corners of each sprite.
            }
            if (points1[0, 1] < points2[0, 1]) // Compares which sprite is above the other.
            {
                Y2Start = 0;
                Y1Start = points2[0, 1] - points1[0, 1];
            }
            else // Used if the first sprite is below the other.
            {
                Y1Start = 0;
                Y2Start = points1[0, 1] - points2[0, 1];
            }
            int j = Y1Start;
            int j2 = Y2Start;
            for (int relY = 0; relY < YOverlap; relY++, j++, j2++) // this is the key for this function 
            {
                int i = X1Start;
                int i2 = X2Start;
                for (int relX = 0; relX < XOverlap; relX++, i++, i2++)
                {
                    bool pixel1 = sprite.GetPixel(i, j).A != Color.Transparent.A;
                    bool pixel2 = entity.sprite.GetPixel(i2, j2).A != Color.Transparent.A;
                    if (pixel1 && pixel2)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { -1, -1 }; 
        }
        public void Damage(Entity explosion) // Simulates partial destruction of sheild when intersecting with a bullet.
        {
            {
                int[,] points1 = GetBoundingPoints();
                int[,] points2 = explosion.GetBoundingPoints();

                int XOverlap = Math.Max(0, Math.Min(points1[3, 0], points2[3, 0]) - Math.Max(points1[0, 0], points2[0, 0]));
                int YOverlap = Math.Max(0, Math.Min(points1[3, 1], points2[3, 1]) - Math.Max(points1[0, 1], points2[0, 1]));

                int X1Start; // Variable instantiation
                int Y1Start; // Variable instantiation
                int X2Start; // Variable instantiation
                int Y2Start; // Variable instantiation

                if (points1[0, 0] < points2[0, 0]) // Compares which sprite is further left.
                {
                    X2Start = 0;
                    X1Start = points2[0, 0] - points1[0, 0]; // Subtracts the X value of the top left corners of each sprite.
                }
                else // Used if the first sprite is further right than the second.
                {
                    X1Start = 0;
                    X2Start = points1[0, 0] - points2[0, 0]; // Subtracts the X value of the top left corners of each sprite.
                }
                if (points1[0, 1] < points2[0, 1]) // Compares which sprite is above the other.
                {
                    Y2Start = 0;
                    Y1Start = points2[0, 1] - points1[0, 1];
                }
                else // Used if the first sprite is below the other.
                {
                    Y1Start = 0;
                    Y2Start = points1[0, 1] - points2[0, 1];
                }
                int j = Y1Start;
                int j2 = Y2Start;
                for (int relY = 0; relY < YOverlap; relY++, j++, j2++) // this is the key for this function 
                {
                    int i = X1Start;
                    int i2 = X2Start;
                    for (int relX = 0; relX < XOverlap; relX++, i++, i2++)
                    {
                        bool pixel1 = sprite.GetPixel(i, j).A != Color.Transparent.A;
                        bool pixel2 = explosion.sprite.GetPixel(i2, j2).A != Color.Transparent.A;
                        if (pixel1 && pixel2)
                        {
                            sprite.SetPixel(i, j, Color.Transparent);
                        }
                    }
                }
            }
        }
        public override void Update()
        {

        }
        
    }
}
