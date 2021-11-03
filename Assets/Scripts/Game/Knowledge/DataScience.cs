using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Knowledges {

    public class DataScience : Knowledge {

        public override string getImagePath() {
            return "";
        }

        public override string getName() {
            return "DATA SCIENCE";
        }

        public override string getToolTip() {
            return "Use machine learning techniques like clustering or classification to structure the data you collect and extract as much as you can from these.";
        }

    }

}
