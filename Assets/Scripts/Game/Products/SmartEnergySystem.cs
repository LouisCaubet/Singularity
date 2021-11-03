using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SmartEnergySystem : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SmartEnergySystem () {
            requirements = new Knowledge[] { };
            leftDevTime = 400;
        }

        public override int getDevCost() {
            return 1000000;
        }

        public override int getDevTime() {
            return 400;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SmartEnergyLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Smart Energy Saving Systems";
        }

        public override double getRecommendedCost() {
            return 1000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Do something good for the climate by creating a product which optimizes energy usages by houses. Targeted Population: everyone";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "1000k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
