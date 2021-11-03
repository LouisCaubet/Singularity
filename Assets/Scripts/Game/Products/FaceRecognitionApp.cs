using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity.Game.Products {

    public class FaceRecognitionApp : Product {

        private Knowledge[] requirements;
        private int leftDevTime;

        public FaceRecognitionApp() {
            requirements = new Knowledge[] { Knowledge.CREATE_APPS };
            leftDevTime = getDevTime();
        }

        public override int getDevCost() {
            return 500;
        }

        public override int getDevTime() {
            return 15;
        }

        public override string getImagePath() {
            return "GUI/ProjectView/Logos/FaceRecognitionLogo";
        }

        public override int getLeftDevTime() {
            return leftDevTime;
        }

        public override string getName() {
            return "Create a face recognition app";
        }

        public override double getRecommendedCost() {
            return 4.99;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "This is the first app you can create with your new Machine Learning knowledge.";
        }

        public override void setLeftDevTime(int left) {
            leftDevTime = left;
            if (left == 0) {
                Events.ProductResearched.Invoke(this);
            }
        }

        public override string getDevCostToDisplay() {
            return getDevCost() + "";
        }

        public override string getType() {
            return "App";
        }
    }

}
