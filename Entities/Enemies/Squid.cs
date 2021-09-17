using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Squid : Enemy
    {
        public override char[,] Graphic0
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','0','0','.','.','.'},
                    {'.','.','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','.'},
                    {'0','0','.','0','0','.','0','0'},
                    {'0','0','0','0','0','0','0','0'},
                    {'.','.','0','.','.','0','.','.'},
                    {'.','0','.','0','0','.','0','.'},
                    {'0','.','0','.','.','0','.','0'},
                };
                return val;
            }
        }         // Inherits Graphic0 from Enemy.cs
        public override char[,] Graphic1
        {
            get
            {
                char[,] val =

                {
                    {'.','.','.','0','0','.','.','.'},
                    {'.','.','0','0','0','0','.','.'},
                    {'.','0','0','0','0','0','0','.'},
                    {'0','0','.','0','0','.','0','0'},
                    {'0','0','0','0','0','0','0','0'},
                    {'.','0','.','0','0','.','0','.'},
                    {'0','.','.','.','.','.','.','0'},
                    {'.','0','.','.','.','.','0','.'},
                };
                return val;
            }
        } // Inherits Graphic0 from Enemy.cs
        public Squid(int x, int y) : base(x, y) { } // Calls base constructor
    }
}