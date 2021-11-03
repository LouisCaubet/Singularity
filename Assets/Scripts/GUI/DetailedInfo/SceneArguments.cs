using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singularity.GUI.DetailedInfo {

    public class SceneArguments : MonoBehaviour {

        public static string AreaName = "null";
        public static string ImagePath = "null";

        // TODO implement Bonus / Malus


        // Current informations
        public static string AreaStatus = "developed";
        public static string Satisfaction = "null";
        public static string Unemployment = "null";
        public static string EnterpriseInfluence = "null";
        public static string EnterprisePopularity = "null";

        public static void writeArgs(string name, string path, string status, string satisfaction, string unemployment, string influence, string popularity) {
            AreaName = name;
            ImagePath = path;
            AreaStatus = status;
            Satisfaction = satisfaction;
            Unemployment = unemployment;
            EnterpriseInfluence = influence;
            EnterprisePopularity = popularity;
        }

    }

}


