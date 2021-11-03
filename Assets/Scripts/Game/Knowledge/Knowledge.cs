using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singularity.Game.Knowledges;

namespace Singularity.Game {

    public abstract class Knowledge : Unlockable {

        // Instances
        public static CreateApps CREATE_APPS = new CreateApps();
        public static MathForApps MATH_APPS = new MathForApps();
        public static Databases DATABASES = new Databases();
        public static AdvDatabases ADV_DATABASES = new AdvDatabases();
        public static Web3 WEB_3_KNOWLEDGE = new Web3();
        public static EmbeddedSysProgramming EMBEDDED_SYS_PROGRAMMING = new EmbeddedSysProgramming();
        public static CloudProgramming CLOUD_PROGRAMMING = new CloudProgramming();
        public static Networking NETWORKING = new Networking();
        public static DataMiningKnowledge DATA_MINING = new DataMiningKnowledge();
        public static DataScience DATA_SCIENCE = new DataScience();

        public abstract string getName();
        public abstract string getToolTip();
        public abstract string getImagePath();

    }

}
