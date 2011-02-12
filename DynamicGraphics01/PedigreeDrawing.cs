using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DynamicGraphics01
{
    class PedigreeDrawing
    {
        private static Pen pen = new Pen(Brushes.Black);
        private static Rectangle rect = new Rectangle(0,0,10,10);

        /**
         * Generates a drawing engine which will draw the given pedigree model.
         */
        public static DrawingEngine generateDrawingEngine(PedigreeModel model)
        {
            DrawingEngine drawingEngine = new DrawingEngine();
            
            drawingEngine.addDrawingStep(delegate(Graphics g)
            {
                foreach (PedigreeCouple couple in model.couples)
                {
                    rect.X = (int)couple.point.x;
                    rect.Y = (int)couple.point.y;

                    g.DrawEllipse(pen, rect);
                }
            });

            return drawingEngine;
        }
    }
}
