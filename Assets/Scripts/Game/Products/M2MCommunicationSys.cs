using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class M2MCommunicationSys : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public M2MCommunicationSys () {
            requirements = new Knowledge[] { };
            leftDevTime = 100;
        }

        public override int getDevCost() {
            return 300000;
        }

        public override int getDevTime() {
            return 100;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/M2MLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Advanced M2M Communication Systems";
        }

        public override double getRecommendedCost() {
            return 2100;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Allows you to implement M2M technologies (Wi-Fi, Bluetooth) and to create an efficient communication protocol to increase your IOT products' productivity";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "300k";
        }

        public override string getType() {
            return "Technology";
        }
    }

}
