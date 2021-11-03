using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class FrameworkIOT : Product {

        private Knowledge[] requirements;

        private int leftDevTime;

        public FrameworkIOT () {
            leftDevTime = 50;
            requirements = new Knowledge[] { Knowledge.WEB_3_KNOWLEDGE };
        }

        public override int getDevCost() {
            return 10000;
        }

        public override int getDevTime() {
            return 50;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/FrameworkLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Framework for IOT Developers";
        }

        public override double getRecommendedCost() {
            return 500;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Greatly increases enterprises interest for our IOT products. Also increases Influence and Popularity";
        }

        public override void setLeftDevTime(int left) {
            this.leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "10k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
