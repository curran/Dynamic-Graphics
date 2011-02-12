using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
/**
 * A utility class for dealing with spawning an animation thread which 
 * increments a layout and redraws a form each frame.
 */
namespace DynamicGraphics01
{
    class Animation
    {
        public static void SpawnAnimationThread(LayoutEngine layoutEngine, Form form, int interFrameSleepTimeMillis)
        {
            BackgroundWorker animationThread = new BackgroundWorker();
            animationThread.WorkerReportsProgress = true;
            animationThread.WorkerSupportsCancellation = true;
            animationThread.DoWork += new DoWorkEventHandler(delegate(object sender, DoWorkEventArgs e)
            {
                while (true)
                {
                    layoutEngine.incrementLayout();
                    Thread.Sleep(interFrameSleepTimeMillis);
                    //Console.Out.WriteLine("Animating " + i);
                    animationThread.ReportProgress(0);
                }
            });
            animationThread.ProgressChanged += new ProgressChangedEventHandler(delegate(object sender, ProgressChangedEventArgs e)
            {
                form.Refresh();
            });
            animationThread.RunWorkerAsync();
        }
    }
}
