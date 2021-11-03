using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SyncPositionSysIOT : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SyncPositionSysIOT () {
            requirements = new Knowledge[] { };
            leftDevTime = 200;
        }

        public override int getDevCost() {
            return 480000;
        }

        public override int getDevTime() {
            return 200;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/PositioningLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Synchronized Positioning System using IOT";
        }

        public override double getRecommendedCost() {
            return 26000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Offer the enterprises an easy and powerful way to localize their objects, using the GPS technology.";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "480k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
