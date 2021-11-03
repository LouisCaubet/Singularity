using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity.Game {

    /// <summary>
    /// Abstract class representing an Innovation. Also contains instances of every Innovation (static)
    /// </summary>
    public abstract class Innovation {

        // Innovation definition
        
        // Generic

        /// <summary>
        /// Returns the DisplayName of the Innovation
        /// </summary>
        /// <returns>A string : the name of the Innovation</returns>
        public abstract string getName();
        /// <summary>
        /// Returns the cost (in days) of the Innovation
        /// </summary>
        /// <returns>An integer : cost in days of the innovation</returns>
        public abstract int getCost();
        /// <summary>
        /// Sets the cost of the innovation. Use reduceCost instead if you wanna reduce cost by 1.
        /// </summary>
        /// <param name="newcost">The new cost of the Innovation</param>
        public abstract void setCost(int newcost);
        /// <summary>
        /// Sets the innovation as Unavailable. Must be used if player chose an other branch.
        /// </summary>
        public abstract void setUnavailable();
        /// <summary>
        /// Returns if the innovation can be researched by the player. Does not checks if player has the prerequites innovations
        /// </summary>
        /// <returns></returns>
        public abstract bool isAvailable();
        /// <summary>
        /// Returns the date when the innovation's research was completed by player. Not Implemented for now
        /// </summary>
        /// <returns></returns>
        public abstract int getEndDate();

        /// <summary>
        /// Reduces innovation cost by 1. Call that if one day passed.
        /// </summary>
        public void reduceCost() {
            setCost(getCost() - 1);
        }

        /// <summary>
        /// Tells if player is currently researching this innovation
        /// </summary>
        /// <returns></returns>
        public abstract bool isStarted();

        /// <summary>
        /// Tells if player already finished researching this innovation
        /// </summary>
        /// <returns></returns>
        public abstract bool isFinished();

        // Childs
        /// <summary>
        /// Returns an array containing 1 or 2 innovation that can be researched once this one is done
        /// </summary>
        /// <returns></returns>
        public abstract Innovation[] getChilds();
        /// <summary>
        /// Returns child count of the innovation
        /// </summary>
        /// <returns></returns>
        public abstract int getChildCount();
        /// <summary>
        /// Returns the child at index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public abstract Innovation getChild(int index);

        // Display
        public abstract string getToolTip();
        public abstract string getScenario();
        public abstract string getImagePath();
        public abstract Unlockable[] unlockedObjects();

        // Cost text detailed gen
        public virtual string getCostText () {

            string text;

            if (isStarted()) {
                text = "<color=purple>Researching ...</color> <color=black>" + getCost() + " days left</color>"; 
            }
            else if (isFinished()) {
                text = "<color=purple>Research finished in " + getEndDate() + "</color>";
            }
            else if (!isAvailable()) {
                text = "<color=black>Unavailable  </color>";
            }
            else {
                text = "<color=black>Research : " + getCost() + " days</color>";
            }

            return text;

        }




        // Overrides from Object
        public override bool Equals(object obj) {
            
            if (! (obj is Innovation)) {
                return false;
            }

            return this.getName() == ((Innovation) obj).getName();

        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

    }
}
