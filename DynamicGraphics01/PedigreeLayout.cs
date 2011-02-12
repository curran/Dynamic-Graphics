using System;
using System.Collections.Generic;
using System.Text;
/**
 * This is a factory class for generating layout engines
 * which lay out pedigree models.
 */
namespace DynamicGraphics01
{
    class PedigreeLayout
    {
        /**
         * Generates a layout engine which will act on the given pedigree model.
         */
        public static LayoutEngine generateLayoutEngine(PedigreeModel model)
        {
            LayoutEngine layoutEngine = new LayoutEngine();
            return layoutEngine;
        }
    }
}
