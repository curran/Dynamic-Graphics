using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

/**
 * A drawing engine is an ordered collection of drawing steps
 * which are executed when draw() is invoked.
 */
namespace DynamicGraphics01
{
    /**
     * The delegate signature required for drawing steps.
     * Each drawing step should draw in g.
     */
    public delegate void DrawingStep(Graphics g);

    public class DrawingEngine
    {
        private List<DrawingStep> steps = new List<DrawingStep>();
        public void draw(Graphics g)
        {
            foreach (DrawingStep step in steps)
                step(g);
        }
        public void addDrawingStep(DrawingStep drawingStep)
        {
            steps.Add(drawingStep);
        }
    }
}
