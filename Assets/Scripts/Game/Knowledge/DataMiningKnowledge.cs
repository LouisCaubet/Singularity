using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Knowledges {

    public class DataMiningKnowledge : Knowledge {

        public override string getImagePath() {
            return "";
        }

        public override string getName() {
            return "DATA MINING KNOWLEDGE";
        }

        public override string getToolTip() {
            return "Data Mining is the first and essential part of any big data program : collect the most interesting data you can. It's an amazing business, as these data can be sold for a lot.";
        }

    }

}
