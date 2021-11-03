using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class ClientTracker : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public ClientTracker () {
            requirements = new Knowledge[] { };
            leftDevTime = 200;
        }

        public override int getDevCost() {
            return 600000;
        }

        public override int getDevTime() {
            return 200;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/ClientTrackingLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Client Tracking with IOT";
        }

        public override double getRecommendedCost() {
            return 40000;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Offer the enterprises an easy way to track their clients, using IOT devices.";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "600k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
