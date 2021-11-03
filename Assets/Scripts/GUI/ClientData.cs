using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Singularity {

    public static class ClientData {

        // GUI data
        public static Vector3 position3D = new Vector3(549, 279, 0);
        public static Quaternion rotation3D = Quaternion.Euler(new Vector3(0, 0, 0));
        public static GUI.InnovationTree.InnovationDetailsWindow activeDetailsWindow = null;

    }

}
