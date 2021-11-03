using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class CreateSearchEngine : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public CreateSearchEngine() {
            requirements = new Knowledge[] { Knowledge.MATH_APPS, Knowledge.ADV_DATABASES };
            leftDevTime = getDevTime();
        }

        public override int getDevCost() {
            return 2000;
        }

        public override int getDevTime() {
            return 45;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/SearchEngineLogo";
        }

        public override string getName() {
            return "Create Search Engine";
        }

        public override double getRecommendedCost() {
            return 0;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Use your new knowledge in databases and algorithms to connect the internet! It's probably worth it...";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
            if (left == 0) {
                Events.ProductResearched.Invoke(this);
            }
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getDevCostToDisplay() {
            return getDevCost() + "";
        }

        public override string getType() {
            return "Web Service";
        }
    }

}
