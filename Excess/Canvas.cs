using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Invaders
{
    class Canvas : Form
    {
        public Game game;
        public Canvas()
        {
            this.DoubleBuffered = true;
            this.Shown += Canvas_Shown; //Shown is the event, Canvas_Shown is the listener
        }

        private void Canvas_Shown(object sender, EventArgs e) // this is waiting for the window to be shown before creating the game
        { game = new Game(this); }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Canvas";
            this.Load += new System.EventHandler(this.Canvas_Load);
            this.ResumeLayout(false);
        }

        private void Canvas_Load(object sender, EventArgs e) { }
    }
}
