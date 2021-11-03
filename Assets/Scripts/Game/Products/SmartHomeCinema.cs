using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class SmartHomeCinema : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public SmartHomeCinema () {
            requirements = new Knowledge[] { };
            leftDevTime = 430;
        }

        public override int getDevCost() {
            return 1200000;
        }

        public override int getDevTime() {
            return 430;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SmartCinemaLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Smart Home Cinema";
        }

        public override double getRecommendedCost() {
            return 19000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "A connected home cinema with amazing lights and sound, and all the best gadgets. Targeted population: Upper classes";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "1200k";
        }

        public override string getType() {
            return "Device";
        }
    }

}
