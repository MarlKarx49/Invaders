using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders
{
    class Plunger : Projectiles
    {
        public override char[][,] AnimatedSprites
        {
            get
            {
                char[][,] val = new char[4][,];
                val[0] = new char[,]
                {
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'0','0','0'},
                        {'.','.','.'},
                        {'.','.','.'},
                };
                val[1] = new char[,]
                {
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'0','0','0'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','.','.'},
                        {'.','.','.'},
                };
                val[2] = new char[,]
                {
                        {'.','0','.'},
                        {'.','0','.'},
                        {'0','0','0'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','.','.'},
                        {'.','.','.'},
                };
                val[3] = new char[,]
                {
                        {'0','0','0'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','0','.'},
                        {'.','.','.'},
                        {'.','.','.'},
                };
                return val;
            }
        }
        public Plunger(int x, int y) : base(x, y)
        {
             
        }
    }
}


