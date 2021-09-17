using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders
{
    abstract class Enemy : Entity
    {
        public abstract char[,] Graphic0 { get; }
        public abstract char[,] Graphic1 { get; }
        public char[,] DeathGraphic
        {
            get
            {
                char[,] val =
                {
                    {'.','.','.','.','.','0','.','.','.','0','.','.','.','.','.','.'},
                    {'.','.','0','.','.','.','0','.','0','.','.','.','0','.','.','.'},
                    {'.','.','.','0','.','.','.','.','.','.','.','0','.','.','.','.'},
                    {'.','.','.','.','0','.','.','.','.','.','0','.','.','.','.','.'},
                    {'.','0','0','.','.','.','.','.','.','.','.','.','0','0','.','.'},
                    {'.','.','.','.','0','.','.','.','.','.','0','.','.','.','.','.'},
                    {'.','.','.','0','.','.','0','.','0','.','.','0','.','.','.','.'},
                    {'.','.','0','.','.','0','.','.','.','0','.','.','0','.','.','.'}
                };
                return val;
            }
        }

        public Bitmap Position0;
        public Bitmap Position1;
        public bool ActiveSprite;
        public int xMove = 2;
        public int yMove = 8;

        public Enemy(int x, int y) : base() // Calls the constructor of the parent class (Entity.cs)
        {
            this.x = x;
            this.y = y;
            Position0 = CharArrayToBitmap(Graphic0);
            Position1 = CharArrayToBitmap(Graphic1);
            sprite = Position0;
            SetDeathGraphic(DeathGraphic);
        }
        public void Hit() 
        { Delete(); } // Hit is called in Bullet.cs in reference to EnemyList[i]. This function tells EnemyList[i] what to do when hit.
        public bool Move(bool LeftToRight)
        {
            ActiveSprite = !ActiveSprite;

            if (LeftToRight) { x += xMove; }
            else             { x -= xMove; }

            if (x <= 0)      { return true; }
            if (x >= 208)    { return true; }

            return false;
        }
        public override void Update()
        {
            if (ActiveSprite)   { sprite = Position0; }
            else                { sprite = Position1; }            
        }
    }
}
