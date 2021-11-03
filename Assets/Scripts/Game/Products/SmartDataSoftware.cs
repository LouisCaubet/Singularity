using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SmartDataSoftware : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SmartDataSoftware () {
            requirements = new Knowledge[] { };
            leftDevTime = 80;
        }

        public override int getDevCost() {
            return 290000;
        }

        public override int getDevTime() {
            return 80;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SmartDataLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Smart Data Software";
        }

        public override double getRecommendedCost() {
            return 3500;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Allows you to offer the enterprises a structured and detailed analysis of the big amounts of data collected thanks to IOT.";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "290k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
