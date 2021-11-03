using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class CarAutopilotTechs : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public CarAutopilotTechs () {
            requirements = new Knowledge[] { };
            leftDevTime = 500;
        }

        public override int getDevCost() {
            return 2000000;
        }

        public override int getDevTime() {
            return 500;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/CarAutopilotLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Car Autopilot Technologies";
        }

        public override double getRecommendedCost() {
            return 3000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Very advanced car drive assisting technologies which makes driving very safe. Sold to car constructors (contracts)";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "2000k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
