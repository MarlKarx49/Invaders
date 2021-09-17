using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Invaders
{
    class EnemyBlob
    {
        public List<Enemy> enemies;
        public Enemy LastMoved;
        public Enemy SecondLastMoved;
        public Spiral spiral = null;
        public Squiggly squiggly = null;
        public Plunger plunger = null;
        public Random rnd = new Random();

        public int startingx = 16;
        public int startingy = 40;
        public int frameCount = 0;
        public bool leftToRight;
        public bool moveDown;
        public EnemyBlob()
        {
            enemies = new List<Enemy>();
            for (int i = 0; i < 1; i++)
            {
                startingx = 16;                                     // Clarifies the X coordinates of the first sprite in the row.
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    enemies.Add(new Squid(startingx, startingy));   // Adds a sprite at the coordinates defined by startingx and startingy
                    startingx += 16;                                // Moves the starting position for the next sprite by 16 pixels.
                }
                startingy += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.
            } // Creates Squid sprites on the first row, as defined by the range of "i".
            for (int i = 1; i < 3; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)                        // The range of j defines the number of sprites in a row.
                {
                    enemies.Add(new Crab(startingx, startingy));    // Adds a sprite at the coordinates defined by startingx and startingy
                    startingx += 16;                                // Moves the starting position of the next sprite by 16 pixels on the X axis.
                }
                startingy += 16;                                    // Moves the starting position for the next row by 16 pixels on the Y axis.

            } // Creates Crab sprites on the second and third rows, as defined by the range of "i".
            for (int i = 3; i < 5; i++)
            {
                startingx = 16;
                for (int j = 0; j < 11; j++)
                {
                    enemies.Add(new Octopus(startingx, startingy));
                    startingx += 16;
                }
                startingy += 16;
            } // Creates Octopus sprites on the fourth and fifth rows, as defined by the range of "i".
            for (int i = 0; i < enemies.Count; i++) 
            {
                enemies[i].Deleted += EnemyBlob_Deleted;
            }
            LastMoved = enemies[enemies.Count - 1];
            SecondLastMoved = enemies[enemies.Count - 2];
        }
        public void EnemyBlob_Deleted(object sender, EventArgs e)
            { enemies.Remove((Enemy)sender); } /* (Enemy) sender is the method to static cast the "Enemy" class to "sender". */ 
        public void Update()
        {
            int move = 0;
            bool hitWall;
            if (enemies.Count > 0)
            {
                if (enemies.FindIndex(x => x == LastMoved) != -1) // If FindIndex doesn't find anything, the value is equal to -1.
                    { move = enemies.FindIndex(x => x == LastMoved); }
                else
                    { move = enemies.FindIndex(x => x == SecondLastMoved); } // Ensures that there is an enemy left to apply this function to in case LastMoved is destroyed in the same frame the function runs.
                move++;
                if (move >= enemies.Count)
                    { move = 0; }
                hitWall = enemies[move].Move(leftToRight);
                if (hitWall)
                    { moveDown = true; }
                if (move == enemies.Count - 1 && moveDown)
                {
                    foreach (Enemy enemy in enemies)
                        { enemy.y += enemy.yMove; }
                    moveDown = false;
                    leftToRight = !leftToRight;
                }
                SecondLastMoved = LastMoved;
                LastMoved = enemies[move];
                Enemy firing = enemies[rnd.Next(enemies.Count)];
                if (rnd.Next(3) == 0 && spiral == null)
                {
                    spiral = new Spiral(firing.x + (firing.Width - 3) / 2, firing.y + firing.Height);
                    spiral.Deleted += Spiral_Deleted;
                }
                if (rnd.Next(3) == 0 && plunger == null)
                {
                    plunger = new Plunger(firing.x + (firing.Width - 3) / 2, firing.y + firing.Height);
                    plunger.Deleted += Plunger_Deleted; 
                }
                if (rnd.Next(3) == 0 && squiggly == null)
                {
                    squiggly = new Squiggly(firing.x + (firing.Width - 3) / 2, firing.y + firing.Height);
                    squiggly.Deleted += Squiggly_Deleted;
                }
            }
        }

        private void Squiggly_Deleted(object sender, EventArgs e)
        {
            squiggly = null;
        }

        private void Plunger_Deleted(object sender, EventArgs e)
        { plunger = null; }
        private void Spiral_Deleted(object sender, EventArgs e)
        { spiral = null; }

        public void Render(Graphics graphics)
        {
            foreach (Enemy enemy in enemies)
                { enemy.Render(graphics); }
        }
    }
}