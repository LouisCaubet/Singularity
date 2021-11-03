using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Singularity.Game.MarketingTechs;

namespace Singularity.Game {

    public abstract class MarketingTech {

        // Generic
        public abstract string getName();
        public abstract string getDescription();
        public abstract string getImagePath();

        // Display
        public abstract int getRow();
        public abstract int getPosInRow();

        // Cost
        public abstract int getCost();
        public abstract void setCost(int newcost);

        public void reduceCost() {
            setCost(getCost() - 1);
        }

        // Requirements (other than parent MarketingTech)
        public abstract Unlockable[] getRequirements();

        // Unlocks - TODO
        public abstract Unlockable[] getUnlocked();

        // Availabitity
        public abstract void setUnavailable();
        public abstract bool isAvailable();

        public abstract bool isStarted();

        public abstract bool isFinished();

        // Childs
        public abstract MarketingTech[] getChilds();
        public abstract int getChildCount();


        public virtual string getCostText() {

            if (isStarted()) {
                return "<color=purple> Researching...</color><color=black> " + getCost() + " days left</color> "; 
            }

            if (isFinished()) {
                return "Research done!";
            }

            if (!isAvailable()) {
                return "<color=black>Unavailable</color>";
            }

            return "Research : " + getCost() + " days.";

        }


        // Overrides from Object
        public override bool Equals(object obj) {

            if (!(obj is MarketingTech)) {
                return false;
            }

            return this.getName() == ((MarketingTech)obj).getName();

        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

    }

}
