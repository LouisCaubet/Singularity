using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singularity.Game.Knowledges {

    public class Databases : Knowledge {

        public Databases () {
            
        }

        public override string getImagePath() {
            return "";
        }

        public override string getName() {
            return "Database Knowledge";
        }

        public override string getToolTip() {
            return "Databases, SQL, and all that won't be a secret for you anymore! Use them to improve all your products!";
        }
    }

}
