using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SmartKitchen : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SmartKitchen () {
            requirements = new Knowledge[] { };
            leftDevTime = 300;
        }

        public override int getDevCost() {
            return 570000;
        }

        public override int getDevTime() {
            return 300;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SmartKitchenLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Smart Kitchen";
        }

        public override double getRecommendedCost() {
            return 4000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "A fully connected kitchen, with a lot of amazing features to optimize your clients time spent in the kitchen. Targeted Population: Middle and Upper class";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "570k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
