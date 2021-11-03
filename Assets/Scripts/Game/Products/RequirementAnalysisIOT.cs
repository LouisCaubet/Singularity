using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class RequirementAnalysisIOT : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public RequirementAnalysisIOT () {
            requirements = new Knowledge[] { };
            leftDevTime = 70;
        }

        public override int getDevCost() {
            return 15000;
        }

        public override int getDevTime() {
            return 70;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/EnterprisesRequirementsLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Enterprises IOT Requirements Analysis Platform";
        }

        public override double getRecommendedCost() {
            return 0;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Can be distributed to enterprises to increase their interest on our IOT products.\n" +
                "Unlocks : Contracts with enterprises";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "15k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
