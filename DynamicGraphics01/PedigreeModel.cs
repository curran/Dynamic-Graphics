using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
/**
 * The top level stateful object model for a dynamic interactive pedigree.
 * The layout engine acts only on objects contained within a pedigree model.
 * This means that the pedigree model must contain, in addition to individuals
 * and couples, a representation of the state of uder interface (namely the 
 * mouse position, touch positions, and the state of drag gestures). To wire
 * a events from a control to a given pedigree model p, you must add mouse listeners
 * which call to p.MouseDown, p.MouseMoved, and p.MouseUp.
 */
namespace DynamicGraphics01
{
    class PedigreeModel
    {
        /**
         * Maps individual ids to individual objects.
         */
        private Dictionary<int, PedigreeIndividual> individualsMap = new Dictionary<int, PedigreeIndividual>();
        /**
         * A list containing all individuals.
         */
        public List<PedigreeIndividual> individuals = new List<PedigreeIndividual>();

        /**
        * Maps individual ids to the couples those individuals are part of.
        */
        private Dictionary<int, PedigreeCouple> couplesMap = new Dictionary<int, PedigreeCouple>();

        /**
         * A list containing all couples.
         */
        public List<PedigreeCouple> couples = new List<PedigreeCouple>();

        Random random = new Random();

        public PedigreeModel(List<SimpleIndividual> simpleIndividuals)
        {
            // initialize (with random coordinates) and index all individuals
            
            foreach (SimpleIndividual simpleIndividual in simpleIndividuals)
            {
                PedigreeIndividual pedigreeIndividual = new PedigreeIndividual(simpleIndividual, RandomPoint());

                individuals.Add(pedigreeIndividual);
                individualsMap.Add(simpleIndividual.id, pedigreeIndividual);
            }

            // derive and index all couples
            foreach (PedigreeIndividual child in individuals)
            {
                PedigreeIndividual mother = null;
                if (individualsMap.ContainsKey(child.simpleIndividual.motherId))
                    mother = individualsMap[child.simpleIndividual.motherId];

                PedigreeIndividual father = null;
                if (individualsMap.ContainsKey(child.simpleIndividual.fatherId))
                    father = individualsMap[child.simpleIndividual.fatherId];

                if (mother != null && father != null)
                {
                    PedigreeCouple parents = null;

                    if (couplesMap.ContainsKey(mother.simpleIndividual.id))
                        parents = couplesMap[mother.simpleIndividual.id];
                    else
                    {
                        parents = new PedigreeCouple(mother, father, RandomPoint());
                        couples.Add(parents);
                        couplesMap.Add(mother.simpleIndividual.id, parents);
                        couplesMap.Add(father.simpleIndividual.id, parents);
                    }
                    parents.children.Add(child);
                    child.parents = parents;
                }
            }
        }

        private PointWithVelocity RandomPoint()
        {
            PointWithVelocity randomPoint = new PointWithVelocity();
            randomPoint.x = random.Next(100);
            randomPoint.y = random.Next(100);
            return randomPoint;
        }


        public void MouseDown(object sender, MouseEventArgs e) { }
        public void MouseMove(object sender, MouseEventArgs e) { }
        public void MouseUp(object sender, MouseEventArgs e) { }


    }
}
