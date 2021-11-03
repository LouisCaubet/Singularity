using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Products {

    // Product to unlock in a research if no product is unlocked by this research
    public class AbstractResearch : Product {

        private Knowledge[] requirements;

        public AbstractResearch() {
            requirements = new Knowledge[0];
        }

        public override int getDevCost() {
            return -1;
        }

        public override string getDevCostToDisplay() {
            return "UNSUPPORTED";
        }

        public override int getDevTime() {
            return -1;
        }

        public override string getImagePath() {
            return "";
        }

        public override int getLeftDevTime() {
            return -1;
        }

        public override string getName() {
            return "Abstract Innovation";
        }

        public override double getRecommendedCost() {
            return -1;
        }

        public override Knowledge[] getRequirements() {
            return requirements;
        }

        public override string getToolTip() {
            return "This innovation won't allow you to create new products immediately. You will have to specialize yourself to use the knowledge that you will acquire.";
        }

        public override string getType() {
            throw new NotSupportedException();
        }

        public override void setLeftDevTime(int left) { }
    }

}
