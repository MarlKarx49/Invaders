using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Player : Entity
    {
        public char[,] Graphic =
            {
                { '.','.','.','.','.','.','0','.','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','.','.','.','.','0','0','0','.','.','.','.','.'},
                { '.','0','0','0','0','0','0','0','0','0','0','0','.'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
                { '0','0','0','0','0','0','0','0','0','0','0','0','0'},
            };

        public int vx;
        public Bullet bullet;
        public Player() : base() // Calls constructor of the parent class (Entity.cs)
        {
            vx = 0;
            y = 211;
            x = 105;
            SetGraphic(Graphic);
        }
        public override void Update()
        {
            if (Game.keys.Contains("a") && x > 0)
            { vx = -2; }
            else if (Game.keys.Contains("d") && x < 223)
            { vx = 2; }
            else
            { vx = 0; }
            // Movement logic above.
            // Shooting logic below.
            if (Game.keys.Contains("w"))
            { 
                if (bullet == null)
                {
                    bullet = new Bullet();
                    bullet.x = x + 6;
                    bullet.y = y - 4;
                    bullet.Deleted += Bullet_Deleted;
                }
            }
            x += vx;
        }
        private void Bullet_Deleted(object sender, EventArgs e)
        {
            bullet = null; // Deletes bullet entity.
        }
    }
}
