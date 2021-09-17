using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Invaders
{
    class Game
    {
        public  static  HashSet<string> keys;
        public  static  List<Entity>    EntityList;
        public  Canvas      window;
        private Thread      gameLoopThread;
        public  EnemyBlob   blob;
        public  Player      player;
        public Game(Canvas canvas)
        {
            keys = new HashSet<string>();
            EntityList = new List<Entity>();
            for (int i = 0; i < 4; i++)
            {
                new Shield((i + 1) * (28) + (i * 22), 211 - 32); 
                // i + 1 iterates through the for loop.
                // i is multiplied by 28 to space the shield sprites apart by 28 pixels.
                // 
            }
            blob = new EnemyBlob();
            player = new Player();
            window = canvas;
            
            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.IsBackground = true; // Attempt to solve thread running after window closes
            gameLoopThread.Start();
            canvas.Paint += Canvas_Paint;       // This is listening for when the window is painted
            canvas.KeyDown += Canvas_KeyPress;
            canvas.KeyUp += Canvas_KeyRelease;
        }
        public void Canvas_KeyRelease(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                { keys.Remove("a"); }
            if (e.KeyCode == Keys.D)
                { keys.Remove("d"); }
            if (e.KeyCode == Keys.W)
                { keys.Remove("w"); }

        }
        public void Canvas_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                { keys.Add("a"); }
            if (e.KeyCode == Keys.D)
                { keys.Add("d"); }
            if (e.KeyCode == Keys.W)
                { keys.Add("w"); }
        }

        private void Canvas_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);

            blob.Update();
            for (int i = 0; i < EntityList.Count; i++)
            { EntityList[i].Update(); }         // Updates all classes within EntityList, as defined by which classes use ": base" in their constructors.
            for (int i = 0; i < EntityList.Count; i++)
            { EntityList[i].Render(graphics); } // Renders all classes within EntityList, as defined by which classes use ": base" in their constructors.
        }

        public void GameLoop()
        {
            while ( gameLoopThread.IsAlive )
            {
                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                Thread.Sleep(1);
            }
        }
    }
}
