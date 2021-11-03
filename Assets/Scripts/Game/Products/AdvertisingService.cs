using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class AdvertisingService : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public AdvertisingService () {
            requirements = new Knowledge[0];
            leftDevTime = getDevTime();
        }

        public override int getDevCost() {
            return 200000;
        }

        public override int getDevTime() {
            return 45;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/TargetedAdvertisingSysLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Targeted Advertising Service";
        }

        public override double getRecommendedCost() {
            return 0;
        }

        public override Knowledge[] getRequirements() {
            return requirements; 
        }

        public override string getToolTip() {
            return "Advertising is a great source of income. Targeted Advertising is the future of advertising. Be part of it!";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
            if (left == 0) {
                Events.ProductResearched.Invoke(this);
            }
        }

        public override string getDevCostToDisplay() {
            return "200k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
