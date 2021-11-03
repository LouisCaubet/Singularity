using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SmartHomeApps : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SmartHomeApps () {
            requirements = new Knowledge[] { };
            leftDevTime = 80;
        }

        public override int getDevCost() {
            return 100000;
        }

        public override int getDevTime() {
            return 80;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SmartHomeAppsLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Smart Home Apps";
        }

        public override double getRecommendedCost() {
            return 200;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Allows your clients to manage a lot of things of their home by smartphone apps. Targeted Population: Everyone";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "100k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
