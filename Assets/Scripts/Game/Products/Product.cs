using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singularity.Game.Products;

namespace Singularity.Game {

    public abstract class Product : Unlockable {

        // Abstract Research - product to tell that innovation does not unlock anything else.
        public static AbstractResearch ABSTRACT_RESEARCH = new AbstractResearch();


        public abstract string getName();
        public abstract string getType();
        public abstract string getToolTip();
        public abstract string getImagePath();

        public abstract int getDevCost();
        public abstract int getDevTime();
        public abstract string getDevCostToDisplay();

        public abstract void setLeftDevTime(int left);
        public abstract int getLeftDevTime();

        public virtual void decreaseLeftDevTime() {
            setLeftDevTime(getLeftDevTime() - 1);
        }

        public abstract Knowledge[] getRequirements();
        // TODO get Marketing techniques required
        public abstract double getRecommendedCost();
        
    }

}
