using System;
using System.Collections.Generic;
using System.Text;
/**
 * A simple-as-possible immutable representation of an individual person used
 * only for the purpose of providing input data to the pedigree model. In this 
 * representation, an individual consists of an id, motherId, fatherId and gender.
 */
namespace DynamicGraphics01
{
    class SimpleIndividual
    {
        public static int NULL_ID = -1;
        public static int GENDER_MALE = 1;
        public static int GENDER_FEMALE = 2;
        

        public int id;
        public int motherId;
        public int fatherId;
        public int gender;
        /// <summary>
        /// Create a new simple individual.
        /// </summary>
        /// <param name="id">the id of this individual person</param>
        /// <param name="motherId">the id of the mother of this individual</param>
        /// <param name="fatherId">the id of the mother of this individual</param>
        /// <param name="gender">the gender of this individual. Use one of SimpleIndividual.GENDER_MALE or SimpleIndividual.GENDER_FEMALE</param>
        public SimpleIndividual(int id,int motherId,int fatherId, int gender){
            this.id = id;
            this.motherId = motherId;
            this.fatherId = fatherId;
        }
    }
}
