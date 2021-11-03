using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    public class ClientDataCollection : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public ClientDataCollection () {
            requirements = new Knowledge[] { };
            leftDevTime = 250;
        }

        public override int getDevCost() {
            return 270000;
        }

        public override int getDevTime() {
            return 250;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/DataCollectionLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Client Data Collection System";
        }

        public override double getRecommendedCost() {
            return 0;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "Allows you to collect user data thanks to sold products. You can then do what you want with the data.";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
        }

        public override string getDevCostToDisplay() {
            return "270k";
        }

        public override string getType() {
            return "Software";
        }
    }

}
