using System;
using System.Collections.Generic;
using System.Text;
/**
 * An individual person object in a pedigree. This contains
 * both a reference to the original SimpleIndividual represented
 * by this PedigreeIndividual (which contains the id, motherId,
 * fatherId, etc.) and the location and velocity of the individual
 * in a pedigree.
 */
namespace DynamicGraphics01
{
    class PedigreeIndividual
    {
        /**
         * The location and velocity of the individual
         */
        public PointWithVelocity point;

        /**
         * The original data about this individual.
         */
        public SimpleIndividual simpleIndividual;

        /**
         * The parents of this individual (set in the constructor of PedigreeModel).
         */
        public PedigreeCouple parents;

        public PedigreeIndividual(SimpleIndividual simpleIndividual, PointWithVelocity point)
        {
            this.simpleIndividual = simpleIndividual;
            this.point = point;
        }
    }
}
