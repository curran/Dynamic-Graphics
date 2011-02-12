using System;
using System.Collections.Generic;
using System.Text;
/**
 * A couple object in a pedigree.
 */
namespace DynamicGraphics01
{
    class PedigreeCouple
    {
        /**
         * The location and velocity of the couple
         */
        public PointWithVelocity point;

        public PedigreeIndividual mother, father;
        public List<PedigreeIndividual> children = new List<PedigreeIndividual>();
        public List<PedigreeCouple> parentCouples = new List<PedigreeCouple>();
        public List<PedigreeCouple> childrenCouples = new List<PedigreeCouple>();
        public List<PedigreeCouple> neighboringCouples = new List<PedigreeCouple>();

        public PedigreeCouple(PedigreeIndividual mother, PedigreeIndividual father, PointWithVelocity point)
        {
            this.mother = mother;
            this.father = father;
            this.point = point;
        }
    }
}
