using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicGraphics01
{
    public delegate void LayoutStep();
    public class LayoutEngine
    {
        private List<LayoutStep> steps = new List<LayoutStep>();
        public void incrementLayout(){
            foreach (LayoutStep step in steps)
                step();
        }
        public void addLayoutStep(LayoutStep layoutStep)
        {
            this.steps.Add(layoutStep);
        }
    }
}
