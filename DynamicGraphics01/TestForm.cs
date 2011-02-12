using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DynamicGraphics01
{
    public partial class TestForm : Form
    {
        /**
         * The time to sleep between frames
         */
        int interFrameSleepTimeMillis = 20;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            List<SimpleIndividual> individuals = new List<SimpleIndividual>();
            int NIL = SimpleIndividual.NULL_ID;
            int MALE = SimpleIndividual.GENDER_MALE;
            int FEMALE = SimpleIndividual.GENDER_FEMALE;

            individuals.Add(new SimpleIndividual(0, NIL, NIL, MALE));
            individuals.Add(new SimpleIndividual(1, NIL, NIL, FEMALE));
            individuals.Add(new SimpleIndividual(2, 0, 1, FEMALE));

            //create the pedigree model from the input data
            PedigreeModel model = new PedigreeModel(individuals);

            //create the layout engine, which is responsible for
            //updating the state of the model each frame
            LayoutEngine layoutEngine = PedigreeLayout.generateLayoutEngine(model);

            //create the drawing engine, which is responsible for
            //visualizing the state of the model each frame
            DrawingEngine drawingEngine = PedigreeDrawing.generateDrawingEngine(model);

            //create the user control which will do the drawing
            DrawingEngineControl control = new DrawingEngineControl(drawingEngine);

            //wire the necessary mouse events from the control to the model
            control.MouseDown += model.MouseDown;
            control.MouseMove += model.MouseMove;
            control.MouseUp += model.MouseUp;

            //add the control to this form
            control.Location = new System.Drawing.Point(0, 0);
            int w = ClientSize.Width, h = ClientSize.Height;
            control.Size = new System.Drawing.Size(w, h);
            this.Controls.Add(control);

            //spawn a new thread which periodically increments the 
            //layout and redraws the pedigree
            Animation.SpawnAnimationThread(layoutEngine, this, interFrameSleepTimeMillis);


        }

    }
}
