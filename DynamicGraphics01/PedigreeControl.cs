using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DynamicGraphics01
{
    class DrawingEngineControl : Control
    {
        private DrawingEngine drawingEngine;
        public DrawingEngineControl(DrawingEngine drawingEngine)
        {
            this.drawingEngine = drawingEngine;

            //enable double buffering to eliminate flicker
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

            //base.OnPaint(pe);
            Graphics g = pe.Graphics;

            //turn on anti-aliasing (smooth lines)
            g.SmoothingMode = SmoothingMode.AntiAlias;

            //leave the drawing to the drawing engine!
            drawingEngine.draw(g);
        }
    }
}
