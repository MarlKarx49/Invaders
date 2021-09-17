using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Invaders
{
    abstract class Projectiles : Entity
    {
        public Bitmap[] sprites = new Bitmap[4]; // The "4" clarifies the number of items in the array.
        public abstract char[][,] AnimatedSprites { get; }
        public int SpriteFrame = 0;
        public int FrameCount = 0;
        public Projectiles(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
            y = 0;
            
            sprite = new Bitmap(1, 4);
            for (int i = 0; i < 4; i++)
                {
                sprites[i] = CharArrayToBitmap(AnimatedSprites[i]);
                }
            sprite = sprites[SpriteFrame];
        }
        public override void Update()
        {
            if (y > 223)
                { Delete(); }
            else
            {
                for (int i = 0; i < Game.EntityList.Count; i++)
                {
                    Entity entity = Game.EntityList[i];
                    if (entity is Player)
                    {
                        if (x <= (entity.x + entity.Width) && x >= entity.x && y <= entity.y && y >= (entity.y - entity.Height))
                        {
                            Delete();
                        }
                    }
                    else if (entity is Shield)
                    {
                        if (IsColliding(entity))
                        {
                            int[] location = ((Shield)entity).FindIntersect(this); //looking for a single [x] 
                            if (location[0] != -1) //if the array location doens't equal -1 (would be above the window extents). 
                            {
                                BulletExplosion explosion = new BulletExplosion(x - 4, y - 2);
                                ((Shield)entity).Damage(explosion);
                                Delete();
                            }
                        }
                    }
                }
            }
            if (FrameCount % 3 == 2) // 0 % 3 = 0, 2 % 3 = 2, 3 % 3 = 0, 4 % 3 = 1 
            {
                SpriteFrame = ++SpriteFrame % 4;
                sprite = sprites[SpriteFrame];
                y += 2;
            }
            FrameCount++;
        }
    }
}
