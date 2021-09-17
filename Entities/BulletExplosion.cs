using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders
{
    class BulletExplosion : Entity
    {
        public char[,] graphic
        {
            get
            {
                char[,] val =
                {
                    {'0','.','.','.','0','.','.','0'},
                    {'.','.','0','.','.','.','0','.'},
                    {'.','0','0','0','0','0','0','.'},
                    {'0','0','0','0','0','0','0','0'},
                    {'0','0','0','0','0','0','0','0'},
                    {'.','0','0','0','0','0','0','.'},
                    {'.','.','0','.','.','0','.','.'},
                    {'0','.','.','0','.','.','.','0'},
                };
                return val;
            }
        }
        int timer = 0;
        public BulletExplosion(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
            SetGraphic(graphic);
        }
        public override void Update()
        {
            if (timer < 20)
            { timer++; }
            else
            { Delete(); }
        }
    }
}
