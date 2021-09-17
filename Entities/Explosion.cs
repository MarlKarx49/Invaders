using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    class Explosion : Entity
    {
        public int Timer;

        public Explosion(int x, int y, Bitmap DeathSprite)
        {
            this.x = x;
            this.y = y;
            this.sprite = DeathSprite;
        }
        public override void Update()
        {
            if (Timer < 20) { Timer++; }
            else { Delete(); }
        }
    }
}
